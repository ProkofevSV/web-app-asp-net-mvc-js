﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ToDoJS.Models;
using DayOfWeek = ToDoJS.Models.DayOfWeek;

namespace ToDoJS.Controllers
{
    public class DayOfWeeksController: Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new ToDoContext();
            var dayOfWeeks = db.DayOfWeeks.ToList();
            return View(dayOfWeeks);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var dayOfWeek = new DayOfWeek();

            return View(dayOfWeek);
        }

        [HttpPost]
        public ActionResult Create(DayOfWeek model)
        {
            var db = new ToDoContext();

            if (!ModelState.IsValid)
            {
                var dayOfWeeks = db.DayOfWeeks.ToList();
                ViewBag.Create = model;
                return View("Index", dayOfWeeks);
            }


            db.DayOfWeeks.Add(model);
            db.SaveChanges();


            return RedirectPermanent("/DayOfWeeks/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new ToDoContext();
            var dayOfWeek = db.DayOfWeeks.FirstOrDefault(x => x.Id == id);
            if (dayOfWeek == null)
                return RedirectPermanent("/DayOfWeeks/Index");

            db.DayOfWeeks.Remove(dayOfWeek);
            db.SaveChanges();

            return RedirectPermanent("/DayOfWeeks/Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ToDoContext();
            var dayOfWeek = db.DayOfWeeks.FirstOrDefault(x => x.Id == id);
            if (dayOfWeek == null)
                return RedirectPermanent("/DayOfWeeks/Index");

            return View(dayOfWeek);
        }

        [HttpPost]
        public ActionResult Edit(DayOfWeek model)
        {

            var db = new ToDoContext();
            var dayOfWeek = db.DayOfWeeks.FirstOrDefault(x => x.Id == model.Id);
            if (dayOfWeek == null)
            {
                ModelState.AddModelError("Id", "Группа не найдена");
            }
            if (!ModelState.IsValid)
            {
                var dayOfWeeks = db.DayOfWeeks.ToList();
                ViewBag.Create = model;
                return View("Index", dayOfWeeks);
            }

            MappingDayOfWeek(model, dayOfWeek);


            db.Entry(dayOfWeek).State = EntityState.Modified;
            db.SaveChanges();


            return RedirectPermanent("/DayOfWeeks/Index");
        }

        private void MappingDayOfWeek(DayOfWeek sourse, DayOfWeek destination)
        {
            destination.DayOfWeekName = sourse.DayOfWeekName;
        }
    }
}