using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Agenda.Models;
using Agenda.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    public class LinkedListController : Controller
    {
        private readonly LinkedListService _linkedListService;

        public LinkedListController (LinkedListService linkedListService)
        {
            _linkedListService = linkedListService;
        }

        // [AllowAnonymous]
        public ActionResult<LinkedList> Index () => View (_linkedListService.SortName ());

        // [HttpGet]
        // public ActionResult<List<Node>> Get () =>
        //     _linkedListService.Get ();

        // [HttpGet]
        // public ActionResult<Node> Get (string id)
        // {
        //     var node = _linkedListService.Find (id);

        //     if (node == null)
        //     {
        //         return NotFound ();
        //     }

        //     return node;
        // }

        [HttpGet]
        public ActionResult Create () => View ();

        [HttpPost]
        public ActionResult<Node> Create (Contato contato)
        {
            _linkedListService.Add (contato);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update (string id) => View (_linkedListService.Find (id));

        [HttpPost]
        public IActionResult Edit (string id, Contato contato)
        {
            var linkedList = _linkedListService.Find (id);

            if (linkedList == null)
            {
                return NotFound ();
            }

            _linkedListService.Edit (id, contato);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remove (string id) => View (_linkedListService.Find (id));

        [HttpPost]
        public IActionResult Delete (string id, Node node)
        {
            var nodeIn = _linkedListService.Find (id);

            if (nodeIn == null)
            {
                return NotFound ();
            }

            _linkedListService.Delete (node);

            return RedirectToAction("Index");
        }
    }
}