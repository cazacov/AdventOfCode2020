using System.Collections.Generic;

namespace Day_12_2
{
    internal class Navigation
    {
        public Navigation()
        {
            this.PosX = 0;
            this.PosY = 0;

            this.WayX = 10;
            this.WayY = 1;
        }

        public int WayY { get; set; }
        public int WayX { get; set; }

        public int PosY { get; set; }
        public int PosX { get; set; }

        public void Go(List<Step> steps)
        {
//            Console.WriteLine($"Pos=({PosX},{PosY})\tWaypoit=({WayX},{WayY})");
            foreach (var step in steps)
            {
                switch (step.Direction)
                {
                    case 'N':
                        this.WayY += step.Distance;
                        break;
                    case 'S':
                        this.WayY -= step.Distance;
                        break;
                    case 'E':
                        this.WayX += step.Distance;
                        break;
                    case 'W':
                        this.WayX -= step.Distance;
                        break;
                    case 'L':
                        for (var i = 0; i < step.Distance / 90; i++)
                        {
                            int temp = WayY;
                            WayY = WayX;
                            WayX = -temp;
                        }
                        break;
                    case 'R':
                        for (var i = 0; i < step.Distance / 90; i++)
                        {
                            int temp = WayY;
                            WayY = -WayX;
                            WayX = temp;
                        }
                        break;
                    case 'F':
                        for (var i = 0; i < step.Distance; i++)
                        {
                            PosX += WayX;
                            PosY += WayY;
                        }
                        break;
                }
//                Console.WriteLine($"{step.Direction} {step.Distance}\tPos=({PosX},{PosY})\tWaypoit=({WayX},{WayY})");
            }
            
        }
    }
}