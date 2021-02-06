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

        //value set at 5 to include pre-initialized Parts in Program.cs
        public static int partCount = 5;

        public Part(string n, decimal p, int inStock, int min, int max)
        {
            PartID = ++partCount;
            Name = n;
            Price = p;
            InStock = inStock;
            Min = min;
            Max = max;
        }

        public Part(int partID, string n, decimal p, int inStock, int min, int max)
        {
            PartID = partID;
            Name = n;
            Price = p;
            InStock = inStock;
            Min = min;
            Max = max;
        }
    }
}
