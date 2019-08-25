using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WelCareForYou_IT1.Models;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace WelCareForYou_IT1.Controllers
{
    public class QuestionnaireController : Controller
    {
        private BusinessModelContainer db = new BusinessModelContainer();
        // GET: Questionnaire
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Result(String salary, String numOfPeople1, String currentRent1)
        public ActionResult Result([Bind(Include = "Id,AgeGroup,Gender,NumOfRoom,Salary,SuburbSuburbName")] Client client, String rent)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }

            var NumOfRoom = client.NumOfRoom;
            var currentRent = int.Parse(rent);
            var acceptableRent = client.Salary * 0.3;

            if (currentRent > acceptableRent)
            {
                List<House> housingList = db.Houses.Where(x => x.MediumPrice <= acceptableRent)
                                                .Where(x => x.NumOfRoom >= NumOfRoom)
                                                .OrderByDescending(x => x.MediumPrice).Take(6).ToList();

                List<int> diffList = new List<int>();
                var item1diff = housingList[0].MediumPrice * 100 / currentRent - 100;
                var item2diff = housingList[1].MediumPrice * 100 / currentRent - 100;
                var item3diff = housingList[2].MediumPrice * 100 / currentRent - 100;
                var item4diff = housingList[3].MediumPrice * 100 / currentRent - 100;
                var item5diff = housingList[4].MediumPrice * 100 / currentRent - 100;
                var item6diff = housingList[5].MediumPrice * 100 / currentRent - 100;
                diffList.Add(item1diff);
                diffList.Add(item2diff);
                diffList.Add(item3diff);
                diffList.Add(item4diff);
                diffList.Add(item5diff);
                diffList.Add(item6diff);
                ViewData["diff"] = diffList;

                //return Redirect("~/Questionnaire/Index");

                return View(housingList);
            }
            else
            {
                //chnage to another website           
                return Redirect("~/Home/Index");
            }
        }

        protected override void HandleUnknownAction(string actionName)
        {
            Response.Redirect("~/Home/Index");
            base.HandleUnknownAction(actionName);
        }
    }


}