using System;

namespace LogicLayer
{
    public class CleanRobot
    {
        #region BussinesRules
        private void NewPosition(ViewModel.Position positionActual, ref ViewModel.Position positionFuture, bool advance, int xMax, int yMAx)
        {
            switch (positionActual.facing)
            {
                case "N":
                    if (advance)
                    {
                        if (positionFuture.X > 0)
                        {
                            positionFuture.X = positionFuture.X - 1;
                        }
                    }
                    else
                    {
                        if (positionFuture.X < xMax)
                        {
                            positionFuture.X = positionFuture.X + 1;
                        }
                    }
                    break;
                case "S":
                    if (advance)
                    {
                        if (positionFuture.X < xMax)
                        {
                            positionFuture.X = positionFuture.X + 1;
                        }
                    }
                    else
                    {
                        if (positionFuture.X > 0)
                        {
                            positionFuture.X = positionFuture.X - 1;
                        }
                    }
                    break;
                case "E":
                    if (advance)
                    {
                        if (positionFuture.Y > 0)
                        {
                            positionFuture.Y = positionFuture.Y - 1;
                        }
                    }
                    else
                    {
                        if (positionFuture.Y < xMax)
                        {
                            positionFuture.Y = positionFuture.Y + 1;
                        }
                    }
                    break;
                case "W":
                    if (advance)
                    {
                        if (positionFuture.Y < xMax)
                        {
                            positionFuture.Y = positionFuture.Y + 1;
                        }
                    }
                    else
                    {
                        if (positionFuture.Y > 0)
                        {
                            positionFuture.Y = positionFuture.Y - 1;
                        }
                    }
                    break;
            }
        }
        private void DoAction(ViewModel.Map input, ref ViewModel.Position position, ref int batteryConsumption, ref ViewModel.Output output)
        {
            string cellValue = input.map[position.X][position.Y].ToString();
            if (cellValue == "S")
            {
                output.visited.Add(position);
            }
            else if (cellValue == "C")
            {
                output.visited.Add(position);
                output.cleaned.Add(position);
                batteryConsumption = batteryConsumption + 5;
            }
            else if (cellValue == "NULL")
            {
                DoAction(input, ref position, ref batteryConsumption, ref output);
            }


        }
        private void Turn(string action, ref ViewModel.Position positionActual)
        {
            string actualFacing = positionActual.facing;

            if (action == "TL")
            {
                switch (actualFacing)
                {
                    case "N":
                        positionActual.facing = "W";
                        break;
                    case "W":
                        positionActual.facing = "S";
                        break;
                    case "S":
                        positionActual.facing = "E";
                        break;
                    case "E":
                        positionActual.facing = "N";
                        break;
                }
            }
            else if (action == "TR")
            {
                switch (actualFacing)
                {
                    case "N":
                        positionActual.facing = "E";
                        break;
                    case "E":
                        positionActual.facing = "S";
                        break;
                    case "S":
                        positionActual.facing = "W";
                        break;
                    case "W":
                        positionActual.facing = "N";
                        break;
                }
            }
        }
        private void OperateCommand(string command, ref int batteryInitial, ref int batteryConsumption, int xMax, int yMax, ref ViewModel.Position positionActual, ref ViewModel.Position positionFuture, ref ViewModel.Map input, ref ViewModel.Output output)
        {
            if (batteryInitial > batteryConsumption)
            {
                switch (command)
                {

                    case "A":
                        NewPosition(positionActual, ref positionFuture, true, xMax, yMax);
                        batteryConsumption = batteryConsumption + 2;
                        DoAction(input, ref positionActual, ref batteryConsumption, ref output);
                        break;
                    case "B":
                        NewPosition(positionActual, ref positionFuture, false, xMax, yMax);
                        batteryConsumption = batteryConsumption + 3;
                        DoAction(input, ref positionActual, ref batteryConsumption, ref output);
                        break;
                    case "TL":
                        Turn(command, ref positionActual);
                        batteryConsumption = batteryConsumption + 1;
                        break;
                    case "TR":
                        Turn(command, ref positionActual);
                        batteryConsumption = batteryConsumption + 1;
                        break;
                }
            }
        }
        #endregion
        public ViewModel.Output Execute(ViewModel.Map input)
        {
            ViewModel.Position positionActual = new ViewModel.Position();
            ViewModel.Position positionFuture = new ViewModel.Position();
            ViewModel.Output output = new ViewModel.Output();
            output.visited.Add(input.start);

            int batteryInitial = input.battery;
            int batteryConsumption = 0;
            positionActual = input.start;
            int Max = input.map[0].Count;
            foreach (string command in input.commands)
            {
                OperateCommand(command, ref batteryInitial, ref batteryConsumption, input.map.Count, input.map[0].Count, ref positionActual, ref positionFuture, ref input, ref output);
            }
            return output;
        }

    }
}
