﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.Data;
using Storyboard.Domain.Data;
using Storyboard.Domain.Core;
using Storyboard.Data.Core;
using System.Collections.Generic;
using System.Linq;
using Storyboard.Domain.Core.Commands;

namespace Storyboard.Data.Tests
{
    [TestClass]
    public class StoryRepositoryTests
    {
        private IStoryRepository target;

        [TestInitialize]
        public void Init()
        {
            var adaptor = new InMemoryAdapter();
            adaptor.SetAutoIncrementColumn("Story.Story", "Id");
            adaptor.SetKeyColumn("Story.Story", "Id");

            Database.UseMockAdapter(adaptor);
            target = new StoryRepository();
        }
        
        [TestCleanup]
        public void CleanUp()
        {
            Database.StopUsingMockAdapter();
        }


        [TestMethod]
        public void CanGetAllStories()
        {
            LoadStories();
            var result = target.Get();
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void CanGetStoryById()
        {
            LoadStories();
            var result = target.Get(1);
            var expected = GetAllStories().Single(s => s.Id == 1);
            Assert.AreEqual(expected.Synopsis, result.Synopsis);
            Assert.AreEqual(expected.Title, result.Title);

        }

        [TestMethod]
        public void CanCreateStory()
        {
            var story = GetAllStories().Single(s => s.Id == 1);
            var command = new AddUpdateStoryCommand
            {
                Title = story.Title,
                Synopsis = story.Synopsis
            };

            target.AddOrUpdate(command);
            var result = target.Get(command.Id);
            Assert.AreEqual(story.Synopsis, result.Synopsis);
            Assert.AreEqual(story.Title, result.Title);

        }

        [TestMethod]
        public void CanUpdateStory()
        {
            LoadStories();
            var expectedTitle = "NewTitle";
            var story = GetAllStories().Single(s => s.Id == 1);
            var command = new AddUpdateStoryCommand
            {
                Id = story.Id,
                Title = expectedTitle,
                Synopsis = story.Synopsis
            };

            target.AddOrUpdate(command);
            var result = target.Get(story.Id);
            Assert.AreEqual(story.Synopsis, result.Synopsis);
            Assert.AreEqual(expectedTitle, result.Title);

        }

      
        [TestMethod]
        public void CanDeleteStory()
        {
            LoadStories();

            target.Delete(1);
            var result = target.Get().Count();
            Assert.AreEqual(2, result);

        }

        private void LoadStories()
        {
            var db = Database.Open();
            db.Story.Story.Insert(GetAllStories());
        }

        private List<Story> GetAllStories()
        {
            return new List<Story>
            {
                new Story { Id = 1, Synopsis = "Synopsis1", Title = "Title1"},
                new Story { Id = 2, Synopsis = "Synopsis2", Title = "Title2"},
                new Story { Id = 3, Synopsis = "Synopsis3", Title = "Title2"}
            };
        }
    }
}