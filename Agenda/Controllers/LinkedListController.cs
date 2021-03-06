using Agenda.Models;
using Agenda.Services;
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

        public ActionResult<LinkedList> Index () => View (_linkedListService.Find ());

        public ActionResult<LinkedList> SortName () => View (_linkedListService.SortName ());

        public ActionResult<LinkedList> SortEmail () => View (_linkedListService.SortEmail ());

        public ActionResult<Node> Navigation (string id) => View (_linkedListService.Navigation (id));

        [HttpGet]
        public ActionResult Create () => View ();

        [HttpPost]
        public ActionResult<Node> Create (Contato contato)
        {
            _linkedListService.Add (contato);
            return RedirectToAction ("Index");
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

            return RedirectToAction ("Index");
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

            return RedirectToAction ("Index");
        }
    }
}