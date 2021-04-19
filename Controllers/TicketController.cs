using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoProject.Models;

namespace ToDoProject.Controllers
{
    public class TicketController : Controller
    {
        private ITicketUnit data { get; set; }
        private IHttpContextAccessor http { get; set; }

        //private Repository<Ticket> tickets { get; set; }
        //private Repository<Status> statuses { get; set; }

        public TicketController(ITicketUnit unit, IHttpContextAccessor ctx)
        {
            data = unit;
            http = ctx;
        }

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var t = this.GetTickets(id);
            return View("Add", t);
        }

        [HttpPost]
        public IActionResult Add(Ticket t)
        {
            if (ModelState.IsValid)
            {
                if (t.Id == 0)
                    data.Tickets.Insert(t);
                else
                    data.Tickets.Update(t);
                data.Tickets.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string operation = (t.Id == 0) ? "Add" : "Edit";
                this.LoadViewBag(operation);
                return View();
            }
        }

        [HttpGet]
        public RedirectToActionResult Delete(Ticket t)
        {
            data.Tickets.Delete(t);
            data.Tickets.Save();
            return RedirectToAction("Index", "Home");
        }

        private Ticket GetTickets(int id)
        {
            var classOptions = new QueryOptions<Ticket>
            {
                Includes = "Tickets",
                Where = t => t.Id == id
            };
            var list = data.Tickets.List(classOptions);

            // return first Class or blank Class if null
            return list.FirstOrDefault();
        }
        private void LoadViewBag(string operation)
        {
            ViewBag.Ticketings = data.Tickets.List(new QueryOptions<Ticket>
            {
                OrderBy = t => t.Id
            });
            ViewBag.Statuses = data.Statuses.List(new QueryOptions<Status>
            {
                OrderBy = t => t.Name
            });
            ViewBag.Operation = operation;
        }
    }
}
