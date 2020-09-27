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
        public ActionResult<Node> Index () => View (_linkedListService.Get ());

        [HttpGet]
        public ActionResult<List<Node>> Get () =>
            _linkedListService.Get ();

        [HttpGet]
        public ActionResult<Node> Get (string id)
        {
            var node = _linkedListService.Find (id);

            if (node == null)
            {
                return NotFound ();
            }

            return node;
        }

        [HttpGet]
        public ActionResult Create () => View ();

        [HttpPost]
        public ActionResult<Node> Create (Contato contato)
        {
            _linkedListService.Add (contato);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update (string id) => View (_linkedListService.Get (id));

        [HttpPost]
        public IActionResult Update (string id, Node node)
        {
            var linkedList = _linkedListService.Get (id);

            if (linkedList == null)
            {
                return NotFound ();
            }

            _linkedListService.Update (id, node);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remove (string id) => View (_linkedListService.Get (id));

        [HttpPost]
        public IActionResult Remove (string id, Contato contato)
        {
            var node = _linkedListService.Get (id);

            if (node == null)
            {
                return NotFound ();
            }

            _linkedListService.Remove (node.Id);

            return RedirectToAction("Index");
        }
    }
}