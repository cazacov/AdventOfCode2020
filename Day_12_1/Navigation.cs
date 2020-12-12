using System.Collections.Generic;

namespace Day_12_1
{
    internal class Navigation
    {
        public Navigation()
        {
            this.PosX = 0;
            this.PosY = 0;
            this.Direction = 'E';
        }

        public int PosX { get; set; }
        public int PosY { get; set; }
        public char Direction { get; set; }

        public void Go(List<Step> steps)
        {
            foreach (var step in steps)
            {
                switch (step.Direction)
                {
                    case 'N':
                        this.PosY += step.Distance;
                        break;
                    case 'S':
                        this.PosY -= step.Distance;
                        break;
                    case 'E':
                        this.PosX += step.Distance;
                        break;
                    case 'W':
                        this.PosX -= step.Distance;
                        break;
                    case 'L':
                        for (int i = 0; i < step.Distance / 90; i++)
                        {
                            switch (this.Direction)
                            {
                                case 'N':
                                    this.Direction = 'W';
                                    break;
                                case 'W':
                                    this.Direction = 'S';
                                    break;
                                case 'S':
                                    this.Direction = 'E';
                                    break;
                                case 'E':
                                    this.Direction = 'N';
                                    break;
                            }
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < step.Distance / 90; i++)
                        {
                            switch (this.Direction)
                            {
                                case 'N':
                                    this.Direction = 'E';
                                    break;
                                case 'W':
                                    this.Direction = 'N';
                                    break;
                                case 'S':
                                    this.Direction = 'W';
                                    break;
                                case 'E':
                                    this.Direction = 'S';
                                    break;
                            }
                        }
                        break;
                    case 'F':
                        int dx = 0;
                        int dy = 0;
                        switch (this.Direction)
                        {
                            case 'N':
                                dy = step.Distance;
                                break;
                            case 'W':
                                dx = -step.Distance;
                                break;
                            case 'S':
                                dy = -step.Distance;
                                break;
                            case 'E':
                                dx = step.Distance;
                                break;
                        }

                        this.PosX += dx;
                        this.PosY += dy;
                        break;
                }
            }
        }
    }
}