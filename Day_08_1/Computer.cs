using System;
using System.Collections.Generic;

namespace Day_08_1
{
    public class Computer
    {
        List<Instruction> RAM;
        private int Accumulator;
        private int IP;

        public Dictionary<int, bool> Visited { get; private set; }

        public Computer()
        {
            RAM = new List<Instruction>();
            var input = System.IO.File.ReadAllLines("input.txt");
            foreach (var line in input)
            {
                var ops = line.Substring(0, 3);
                var ins = new Instruction();
                switch (ops) {
                    case "nop":
                        ins.Operation = Operation.NOP;
                        break;
                    case "acc":
                        ins.Operation = Operation.ACC;
                        break;
                    case "jmp":
                        ins.Operation = Operation.JMP;
                        break;
                }
                var argument = line.Substring(4);
                ins.Argument = Int32.Parse(argument);
                RAM.Add(ins);
            }
        }

        public int FindLoopAcc()
        {
            this.Accumulator = 0;
            this.IP = 0;
            this.Visited = new Dictionary<int, bool>();
            do
            {
                var nextIp = ExecuteStep();
                if (this.Visited.ContainsKey(nextIp))
                {
                    break;
                }
                this.Visited[nextIp] = true;
                this.IP = nextIp;
            } while (true);
            return this.Accumulator;
        }

        private int ExecuteStep()
        {
            int nextIp = IP;
            var command = this.RAM[IP];
            switch (command.Operation)
            {
                case Operation.ACC:
                    this.Accumulator += command.Argument;
                    nextIp += 1;
                    break;
                case Operation.NOP:
                    nextIp += 1;
                    break;
                case Operation.JMP:
                    nextIp += command.Argument;
                    break;
            }

            return nextIp;
        }
    }
}