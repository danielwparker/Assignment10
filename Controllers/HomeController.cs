using Bowling.Models;
using Bowling.Models.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index(long? teamId, string teamname, int pageNum = 0)
        {
            int pageSize = 5;

            return View(new IndexViewModel
            {
                Bowlers = (context.Bowlers
                    //Sorts content
                    .Where(m => m.TeamId == teamId || teamId == null)
                    .OrderBy(m => m.BowlerLastName)
                    //Creates pagination
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),

                PageNumberInfo = new PageNumberInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //Counts all bowlers or bowlers per team
                    TotalNumItems = (teamId == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == teamId).Count())
                },

                Team = teamname

            }); ;

        

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
