using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Helper
{
    // Bruges til session, for at gemme alle produktid's og hvor mange antal, af hvert produkt
    public class SessionData
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
