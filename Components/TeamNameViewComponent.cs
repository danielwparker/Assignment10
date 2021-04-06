using Bowling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Components
{
    public class TeamNameViewComponent : ViewComponent
    {

        private BowlingLeagueContext context;

        public TeamNameViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            //Allows to select the team for the heading and menu shading
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];
            return View(context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
