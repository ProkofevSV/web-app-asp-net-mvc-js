﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoJS.Models
{
    public class ToDoContext : DbContext
    {

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<DayOfWeek> DayOfWeeks { get; set; }
        public DbSet<PerformerImage> PerformerImages { get; set; }
        public DbSet<Performer> Performers { get; set; }        
       

        public ToDoContext() : base("ToDoEntity")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Performer>().HasOptional(x => x.PerformerImage).WithRequired().WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }


    }
}