using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test0918_Controls.Controllers
{
    public class LabController : Controller
    {
        // GET: Lab
        public ActionResult Index()
        {
            return View();
        }
        [ActionName("Member")]  //練習1 成功
        public ActionResult SignUp(CMember Mbr) {
            string Result = string.Format("FirstName: {0},LastName: {1}",Mbr.FirstName,Mbr.LastName);
            return Content(Result);
        }
        
        public ActionResult MemberSignUp(CMember Mbr) { //練習2 成功
            string Result = string.Format("FirstName: {0},LastName: {1}", Request["FirstName"], Request["LastName"]);
            return Content(Result);
        }
        public ActionResult testRedirect(CMember Mbr) { //練習3 失敗
            if (string.IsNullOrEmpty(Mbr.LastName)) {
                RedirectToAction("testRedirect","Lab");
            }
            return RedirectToAction("Member","Lab");
        }
        public ActionResult testXML() { //練習4 成功
            ContentResult Result = new ContentResult() {
                Content = "<book><title>bookName</title><price>500</price></book>",
                ContentType = "text/xml",
                ContentEncoding = System.Text.Encoding.UTF8
            };
            return Result;
        }
        public ActionResult testXML2() { //練習4優化 成功
            return new ContentResult() {
                Content = "<book><title>bookName</title><price>500</price></book>",
                ContentType = "text/xml",
                ContentEncoding = System.Text.Encoding.UTF8
            };
        }
        public ActionResult testRedirect2() { //練習5 成功
            return Redirect("http://www.google.com");
            //return RedirectToAction("Member","Lab");
        }
        public ActionResult testViewBag() { //練習六 成功
            ViewBag.FirstName = "Shaoming";
            return View();
        }
        public ActionResult testViewData() {
            ViewData["FirstName"] = "Shine";
            TempData["FirstName"] = "Shine Shine";
            //return View(); //顯示ViewData 成功
            //return RedirectToAction("ShowData","Lab"); //ViewData僅限本View使用 成功
            return RedirectToAction("ShowData","Lab");  //TempData值可到第二頁使用 成功
        }
        public ActionResult ShowData() {
            //return View(); //TempData 成功
            return RedirectToAction("ShowDataAgain","Lab"); //TempData 成功
        }
        public ActionResult ShowDataAgain() {
            return View();  //TempData 成功
        }
        [HttpPost]
        public ActionResult Hello(CMember Mbr) {  //練習 失敗
            if (string.IsNullOrEmpty(Mbr.LastName)) {
                return View(Mbr);
            }
            return RedirectToAction("SayHello","Lab");
        }
        public ActionResult SayHello() {
            return View();
        }
    }
    public class CMember {
        public string FirstName { set; get; }
        public string LastName { set; get; }
    }
}