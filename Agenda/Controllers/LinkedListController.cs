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

        // [HttpGet ("{id:length(24)}", Name = "GetLinkedList")]
        // public ActionResult<LinkedList> Get (string id)
        // {
        //     var linkedList = _linkedListService.Get (id);

        //     if (linkedList == null)
        //     {
        //         return NotFound ();
        //     }

        //     return linkedList;
        // }

        [HttpGet]
        public ActionResult Create () => View ();

        [HttpPost]
        public ActionResult<LinkedList> Create (Contato contato)
        {
            _linkedListService.Add (contato);
            return RedirectToAction("Index");
        }

        // [HttpPut]
        // public ActionResult Update (string id) => View (_linkedListService.Get (id));

        // [HttpPost]
        // public IActionResult Update (string id, LinkedList linkedListIn)
        // {
        //     var linkedList = _linkedListService.Get (id);

        //     if (linkedList == null)
        //     {
        //         return NotFound ();
        //     }

        //     _linkedListService.Update (id, linkedListIn);

        //     return RedirectToAction("Index");
        // }

        // [HttpDelete]
        // public ActionResult Remove (string id) => View (_linkedListService.Get (id));

        // [HttpPost]
        // public IActionResult Remove (string id, LinkedList linkedListIn)
        // {
        //     var linkedList = _linkedListService.Get (id);

        //     if (linkedList == null)
        //     {
        //         return NotFound ();
        //     }

        //     _linkedListService.Remove (linkedList.Id);

        //     return RedirectToAction("Index");
        // }
    }
}