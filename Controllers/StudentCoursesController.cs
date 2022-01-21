﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EfExample2.Models;

namespace EfExample2.Controllers
{
    public class StudentCoursesController : Controller
    {
        private Model1Context db = new Model1Context();

        // GET: StudentCourses
        public ActionResult Index()
        {
            var studentCourses = db.StudentCourses.Include(s => s.Course).Include(s => s.Course1).Include(s => s.Student).Include(s => s.Student1);
            return View(studentCourses.ToList());
        }

        // GET: StudentCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // GET: StudentCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name");
            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,CourseId")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.StudentCourses.Add(studentCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", studentCourse.CourseId);
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", studentCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentCourse.StudentId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentCourse.StudentId);
            return View(studentCourse);
        }

        // GET: StudentCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", studentCourse.CourseId);
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", studentCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentCourse.StudentId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentCourse.StudentId);
            return View(studentCourse);
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,CourseId")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", studentCourse.CourseId);
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", studentCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentCourse.StudentId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentCourse.StudentId);
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            db.StudentCourses.Remove(studentCourse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
