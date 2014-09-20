﻿using Simple.Data;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Data.Core
{
    public class ActorRepository : IActorRepository
    {
        public IEnumerable<Actor> Get()
        {
            var db = Database.Open();
            IEnumerable<Actor> actor = db.Story.Actor.All();
            return actor;
        }

        public Actor Get(int id)
        {
            var db = Database.Open();
            Actor actor = db.Story.Actor.FindAllById(id).SingleOrDefault();
            return actor;
        }

        public void AddOrUpdate(AddUpdateActorCommand command)
        {
            var db = Database.Open();
            if (command.Id == 0)
            {
                AddUpdateActorCommand result = db.Story.Actor.Insert(command);
                command.Id = result.Id;
            }
            else
            {
                db.Story.Actor.Update(command);
            }
        }

        public void Delete(int id)
        {
            var db = Database.Open();
            db.Story.Actor.DeleteById(id);
        }
    }
}