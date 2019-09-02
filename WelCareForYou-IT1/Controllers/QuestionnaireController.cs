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
            List<SelectListItem> ageGroupList = new List<SelectListItem>();
            ageGroupList.AddRange(new[]
            {
                new SelectListItem() {Text = "50-55", Value = "50-55", Selected = false},
                new SelectListItem() {Text = "56-60", Value = "56-60", Selected = false},
                new SelectListItem() {Text = "61-65", Value = "61-65", Selected = false},
                new SelectListItem() {Text = "66-70", Value = "66-70", Selected = false},
                new SelectListItem() {Text = "71-75", Value = "71-75", Selected = false},
                new SelectListItem() {Text = "75 +", Value = "75 +", Selected = false}
            });
            ViewData["AgeGroup"] = ageGroupList;

            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.AddRange(new[]
            {
                new SelectListItem() {Text = "Male", Value = "Male", Selected = false},
                new SelectListItem() {Text = "Female", Value = "Female", Selected = false},
                new SelectListItem() {Text = "Others", Value = "Others", Selected = false}
            });
            ViewData["Gender"] = genderList;

            List<SelectListItem> numOfRoomList = new List<SelectListItem>();
            numOfRoomList.AddRange(new[]
            {
                new SelectListItem() {Text = "1", Value = "1", Selected = false},
                new SelectListItem() {Text = "2", Value = "2", Selected = false},
                new SelectListItem() {Text = "3", Value = "3", Selected = false},
                new SelectListItem() {Text = "4", Value = "4", Selected = false}
            });
            ViewData["NumOfRoom"] = numOfRoomList;

            ViewData["SuburbName"] = new SelectList(db.Suburbs, "SuburbName", "SuburbName");

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

            var numOfRoom = client.NumOfRoom;
            var currentRent = int.Parse(rent);
            var acceptableRent = client.Salary * 0.3;

            List<Suburb> selectedSuburb = db.Suburbs.Where(x => x.SuburbName == client.SuburbSuburbName).ToList();
            var areaName = selectedSuburb[0].AreaName;
            var availableSuburb = db.Suburbs.Where(x => x.AreaName == areaName).Select(x => x.SuburbName).ToList();

            if (currentRent > acceptableRent)
            {

                List<House> housingList = db.Houses.Where(x => availableSuburb.Contains(x.SuburbSuburbName)).Where(x => x.MediumPrice <= acceptableRent)
                                                .Where(x => x.NumOfRoom >= numOfRoom)
                                                .OrderByDescending(x => x.MediumPrice).Take(8).ToList();

                if (housingList.Count() == 0)
                {
                    housingList = db.Houses.Where(x => x.MediumPrice <= acceptableRent)
                                                .Where(x => x.NumOfRoom >= numOfRoom)
                                                .OrderByDescending(x => x.MediumPrice).Take(8).ToList();
                }


                if (housingList.Count() == 0)
                {
                    ViewBag.ResultTitle = "Sorry! There is no option for you.";
                }

                List<House> housingList1 = db.Houses.Where(x => x.MediumPrice <= acceptableRent)
                                                .Where(x => x.NumOfRoom >= numOfRoom)
                                                .OrderByDescending(x => x.MediumPrice).Take(8).ToList();


                /*
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
                */

                //return Redirect("~/Questionnaire/Index");

                return View(housingList);
            }
            else
            {
                //chnage to another website           
                //return Redirect("~/Home/Contact");
                List<House> housingList = db.Houses.Where(x => availableSuburb.Contains(x.SuburbSuburbName)).Where(x => x.MediumPrice <= acceptableRent)
                                                .Where(x => x.NumOfRoom >= numOfRoom)
                                                .OrderByDescending(x => x.MediumPrice).Take(8).ToList();

                ViewBag.ResultTitle = "Great! You are not at homelessness risk.";

                return View(housingList);
            }
        }

        public bool IsNumeric(String input)
        {
            bool isNumeric = true;
            foreach (char c in input)
            {
                if (!Char.IsNumber(c))
                {
                    isNumeric = false;
                    break;
                }
            }
            return isNumeric;
        }

        protected override void HandleUnknownAction(string actionName)
        {
            Response.Redirect("~/Home/Index");
            base.HandleUnknownAction(actionName);
        }
    }


}