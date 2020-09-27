using System;
using System.Collections.Generic;
using System.Linq;
using Agenda.Models;
using MongoDB.Driver;

namespace Agenda.Services
{
    public class LinkedListService
    {
        private readonly IMongoCollection<Node> _linkedList;

        public LinkedListService (IDatabaseSettings settings)
        {
            var client = new MongoClient (settings.ConnectionString);
            var database = client.GetDatabase (settings.DatabaseName);

            _linkedList = database.GetCollection<Node> (settings.LinkedListCollectionName);
        }

        private LinkedList lista = new LinkedList ();
        public Node Add (Contato contato)
        {
            var newNode = new Node (contato);
            newNode.Next = lista.Head;
            lista.Head = newNode;

            try
            {
                _linkedList.InsertOne (newNode);
            }
            catch (Exception e)
            {
                Console.WriteLine (e);
            }
            return newNode;
        }

        public Node Find (string id)
        {
            Node aux = lista.Head;
            while ((aux != null) && (aux.Id != id))
            {
                aux = aux.Next;
            }
            return aux;
        }

        public List<Node> Get () =>
            _linkedList.Find (node => true).ToList ();

        public Node Get (string id) =>
            _linkedList.Find<Node> (node => node.Id == id).FirstOrDefault ();

        public void Update (string id, Node node) =>
            _linkedList.ReplaceOne (node => node.Id == id, node);

        public bool IsEmpty ()
        {
            return (lista.Head == null);
        }

        public void Delete (Node node)
        {
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
                _linkedList.ReplaceOne (n => n.Next.Id == node.Id, aux);
            }
            else
            {
                ant.Next = aux.Next;
                _linkedList.ReplaceOne (n => n.Next.Id == node.Id, ant);
            }
            _linkedList.DeleteOne (n => n.Id == node.Id);
        }

        public void Remove (string id) =>
            _linkedList.DeleteOne (node => node.Id == id);
    }
}