using ElevenNote.Service;
using ElvenNote.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{

    [Authorize]//Accessible only for logged in users
    public class NoteController : Controller
    {
        // GET: Note

        //GUID stands for Global Unique Identifier. A GUID is a 128-bit integer (16 bytes) that you can use across all computers and networks wherever a unique identifier is required.
        public ActionResult Index()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());//User.Identity.GetUserId() return string
            //new up an instance of NoteService and pass in the userid
            var service = new NoteService(userId);
            //use service to call our method from note Service
            var model = service.GetNotes();

            return View(model);
        }

        public ActionResult Create( )
        {
            return View();
        }
        //With Breakpoints and Quickwatch, You can explore the data coming from the view
        [HttpPost]
        [ValidateAntiForgeryToken]//to prevent forgery of a request
        public ActionResult Create( NoteCreate note)
        {
            if (!ModelState.IsValid)// If modelSate is not valid
            {
                return View(note);
            }

            //if model state is valid
            var service = CreateNoteService();//grabs the current ,
            if (service.CrerateNote(note))
            {
                //view bag is a dynamic object so you can define any proprety in this case is assigned a string
                //Add success message, but still need to add few codes in the view
                TempData["SaveResult"] = "Your note was created";
                return RedirectToAction("Index");// returns the user back to the index view
            }
            //Add error message
            ModelState.AddModelError("", "Not could not be created");
            return View(note);
        }


        public ActionResult Details(int id)
        {
            var srv = CreateNoteService();
            var model = srv.GetNoteById(id);
            return View(model);
        }

        public ActionResult Edit(int id)//????
        {
            var srv = CreateNoteService();
            var details = srv.GetNoteById(id);

            var model = new NoteEdit
            {
                NoteId = details.NoteId,
                Title = details.Title,
                Content = details.Content
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, NoteEdit model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.NoteId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
            }

            var service = CreateNoteService();
            if (service.UpdateNote(model))
            {
                TempData["SaveResult"] = "Your note was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", " Your not could not be updated");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var srv = CreateNoteService();
            var model = srv.GetNoteById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNote(int id)
        {
            var model = CreateNoteService();
            model.DeleteNote(id);

            TempData["SaveResult"] = "Your note was created";
            return RedirectToAction("Index");

        }

        //it is usable in all  methods
        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new NoteService(userId);
            return service;
        }
    }
}