using System;
using System.Collections.Generic;
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
            Node node = new Node (contato);
            node.Next = lista.Head;
            lista.Head = node;

            _node.InsertOne (node);
            _linkedList.DeleteOne (node => true);
            _linkedList.InsertOne (lista);

            return node;
        }

        // public List<Node> Get () =>
        //     _node.Find (node => true).ToList ();

        public LinkedList Find ()
        {
            LinkedList lista = _linkedList.Find (node => true).FirstOrDefault ();
            if (lista == null)
            {
                lista = new LinkedList ();
            }
            return lista;
        }

        // public Node Get (string id) =>
        //     _node.Find<Node> (node => node.Id == id).FirstOrDefault ();

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

        // public void Update (string id, Node node) =>
        //     _node.ReplaceOne (node => node.Id == id, node);

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

        // public void Remove (string id) =>
        //     _node.DeleteOne (node => node.Id == id);

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
            LinkedList lista = _linkedList.Find (head => true).FirstOrDefault ();
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
    }
}