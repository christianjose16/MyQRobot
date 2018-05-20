using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicLayer.ViewModel
{


        public class Map
        {
            public List<List<string>> map { get; set; }
            public Position start { get; set; }
            public List<string> commands { get; set; }
            public int battery { get; set; }
        }
    }

