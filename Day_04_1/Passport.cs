using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day_04_1
{
    public class Passport
    {
        public Dictionary<string, string> fields = new Dictionary<string, string>();
        private bool isPresent;
        private int byr;
        private int iyr;
        private int eyr;
        private string hgt;
        private string hcl;
        private string ecl;
        private string pid;

        public Passport(string block)
        {
            var fieldr = new Regex(@"(\w*):(\S*)");
            var bfields = block.Split(' ');
            foreach (var field in bfields)
            {
                if (field == String.Empty)
                {
                    continue;
                }
                var m = fieldr.Match(field);
                if (!m.Success)
                {
                    throw new ArgumentOutOfRangeException($"Unsupported input format: {field}");
                }
                if (m.Groups.Count != 3)
                {
                    throw new ArgumentOutOfRangeException($"Unsupported input format: {field}");
                }
                fields.Add(m.Groups[1].Value, m.Groups[2].Value);
            }
            ParseFields();
        }

        private void ParseFields()
        {
            this.isPresent = true;
            var hgtr = new Regex(@"(\d*)(\w*)");
            var colorr = new Regex("^#[0-9a-f]{6}$");
            var eyer = new Regex("^(amb|blu|brn|gry|grn|hzl|oth)$");
            var pidr = new Regex(@"^\d{9}$");
            try
            {
                this.byr = Int32.Parse(this.fields["byr"]);
                if (byr < 1920 || byr > 2002)
                {
                    this.isPresent = false;
                }
                this.iyr = Int32.Parse(this.fields["iyr"]);
                if (iyr < 2010 || iyr > 2020)
                {
                    this.isPresent = false;
                }
                this.eyr = Int32.Parse(this.fields["eyr"]);
                if (eyr < 2020 || eyr > 2030)
                {
                    this.isPresent = false;
                }
                this.hgt = fields["hgt"];
                var hgtm = hgtr.Match(hgt);
                if (!hgtm.Success || hgtm.Groups.Count != 3)
                {
                    this.isPresent = false;
                }
                var units = hgtm.Groups[2].Value;
                var height = Int32.Parse(hgtm.Groups[1].Value);
                if (units == "cm")
                {
                    if (height < 150 || height > 193)
                    {
                        this.isPresent = false;
                    }
                }
                else if (units == "in")
                {
                    if (height < 59 || height > 76)
                    {
                        this.isPresent = false;
                    }
                }
                else
                {
                    this.isPresent = false;
                }
                this.hcl = fields["hcl"];
                if (!colorr.IsMatch(hcl))
                {
                    this.isPresent = false;
                }
                this.ecl = fields["ecl"];
                if (!eyer.IsMatch(ecl))
                {
                    this.isPresent = false;
                }
                this.pid = fields["pid"];
                if (!pidr.IsMatch(pid))
                {
                    this.isPresent = false;
                }
            }
            catch (Exception ex)
            {
                this.isPresent = false;
            }
        }

        public bool IsPresent
        {
            get
            {
                return this.isPresent;
            }
        }

        internal bool IsValid
        {
            get
            {
                if (this.fields.Count == 8)
                {
                    return true;
                }
                if (this.fields.Count == 7 && !this.fields.ContainsKey("cid"))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
