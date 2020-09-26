using System;
using System.Collections.Generic;
using System.Linq;
using Agenda.Models;
using MongoDB.Driver;

namespace Agenda.Services
{
    public class LinkedListService
    {
        private readonly IMongoCollection<LinkedList> _linkedList;

        public LinkedListService (IDatabaseSettings settings)
        {
            var client = new MongoClient (settings.ConnectionString);
            var database = client.GetDatabase (settings.DatabaseName);

            _linkedList = database.GetCollection<LinkedList> (settings.LinkedListCollectionName);
        }

        // public LinkedListService ()
        // {
        //     lista.Head = null;
        // }

        public void Add (Contato contato)
        {
            var lista = new LinkedList ();
            var newNode = new Node (contato);
            newNode.Next = lista.Head;
            lista.Head = newNode;

            _linkedList.InsertOne (lista);
        }

        public List<LinkedList> Get () =>
            _linkedList.Find (linkedList => true).ToList ();

        // public LinkedList Get (string id) =>
        //     _linkedList.Find<LinkedList> (linkedList => linkedList.Id == id).FirstOrDefault ();

        // public LinkedList Create (LinkedList linkedList)
        // {
        //     try
        //     {
        //         _linkedList.InsertOne (linkedList);
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine (e);
        //     }
        //     return linkedList;
        // }

        // public void Update (string id, LinkedList linkedListIn) =>
        //     _linkedList.ReplaceOne (linkedList => linkedList.Id == id, linkedListIn);

        // public void Remove (LinkedList linkedListIn) =>
        //     _linkedList.DeleteOne (linkedList => linkedList.Id == linkedListIn.Id);

        // public void Remove (string id) =>
        //     _linkedList.DeleteOne (linkedList => linkedList.Id == id);
    }
}