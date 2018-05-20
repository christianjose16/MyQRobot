using System;
using System.IO;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LogicLayerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public string TestLogicexecution(string inputTxt)
        {
            LogicLayer.ViewModel.Map input = new LogicLayer.ViewModel.Map();
            LogicLayer.CleanRobot cleanrobot = new CleanRobot();

                JObject jo = (JObject)JToken.Parse(inputTxt);
                input = jo.ToObject<LogicLayer.ViewModel.Map>();
            
            LogicLayer.ViewModel.Output output = cleanrobot.Execute(input);
            return JsonConvert.SerializeObject(output);
        }
    }
}
