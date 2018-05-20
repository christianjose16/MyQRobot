using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicLayer.ViewModel
{

    public class Output
    {
        public List<Position> visited { get; set; }
        public List<Position> cleaned { get; set; }
        public Position final { get; set; }
        public int battery { get; set; }
    }
}
