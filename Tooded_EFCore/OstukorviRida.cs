using System;
using System.Collections.Generic;
using System.Text;

namespace Tooded_EFCore
{
    public class OstukorviRida
    {
        public Toode Toode { get; set; }
        public int Kogus { get; set; }

        public float Summa => Toode.Hind * Kogus;

        public override string ToString()
        {
            return $"{Toode.Toodenimetus} – {Kogus} tk – {Summa} €";
        }
    }
}
