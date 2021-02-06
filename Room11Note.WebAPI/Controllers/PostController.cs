using Microsoft.AspNet.Identity;
using Room11Note.Models;
using Room11Note.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Room11Note.WebAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        public IHttpActionResult Get()
        {
            PostService noteService = CreatePostService();
            var notes = noteService.GetPost();
            return Ok(notes);
        }

        public IHttpActionResult Get(int id)
        {
            PostService noteService = CreatePostService();
            var note = noteService.GetPostById(id);
            return Ok(note);
        }

        public IHttpActionResult Post(PostCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(note))
                return InternalServerError();

            return Ok();
        }
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new PostService(userId);
            return noteService;
        }

        public IHttpActionResult Put(PostEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.UpdatePost(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();

            if (!service.DeletePost(id))
                return InternalServerError();

            return Ok();
        }
    }
}
