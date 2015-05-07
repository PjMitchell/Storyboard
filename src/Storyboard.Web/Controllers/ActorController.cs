using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using System.Threading.Tasks;

namespace Storyboard.Web.Controllers
{
    [Authorize]
    public class ActorController : Controller
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
        public async Task<ActionResult> Create(AddUpdateActorCommand command)
        {
            if (!ModelState.IsValid)
                return View();

            await repository.Add(command);
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
        public async Task<ActionResult> Edit(AddUpdateActorCommand command)
        {
            if (!ModelState.IsValid)
                return View();

            await repository.Update(command);
            return RedirectToAction("Index");
        }

        // GET: Actor/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}