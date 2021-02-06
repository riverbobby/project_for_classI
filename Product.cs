using System;
using System.Collections.Generic;
using System.Text;

namespace JustinTownleySoftwareI
{
    class Product
    {
        public Part AssociatedParts { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public static int productCount = 0;

        public Product(string n, decimal p, int inStock, int min, int max)
        {
            ProductID = productCount++;
            Name = n;
            Price = p;
            InStock = inStock;
            Min = min;
            Max = max;
        }

        public Product()
        {

        }

        //public void addAssociatedPart(Part)
        //{

        //}

        //public bool removeAssociatedPart(int)
        //{

        //}

        //public Part lookupAssociatedPart(int)
        //{

        //}
    }
}
