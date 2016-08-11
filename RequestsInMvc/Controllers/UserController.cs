using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RequestsInMvc.Models;

namespace RequestsInMvc.Controllers
{
    public class UserController : Controller
    {

        #region Views
        // GET: /User  
        public ActionResult Index()
        {
            return View("All");
        }

        // GET: /User/All
        public ActionResult All()
        {
            return View();
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: /User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        } 
        #endregion

        #region Why use HttpGet/Post/Put/Delete
        public JsonResult UrlResponse()     //accessable using Url
        {
            return Json(new { Name = "UrlResponse", Response = "Response from Get", Date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TypedResponse()    //error if try to access using Url
        {
            return Json(new { Name = "TypedResponse", Response = "Response from Get", Date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        //or [AcceptVerbs("GET","POST")]
        public JsonResult MultipleTypedResponse()
        {
            return Json(new { Name = "MultipleTypedResponse", Response = "Response from Get", Date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Typed Jsons
        // GET: /User/Get/5
        [HttpGet]
        public JsonResult Get(int id)
        {
            return Json("Response from Get", JsonRequestBehavior.AllowGet);
        }

        // GET: /User/Find/1/30 or
        // GET: /User/Find
        [HttpGet]
        public JsonResult Find(int pageNo, int pageSize, User user)
        {
            var value = Request.QueryString["user"];
            /*here we will not get user, beacuse mvc doesn't work like that*/
            /*solution 1: rather than an object, use all properties of user object as parms
              Find(int pageNo, int pageSize, long userId, string userName...)
            */
            /*solution 2: use httppost, which is the most proper for the job*/
            return Json("Response from Find", JsonRequestBehavior.AllowGet);
        }

        // GET: /User/Contains
        [HttpGet]   //use or not works same
        public JsonResult Contains(string name, string email)
        {
            return Json("Response from Contains", JsonRequestBehavior.AllowGet);
        }


        // POST: /User/Create
        [HttpPost]
        public JsonResult Create(User user)
        {
            return Json("Response from Create");
        }

        // PUT: /User/Edit
        [HttpPut]
        public JsonResult Edit(int id, User user)
        {
            return Json("Response from Edit");
        }

        // DELETE: /User/Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            return Json("Response from Delete");
        } 
        #endregion
    }
}
