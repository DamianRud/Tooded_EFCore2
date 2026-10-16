using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
namespace Tooded_EFCore
{
   

    public class Kategooria
    {
        public int Id { get; set; }
        public string Kategooria_nimetus { get; set; }
        public string Kirjeldus { get; set; }

        public ICollection<Toode> Tooded { get; set; }
    }
}
