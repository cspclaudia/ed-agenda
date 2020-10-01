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

        // --- não consegui salvar no banco quando a lista é circular e/ou duplamente encadeada ---

        LinkedList lista = new LinkedList ();
        public Node Add (Contato contato)
        {
            var filter = Builders<LinkedList>.Filter.Exists ("item", false);
            var result = _linkedList.Find (filter).ToList ();
            if (result.Count != 0)
            {
                lista = _linkedList.Find (head => true).First ();
            }
            Node node = new Node (contato);
            node.Next = lista.Head;
            // ------- Duplamente Encadeada -------
            // node.Before = null;
            // if (lista.Head != null)
            // {
            //     lista.Head.Before = node;
            // }
            lista.Head = node;
            // ------- Circular -------
            // Node aux = lista.Head;
            // var node = new Node (contato);
            // if (lista.Head != null)
            // {
            //     while (aux.Next != lista.Head)
            //     {
            //         aux = aux.Next;
            //     }
            // }
            // else
            // {
            //     aux = node;
            // }
            // node.Next = lista.Head;
            // lista.Head = node;
            // aux.Next = lista.Head;

            _node.InsertOne (node);
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
            Node aux = lista.Head;
            Node ant = null;
            while ((aux != null) && (aux.Id != node.Id))
            {
                ant = aux;
                aux = aux.Next;
            }
            if (ant == null)
            {
                lista.Head = aux.Next;
                _node.ReplaceOne (n => n.Next.Id == node.Id, aux);
            }
            else
            {
                ant.Next = aux.Next;
                _node.ReplaceOne (n => n.Next.Id == node.Id, ant);
            }
            _linkedList.DeleteOne (node => true);
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
            int count = 0;
            while (node != null)
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
                while (node.Next != null);
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
            int count = 0;
            while (node != null)
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
                while (node.Next != null);
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
                node = node.Next;
            }
            return node;
        }
    }
}