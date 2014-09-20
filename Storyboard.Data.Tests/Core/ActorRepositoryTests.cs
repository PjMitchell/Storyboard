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
    public class ActorRepositoryTests
    {
        private IActorRepository target;

        [TestInitialize]
        public void Init()
        {
            var adaptor = new InMemoryAdapter();
            adaptor.SetAutoIncrementColumn("Story.Actor", "Id");
            adaptor.SetKeyColumn("Story.Actor", "Id");

            Database.UseMockAdapter(adaptor);
            target = new ActorRepository();
        }
        
        [TestCleanup]
        public void CleanUp()
        {
            Database.StopUsingMockAdapter();
        }


        [TestMethod]
        public void CanGetAllActors()
        {
            LoadActors();
            var result = target.Get();
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void CanGetActorById()
        {
            LoadActors();
            var result = target.Get(1);
            var expected = GetAllActors().Single(s => s.Id == 1);
            Assert.AreEqual(expected.Description, result.Description);
            Assert.AreEqual(expected.Name, result.Name);

        }

        [TestMethod]
        public void CanCreateActor()
        {
            var actor = GetAllActors().Single(s => s.Id == 1);
            var command = new AddUpdateActorCommand
            {
                Name = actor.Name,
                Description = actor.Description
            };

            target.AddOrUpdate(command);
            var result = target.Get(command.Id);
            Assert.AreEqual(actor.Description, result.Description);
            Assert.AreEqual(actor.Name, result.Name);

        }

        [TestMethod]
        public void CanUpdateActor()
        {
            LoadActors();
            var expectedName = "NewName";
            var actor = GetAllActors().Single(s => s.Id == 1);
            var command = new AddUpdateActorCommand
            {
                Id = actor.Id,
                Name = expectedName,
                Description = actor.Description
            };

            target.AddOrUpdate(command);
            var result = target.Get(actor.Id);
            Assert.AreEqual(actor.Description, result.Description);
            Assert.AreEqual(expectedName, result.Name);

        }

      
        [TestMethod]
        public void CanDeleteActor()
        {
            LoadActors();

            target.Delete(1);
            var result = target.Get().Count();
            Assert.AreEqual(2, result);

        }

        private void LoadActors()
        {
            var db = Database.Open();
            db.Story.Actor.Insert(GetAllActors());
        }

        private List<Actor> GetAllActors()
        {
            return new List<Actor>
            {
                new Actor { Id = 1, Name = "Name1", Description = "Description1"},
                new Actor { Id = 2, Name = "Name2", Description = "Description2"},
                new Actor { Id = 3, Name = "Name3", Description = "Description2"}
            };
        }
    }
}