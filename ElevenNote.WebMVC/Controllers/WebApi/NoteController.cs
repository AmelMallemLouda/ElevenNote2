using ElevenNote.Service;
using ElvenNote.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebMVC.Controllers.WebApi
{
    public class NoteController : ApiController
    {
        [Authorize]

        [RoutePrefix("api/Note")]

        public class Notecontroller : ApiController
        {
            private bool SetStarState(int noteId, bool newState)
            {
                //Create the service
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new NoteService(userId);

                //Get the note
                var detail = service.GetNoteById(noteId);

                //Create The NoteEdit model intance with the new start state

                var updateNote =
                    new NoteEdit
                    {
                        NoteId = detail.NoteId,
                        Title = detail.Title,
                        Content = detail.Content,
                        IsStarred = newState
                    };

                //Return a value indication whether the update succeeded
                return service.UpdateNote(updateNote);
            }

            [Route("{id}/Star")]
            [HttpPut]

            public bool ToggleStarOn(int id) => SetStarState(id, true);

            [Route("{id}/Star")]

            [HttpDelete]
            public bool ToggleStarOff(int id) => SetStarState(id, false);
        }
    }
}
