﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Data.EF.DbObject
{
    [Table("Story", Schema = "Story")]
    public class StoryTableRow
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
    }
    
}
