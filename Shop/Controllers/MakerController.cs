using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Shop.Models;

namespace Shop.Controllers
{
    public class MakerController : ApiController
    {
        private ShopContext db = new ShopContext();

        // GET api/Maker
        public IEnumerable<Maker> GetMakers()
        {
            return db.Makers.AsEnumerable();
        }

        // GET api/Maker/5
        public Maker GetMaker(int id)
        {
            Maker maker = db.Makers.Find(id);
            if (maker == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return maker;
        }

        // PUT api/Maker/5
        public HttpResponseMessage PutMaker(int id, Maker maker)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != maker.MakerID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(maker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Maker
        public HttpResponseMessage PostMaker(Maker maker)
        {
            if (ModelState.IsValid)
            {
                db.Makers.Add(maker);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, maker);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = maker.MakerID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Maker/5
        public HttpResponseMessage DeleteMaker(int id)
        {
            Maker maker = db.Makers.Find(id);
            if (maker == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Makers.Remove(maker);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, maker);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}