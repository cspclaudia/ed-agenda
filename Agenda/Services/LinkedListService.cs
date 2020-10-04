using System.Linq;
using Agenda.Models;
using MongoDB.Driver;

namespace Agenda.Services
{
    public class LinkedListService
    {
        private readonly IMongoCollection<Node> _node;
        private readonly IMongoCollection<LinkedList> _linkedList;

        public LinkedListService (IDatabaseSettings settings)
        {
            var client = new MongoClient (settings.ConnectionString);
            var database = client.GetDatabase (settings.DatabaseName);

            _node = database.GetCollection<Node> (settings.NodeCollectionName);
            _linkedList = database.GetCollection<LinkedList> (settings.LinkedListCollectionName);
        }

        LinkedList lista = new LinkedList ();
        public Node Add (Contato contato)
        {
            var filter = Builders<LinkedList>.Filter.Exists ("item", false);
            var result = _linkedList.Find (filter).ToList ();
            if (result.Count != 0)
            {
                lista = _linkedList.Find (head => true).First ();
            }
            Node aux = lista.Head;
            Node node = new Node (contato);
            if (lista.Head != null)
            {
                if (aux.Id == aux.Next.Id)
                {
                    node.Before = aux.Id;
                    node.Next = lista.Head;
                    _node.InsertOne (node);
                    aux.Before = node.Id;
                    aux.Next.Id = node.Id;
                    _node.ReplaceOne (n => n.Id == lista.Head.Id, aux);
                }
                else
                {
                    while (aux.Next.Id != lista.Head.Id)
                    {
                        aux = aux.Next;
                    }
                    _node.InsertOne (node);
                    lista.Head.Before = node.Id;
                    node.Next = lista.Head;
                    node.Before = aux.Id;
                    _node.ReplaceOne (n => n.Id == node.Id, node);
                    aux.Next.Id = node.Id;
                    _node.ReplaceOne (n => n.Id == aux.Id, aux);
                }
            }
            else
            {
                _node.InsertOne (node);
                node.Before = node.Id;
                node.Next = new Node ();
                node.Next.Id = node.Id;
                _node.ReplaceOne (n => n.Id == node.Id, node);
            }
            lista.Head = node;
            _linkedList.DeleteOne (node => true);
            _linkedList.InsertOne (lista);

            return node;
        }

        public LinkedList Find ()
        {
            LinkedList lista = _linkedList.Find (node => true).FirstOrDefault ();
            if (lista == null)
            {
                lista = new LinkedList ();
            }
            return lista;
        }

        public Node Find (string id)
        {
            LinkedList lista = _linkedList.Find (head => true).First ();
            Node node = lista.Head;
            while ((node != null) && (node.Id != id))
            {
                node = node.Next;
            }
            return node;
        }

        public void Edit (string id, Contato contato)
        {
            LinkedList lista = _linkedList.Find (head => true).First ();
            Node node = lista.Head;
            while ((node != null) && (node.Id != id))
            {
                node = node.Next;
            }
            node.Contato = contato;
            _node.ReplaceOne (node => node.Id == id, node);
            _linkedList.DeleteOne (node => true);
            _linkedList.InsertOne (lista);
        }

        public void Delete (Node node)
        {
            LinkedList lista = _linkedList.Find (head => true).First ();
            Node ant = null;
            Node aux = lista.Head;
            Node pos = aux.Next;
            while ((aux != null) && (aux.Id != node.Id))
            {
                ant = aux;
                aux = aux.Next;
                pos = aux.Next;
            }
            if (ant == null)
            {
                if (aux.Id != aux.Next.Id)
                {
                    pos.Before = aux.Before;
                    lista.Head = pos;
                    _node.ReplaceOne (n => n.Before == node.Id, pos);
                    do
                    {
                        aux = aux.Next;
                    }
                    while (aux.Next.Contato != null);
                    aux.Next.Id = pos.Id;
                    _node.ReplaceOne (n => n.Before == node.Id, aux);
                }
                else 
                {
                    lista.Head = null;
                }
            }
            else if (pos.Id == lista.Head.Id)
            {
                lista.Head.Before = ant.Id;
                ant.Next = aux.Next;
                _node.ReplaceOne (n => n.Next == node, ant);
            }
            else
            {
                ant.Next = aux.Next;
                _node.ReplaceOne (n => n.Next == node, ant);
                pos.Before = aux.Before;
                _node.ReplaceOne (n => n.Before == node.Id, pos);
            }
            _linkedList.DeleteOne (lista => true);
            _linkedList.InsertOne (lista);
            _node.DeleteOne (n => n.Id == node.Id);
        }

        public LinkedList SortName ()
        {
            var filter = Builders<LinkedList>.Filter.Exists ("item", false);
            var result = _linkedList.Find (filter).ToList ();
            if (result.Count != 0)
            {
                lista = _linkedList.Find (head => true).First ();
            }
            Node node = lista.Head;
            Contato aux = null;
            int count = 1;
            while (node.Next.Id != lista.Head.Id)
            {
                count++;
                node = node.Next;
            }
            node = lista.Head;
            for (var i = 0; i < count; i++)
            {
                do
                {
                    if (node.Next.Contato.Nome.CompareTo (node.Contato.Nome) < 0)
                    {
                        aux = node.Contato;
                        node.Contato = node.Next.Contato;
                        node.Next.Contato = aux;
                    }
                    node = node.Next;
                }
                while (node.Next.Id != lista.Head.Id);
                node = lista.Head;
            }
            return lista;
        }

        public LinkedList SortEmail ()
        {
            var filter = Builders<LinkedList>.Filter.Exists ("item", false);
            var result = _linkedList.Find (filter).ToList ();
            if (result.Count != 0)
            {
                lista = _linkedList.Find (head => true).First ();
            }
            Node node = lista.Head;
            Contato aux = null;
            int count = 1;
            while (node.Next.Id != lista.Head.Id)
            {
                count++;
                node = node.Next;
            }
            node = lista.Head;
            for (var i = 0; i < count; i++)
            {
                do
                {
                    if (node.Next.Contato.Email.CompareTo (node.Contato.Email) < 0)
                    {
                        aux = node.Contato;
                        node.Contato = node.Next.Contato;
                        node.Next.Contato = aux;
                    }
                    node = node.Next;
                }
                while (node.Next.Id != lista.Head.Id);
                node = lista.Head;
            }
            return lista;
        }

        public Node Navigation (string id)
        {
            var filter = Builders<LinkedList>.Filter.Exists ("item", false);
            var result = _linkedList.Find (filter).ToList ();
            if (result.Count != 0)
            {
                lista = _linkedList.Find (head => true).First ();
            }
            Node node = lista.Head;
            if (lista.Id != id)
            {
                while ((node.Next != null) && (node.Id != id))
                {
                    node = node.Next;
                }
                if (node.Next == null)
                {
                    return node = lista.Head;
                }
            }
            return node;
        }
    }
}