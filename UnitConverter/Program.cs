using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using NCalc;

namespace UnitConverter
{
    class Program
    {
        public static IOrderedEnumerable<KeyValuePair<string, double>> Values = new Dictionary<string, double>()
        {
            {"j", 1d},
            {"kj", 1000d},
            {"btu", 0.000947817},

            {"gm", 0.001D},
            {"kg", 1},
            {"lb", 0.453592},
            {"tn", 1000},
            {"stn", 907.185},

            {"k", 1},
            {"r", 1.8},

            {"m3", 1},
            {"kft3", 0.0283168 * 1000},
            {"ft3", 0.0283168},
            {"cm3", 1000000},
            {"b", 6.29},

            {"pa", 1},
            {"bar", 100000},
            {"psi", 6894.76},
            {"atm", 101325},

            {"s", 1},
            {"h", 3600},
            {"d", 86400},

            {"m", 1},
            {"ft", 3.2808399},
            {"cm", 100},

            {"pa.s", 1},
            {"cp", 1000},


            {"mol", 1},

            {"p.m2", 1},
            {"p.d", 9.86923E-13},
            {"p.md", 9.86923E-10},

        }.OrderByDescending(x => x.Key.Length);
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please in expression");

                var exp = Console.ReadLine();

                exp = Values.Aggregate(exp, (current, val) => current.Replace(val.Key, (val.Value).ToString(CultureInfo.InvariantCulture)));
                var value = (new DataTable().Compute(exp, null)).ToString()?.Replace(",", ".");
                Console.WriteLine(value);
            }
        }
    }
}
