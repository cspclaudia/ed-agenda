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
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController (BookService bookService)
        {
            _bookService = bookService;
        }

        // [AllowAnonymous]
        public ActionResult<IList<Book>> Index () => View (_bookService.Get ());

        [HttpGet]
        public ActionResult<List<Book>> Get () =>
            _bookService.Get ();

        [HttpGet ("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Book> Get (string id)
        {
            var book = _bookService.Get (id);

            if (book == null)
            {
                return NotFound ();
            }

            return book;
        }

        [HttpGet]
        public ActionResult Create () => View ();

        [HttpPost]
        public ActionResult<Book> Create (Book book)
        {
            _bookService.Create (book);

            return RedirectToAction("Index");
        }

        // [HttpPut]
        public ActionResult Update (string id) => View (_bookService.Get (id));

        [HttpPost]
        public IActionResult Update (string id, Book bookIn)
        {
            var book = _bookService.Get (id);

            if (book == null)
            {
                return NotFound ();
            }

            _bookService.Update (id, bookIn);

            return RedirectToAction("Index");
        }

        // [HttpDelete]
        public ActionResult Remove (string id) => View (_bookService.Get (id));

        [HttpPost]
        public IActionResult Remove (string id, Book bookIn)
        {
            var book = _bookService.Get (id);

            if (book == null)
            {
                return NotFound ();
            }

            _bookService.Remove (book.Id);

            return RedirectToAction("Index");
        }
    }
}