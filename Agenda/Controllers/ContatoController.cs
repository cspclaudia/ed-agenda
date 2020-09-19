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
    [Route ("api/[controller]")]
    [ApiController]
    public class ContatoController : Controller
    {
        private readonly ContatoService _contatoService;

        public ContatoController (ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [AllowAnonymous]
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
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult<Contato> Create (Contato contato)
        {
            _contatoService.Create (contato);

            return CreatedAtRoute ("GetContato", new { id = contato.Id.ToString () }, contato);
        }

        [HttpGet]
        public ActionResult<Contato> Update(string id) => View(_contatoService.Get(id));

        [HttpPut ("{id:length(24)}")]
        public IActionResult Update (string id, Contato contatoIn)
        {
            var contato = _contatoService.Get (id);

            if (contato == null)
            {
                return NotFound ();
            }

            _contatoService.Update (id, contatoIn);

            return NoContent ();
        }

        [HttpDelete ("{id:length(24)}")]
        public IActionResult Remove (string id)
        {
            var contato = _contatoService.Get (id);

            if (contato == null)
            {
                return NotFound ();
            }

            _contatoService.Remove (contato.Id);

            return NoContent ();
        }
    }
}