using System;
using System.Collections.Generic;
using System.Text;

namespace JustinTownleySoftwareI
{
    class Inhouse : Part
    {
        public int MachineID { get; set; }

        public Inhouse(string n, decimal p, int inStock, int min, int max, int mID)
        : base(n, p, inStock, min, max)
        {
            MachineID = mID;
        }

        public Inhouse(int pID, string n, decimal p, int inStock, int min, int max, int mID)
            : base(pID, n, p, inStock, min, max)
        {
            MachineID = mID;
        }
    } 
}
