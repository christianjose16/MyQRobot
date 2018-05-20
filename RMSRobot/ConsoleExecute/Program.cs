using LogicLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExecute
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                System.Console.WriteLine("Please enter this two parameters [Input json file] and [Path output json file]");
            }
            else
            {

                LogicLayer.ViewModel.Map input = new LogicLayer.ViewModel.Map();
                LogicLayer.CleanRobot cleanrobot = new CleanRobot();
                using (StreamReader inputFile = File.OpenText(args[0].ToString()))
                using (JsonTextReader reader = new JsonTextReader(inputFile))
                {
                    JObject jo = (JObject)JToken.ReadFrom(reader);
                    input = jo.ToObject<LogicLayer.ViewModel.Map>();
                }
                LogicLayer.ViewModel.Output output = cleanrobot.Execute(input);
                var outputTxt = JsonConvert.SerializeObject(output);

                using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(args[1].ToString(), true))
                {
                    outputFile.Write(outputTxt);
                }
            }
        }
    }
}
