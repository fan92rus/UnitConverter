using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace UnitConverter
{
    class Program
    {
        public static Dictionary<string, double> Values = new Dictionary<string, double>()
        {
            {"j", 1d},
            {"kj", 1000d},
            {"btu", 1000d},

            {"kg", 1},
            {"g", .001},
            {"lb", 2.20462},

            {"k", 1},
            {"r", 1.8},

            {"m3", 1},
            {"mcf", 3.53E-02},
            {"cf", 35.31},
            {"cc", 1000000},
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
            {"cp", 0.01},


            {"mol", 1},

            {"p.m2", 1},
            {"p.d", 9.86923E-13},
            {"p.md", 9.86923E-10},

        };
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please in expression");

                var exp = Console.ReadLine();

                exp = Values.OrderByDescending(x => x.Key.Length).Aggregate(exp, (current, val) => current.Replace(val.Key, val.Value.ToString(CultureInfo.InvariantCulture)));

                var value = (new DataTable().Compute(exp, null)).ToString()?.Replace(",", ".");

                Console.WriteLine(value);
            }
        }
    }
}
