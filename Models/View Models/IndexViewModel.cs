using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Models.View_Models
{
    public class IndexViewModel
    {
        public List<Bowlers> Bowlers { get; set; }
        public PageNumberInfo PageNumberInfo { get; set; }
        public string Team { get; set; }
    }
}
