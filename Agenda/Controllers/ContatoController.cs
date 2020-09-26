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
    public class ContatoController : Controller
    {
        private readonly ContatoService _contatoService;
        private readonly LinkedListService _linkedListService;

        public ContatoController (ContatoService contatoService, LinkedListService linkedListService)
        {
            _contatoService = contatoService;
            _linkedListService = linkedListService;
        }

        public ActionResult<IList<LinkedList>> Index () => View (_linkedListService.Get ());

        [HttpGet]
        public ActionResult<List<Contato>> Get () =>
            _contatoService.Get ();

        [HttpGet ("{id:length(24)}", Name = "GetContato")]
        public ActionResult<Contato> Get (string id)
        {
            var contato = _contatoService.Get (id);

            if (contato == null)
            {
                return NotFound ();
            }

            return contato;
        }

        [HttpGet]
        public ActionResult Create () => View ();

        [HttpPost]
        public ActionResult<Contato> Create (Contato contato)
        {
            // _contatoService.Create (contato);
            _linkedListService.Add (contato);
            return RedirectToAction("Index", "LinkedList");
        }

        // [HttpPut]
        public ActionResult Update (string id) => View (_contatoService.Get (id));

        [HttpPost]
        public IActionResult Update (string id, Contato contatoIn)
        {
            var contato = _contatoService.Get (id);

            if (contato == null)
            {
                return NotFound ();
            }

            _contatoService.Update (id, contatoIn);

            return RedirectToAction("Index");
        }

        // [HttpDelete]
        public ActionResult Remove (string id) => View (_contatoService.Get (id));

        [HttpPost]
        public IActionResult Remove (string id, Contato contatoIn)
        {
            var contato = _contatoService.Get (id);

            if (contato == null)
            {
                return NotFound ();
            }

            _contatoService.Remove (contato.Id);

            return RedirectToAction("Index");
        }
    }
}