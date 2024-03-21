using Microsoft.AspNetCore.Mvc;
using SpaceWespers.Models;
using System.Diagnostics;
using System;
using System.Reflection.Metadata.Ecma335;

namespace SpaceWespers.Controllers
{
    public class HomeController : Controller
    {
        private List<News> GetObj()
        {
            List<News> news = new List<News>();
            List<object> a = LocalScr.DbHelper.ExecuteWithAnswer("SELECT * FROM SpaceDataBases ORDER BY dataId");
            for (int i = 0; i < a.Count; i += 5)
            {
                news.Add(new News(a[i].ToString(), a[i + 1].ToString(), a[i + 2].ToString(), a[i + 3].ToString(), a[i + 4].ToString()));
            }
            return news;
        }
        private List<News> GetUniStr()
        {
            List<News> news = new List<News>();
            List<object> a = LocalScr.DbHelper.ExecuteWithAnswer("SELECT dataId FROM SpaceDataBases ORDER BY dataId");
            for (int i = 0; i<=a.Count;i++)
            {
                string id = LocalScr.DbHelper.ExecuteQueryWithAnswer($"SELECT dataName From SpaceDataBases WHERE dataId = {i}");
            }
            return news;
        }
        private List<News> Search(string name)
        {
            if (name != null)
            {
                return GetObj().Where(n => n.dataName.ToString().Contains(name.ToLower())).ToList();
            }
            else
            {
                return GetObj();
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(GetObj());
        }
        [HttpPost]
        public IActionResult Index(string name)
        {
            return View(Search(name));
        }
        public IActionResult Privacy()
        {
            return View();
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
