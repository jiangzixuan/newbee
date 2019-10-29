using Newbee.Bll;
using Newbee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Newbee.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Questions()
        {
            
            return View();
        }

        public ActionResult GetQuestion(int quesIndex)
        {
            List<M_Question> ql = QuestionHelper.Questions;

            M_Question q = ql.FirstOrDefault(a=>a.Num == quesIndex);

            ViewBag.QuesIndex = quesIndex;
            ViewBag.QuesCount = ql.Count;
            return View(q);
        }

        public ActionResult ShowResult(string answer)
        {
            string[] answers = answer.Split(',');

            return View();
        }
    }
}
