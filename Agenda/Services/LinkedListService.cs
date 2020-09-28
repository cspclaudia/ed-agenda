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
            Node newNode = new Node (contato);
            newNode.Next = lista.Head;
            lista.Head = newNode;

            try
            {
                _node.InsertOne (newNode);
                _linkedList.DeleteOne (node => true);
                _linkedList.InsertOne (lista);
            }
            catch (Exception e)
            {
                Console.WriteLine (e);
            }
            return newNode;
        }

        public List<Node> Get () =>
            _node.Find (node => true).ToList ();

        // public LinkedList Find ()
        // {
        //     LinkedList nodes = new LinkedList();
        //     var nodes = _node.Find (node => true).ToList ();
        //     while (lista != null)
        //     {
        //          = node.Next;
        //     }
        //     return nodes;
        // }

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
            if (this.IsEmpty ())
            {
                return;
            }
            Node node = Find (id);
            node.Contato = contato;
            _node.ReplaceOne (node => node.Id == id, node);
        }

        // public void Remove (string id) =>
        //     _node.DeleteOne (node => node.Id == id);

        public void Delete (Node node)
        {
            LinkedList lista = _linkedList.Find (head => true).First ();
            if (this.IsEmpty ())
            {
                return;
            }
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

        public bool IsEmpty ()
        {
            return (lista.Head == null);
        }
    }
}