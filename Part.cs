using System;
using System.Collections.Generic;
using System.Text;

namespace JustinTownleySoftwareI
{
    abstract class Part
    {
        public int PartID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public static int partCount;

        public Part(string n)
        {
            PartID = partCount++;
            Name = n;
        }

        public Part(int partID, string n)
        {
            PartID = partID;
            Name = n;
        }
    }
}
