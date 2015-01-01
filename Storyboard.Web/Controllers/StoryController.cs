using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using Storyboard.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storyboard.Web.Controllers
{
    public class StoryController : Controller
    {
        private readonly IStoryRepository repository;
        private readonly IStoryReadService service;
        
        public StoryController(IStoryReadService service, IStoryRepository repository)
        {
            this.repository = repository;
            this.service = service;
        }
        
        // GET: Story
        public ActionResult Index()
        {
            var stories = repository.GetAsync();
            stories.Wait();
            return View(stories.Result);
        }

        // GET: Story/Details/5
        public ActionResult Details(int id)
        {
            return View(service.GetStoryOverview(id));
        }

        // GET: Story/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Story/Create
        [HttpPost]
        public ActionResult Create(AddUpdateStoryCommand command)
        {
            if (!ModelState.IsValid)
                return View();
            
            repository.AddOrUpdate(command);
            return RedirectToAction("Index");
        }

        // GET: Story/Edit/5
        public ActionResult Edit(int id)
        {
            var story = repository.Get(id);
            if(story == null)
                return RedirectToAction("Index");
            return View(story.ToAddUpdateCommand());
        }

        // POST: Story/Edit/5
        [HttpPost]
        public ActionResult Edit(AddUpdateStoryCommand command)
        {
            if (!ModelState.IsValid)
                return View();

            repository.AddOrUpdate(command);
            return RedirectToAction("Index");
        }

        // GET: Story/Delete/5
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Story/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
