using System;
using System.Collections.Generic;
using System.Linq;

namespace FNZ.Bomb
{
    public class BombCore
    {
        public static bool Defuse(string code)
        {
            List<char> input = code.ToCharArray().ToList();

            if (!input.Any()) return false;

            var iDay = DateTime.ParseExact("28-October-1918", "dd-MMMM-yyyy", null);
            var sIDay = iDay.ToString("yyyyMMdd");

            var a = char.Parse((int.Parse(iDay.ToString(("MM"))) - 1).ToString());
            var n_a = int.Parse(a.ToString());
            if (input[0] != a)
            {
                return false;
            }
            input.RemoveAt(0);

            if (!input.Any()) return false;
            if (input[0] != char.Parse(sIDay.Substring(6, 1)))
            {
                return false;
            }
            input.RemoveAt(0);

            if (!input.Any()) return false;
            if (input[0] != char.Parse(Math.Abs(n_a - int.Parse(sIDay)).ToString().Substring(0, 1)))
            {
                return false;
            }
            input.RemoveAt(0);

            if (!input.Any()) return false;
            if (input[0] != char.Parse((n_a / 2).ToString()))
            {
                return false;
            }
            input.RemoveAt(0);

            if (input.Any())
            {
                return false;
            }

            return true;
        }
    }
}
