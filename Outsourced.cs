using System;
using System.Collections.Generic;
using System.Text;

namespace JustinTownleySoftwareI
{
    class Outsourced : Part
    {
        public string CompanyName { get; set; }

        public Outsourced(string n, decimal p, int inStock, int min, int max, string cName)
        : base(n, p, inStock, min, max)
        {
            CompanyName = cName;
        }

        public Outsourced(int pID, string n, decimal p, int inStock, int min, int max, string cName)
            : base(pID, n, p, inStock, min, max)
        {
            CompanyName = cName;
        }
    }
}
