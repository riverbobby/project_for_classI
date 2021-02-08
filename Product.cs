using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JustinTownleySoftwareI
{
    class Product
    {
        public BindingList<Part> associatedParts = new BindingList<Part>();

        public Part AssociatedParts { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public static int productCount = 0;

        public Product()
        {

        }
        public Product(Part parts, string n, decimal p, int inStock, int min, int max)
        {
            AssociatedParts = parts;
            ProductID = ++productCount;
            Name = n;
            Price = p;
            InStock = inStock;
            Min = min;
            Max = max;
        }

        public Product(Part parts, int pID, string n, decimal p, int inStock, int min, int max)
        {
            AssociatedParts = parts;
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
