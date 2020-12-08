using System;
using System.Collections.Generic;

namespace Day_08_2
{
    public class Computer
    {
        List<Instruction> RAM;
        private int Accumulator;
        private int IP;
        private List<Instruction> RAM_Init;
        public Dictionary<int, bool> Visited { get; private set; }

        public Computer()
        {
            RAM = new List<Instruction>();

            var input = System.IO.File.ReadAllLines("input.txt");
            ParseSource(input);
            this.RAM_Init = CopyRAM(RAM);
        }

        private void ParseSource(string[] input)
        {
            foreach (var line in input)
            {
                var ops = line.Substring(0, 3);
                var ins = new Instruction();
                switch (ops)
                {
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

        private List<Instruction> CopyRAM(List<Instruction> ram)
        {
            var result = new List<Instruction>();
            foreach (var ins in ram)
            {
                result.Add(new Instruction()
                {
                    Argument = ins.Argument,
                    Operation = ins.Operation
                });
            }
            return result;
        }

        public int FindCorrupt()
        {
            for (var i = 0; i < this.RAM_Init.Count; i++)
            {
                if (this.RAM_Init[i].Operation == Operation.ACC)
                {
                    continue;
                }
                this.RAM = CopyRAM(RAM_Init);

                // Try to repair command in position i
                this.RAM[i].Operation = this.RAM_Init[i].Operation == Operation.NOP ? Operation.JMP : Operation.NOP;
                if (IsCorrect())
                {
                    return this.Accumulator;
                }
            }
            throw new Exception("Could not find the corrupted instruction");
        }

        public bool IsCorrect()
        {
            this.Accumulator = 0;
            this.IP = 0;
            this.Visited = new Dictionary<int, bool>();
            do
            {
                if (!TryExecuteStep())
                {
                    return false;
                }
                if (this.IP == this.RAM.Count)
                {
                    return true;
                }
            } while (true);
        }

        public bool TryExecuteStep()
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
            if (this.Visited.ContainsKey(nextIp))
            {
                return false;
            }
            else if (nextIp < 0)
            {
                return false;
            }
            else if (nextIp > RAM.Count)
            {
                return false;
            }
            else
            {
                this.Visited[nextIp] = true;
                this.IP = nextIp;
                return true;
            }
        }
    }
}