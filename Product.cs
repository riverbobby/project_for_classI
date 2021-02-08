using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JustinTownleySoftwareI
{
    class Product
    {
        private BindingList<Part> associatedParts = new BindingList<Part>();

        public BindingList<Part> AssociatedParts { get {return associatedParts; } set { associatedParts = value; } }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public static int productCount = 0;

        //default constructor for temp when adding or modifying product
        public Product()
        {

        }
        //constructor for pre-populated products
        public Product(string n, decimal p, int inStock, int min, int max)
        {
            ProductID = ++productCount;
            Name = n;
            Price = p;
            InStock = inStock;
            Min = min;
            Max = max;
        }
        //constructor for new products
        //public Product(BindingList<Part> parts, string n, decimal p, int inStock, int min, int max)
        //{
        //    AssociatedParts = parts;
        //    ProductID = ++productCount;
        //    Name = n;
        //    Price = p;
        //    InStock = inStock;
        //    Min = min;
        //    Max = max;
        //}
        //constructor for modified products
        public Product(/*BindingList<Part> parts, */int pID, string n, decimal p, int inStock, int min, int max)
        {
            //AssociatedParts = parts;
            ProductID = pID;
            Name = n;
            Price = p;
            InStock = inStock;
            Min = min;
            Max = max;
        }

        public void addAssociatedPart(Part part)
        {
            associatedParts.Add(part);

        }

        public bool removeAssociatedPart(int i)
        {
            associatedParts.RemoveAt(i);
            return true;
        }

        public Part lookupAssociatedPart(int i)
        {
            for (int j = 0; j < associatedParts.Count; ++j)
            {
                if (associatedParts[j].PartID.Equals(i))
                {
                    Inventory.CurrentAssociatedPartIndex = j;
                    return associatedParts[j];
                }
            }
            Inventory.CurrentAssociatedPartIndex = -1;
            return null;

        }
    }
}
