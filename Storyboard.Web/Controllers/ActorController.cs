using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Storyboard.Web.Controllers
{
    public class ActorController : AsyncController
    {
        private readonly IActorRepository repository;
        
        public ActorController(IActorRepository repository)
        {
            this.repository = repository;
        }

        // GET: Actor
        public async Task<ActionResult> Index()
        {
            return View(await repository.GetAsync());
        }

        // GET: Actor/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await repository.GetAsync(id));
        }

        // GET: Actor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Story/Create
        [HttpPost]
        public ActionResult Create(AddUpdateActorCommand command)
        {
            if (!ModelState.IsValid)
                return View();

            repository.AddOrUpdate(command);
            return RedirectToAction("Index");
        }

        // GET: Actor/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var actor = await repository.GetAsync(id);
            if (actor == null)
                return RedirectToAction("Index");
            return View(actor.ToAddUpdateCommand());
        }

        // POST: Actor/Edit/5
        [HttpPost]
        public ActionResult Edit(AddUpdateActorCommand command)
        {
            if (!ModelState.IsValid)
                return View();

            repository.AddOrUpdate(command);
            return RedirectToAction("Index");
        }

        // GET: Actor/Delete/5
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}