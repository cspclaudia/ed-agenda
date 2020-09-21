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
        private readonly BookService _bookService;

        public ContatoController (ContatoService contatoService, BookService bookService)
        {
            _contatoService = contatoService;
            _bookService = bookService;
        }

        public ActionResult<IList<Contato>> Index () => View (_contatoService.Get ());

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
        public ActionResult<Contato> Create (Contato contato, string id = "5f6935b15818d28c65110415")
        {
            _contatoService.Create (contato);
            _bookService.AddContato (contato, id);
            return RedirectToAction("Index");
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