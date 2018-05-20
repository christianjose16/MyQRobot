using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogicLayer;

namespace RMSRobot.Controllers
{
    [Route("api/[controller]")]
    public class RobotprocessController : Controller
    {
        
        // POST api/values
        [HttpPost]
        public LogicLayer.ViewModel.Output Post([FromBody]LogicLayer.ViewModel.Map input)
        {
            LogicLayer.CleanRobot cleanrobot = new CleanRobot();
            LogicLayer.ViewModel.Output output = cleanrobot.Execute(input);
            return output;
        }

    }
}
