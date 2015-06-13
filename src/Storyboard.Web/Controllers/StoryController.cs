using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using Storyboard.Domain.Models;
using Storyboard.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Storyboard.Web.Controllers
{
    [Authorize]
    public class StoryController : Controller
    {
        private readonly IStoryRepository repository;
        private readonly IStoryReadService storyReadService;
        
        public StoryController(IStoryReadService service, IStoryRepository repository)
        {
            this.repository = repository;
            this.storyReadService = service;
        }
        #region pages
        // GET: Story
        public async Task<ActionResult> Index()
        {
            var stories = await  repository.GetAsync();
            return View(stories);
        }

        // GET: Story/Details/5
        public ActionResult Details(int id)
        {
            return View(storyReadService.GetStoryOverview(id));
        }

        // GET: Story/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Story/Create
        [HttpPost]
        public async Task<ActionResult> Create(AddUpdateStoryCommand command)
        {
            if (!ModelState.IsValid)
                return View();
            
            await repository.Add(command);
            return RedirectToAction(nameof(Index));
        }

        // GET: Story/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var story = await repository.GetAsync(id);
            if(story == null)
                return RedirectToAction(nameof(Index));
            return View(story.ToAddUpdateCommand());
        }

        // POST: Story/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(AddUpdateStoryCommand command)
        {
            if (!ModelState.IsValid)
                return View();

            await repository.Update(command);
            return RedirectToAction(nameof(Index));
        }

        // GET: Story/Delete/5
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
