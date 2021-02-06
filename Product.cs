using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JustinTownleySoftwareI
{
    class Product
    {
        private BindingList<Part> associatedParts = new BindingList<Part>();

        public Part AssociatedParts { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public static int productCount = 0;

        public Product(Part parts , string n, decimal p, int inStock, int min, int max)
        {
            AssociatedParts = parts;
            ProductID = productCount++;
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

        //The UML Class Diagram indicated this function to 
        //have a bool return type and I saw no reason for this so I changed it to void
        public void removeAssociatedPart(int i)
        {
            associatedParts.RemoveAt(i);
        }

        public Part lookupAssociatedPart(int i)
        {
            for (int j = 0; j < associatedParts.Count; ++j)
            {
                if (associatedParts[j].PartID.Equals(i))
                {
                    Inventory.CurrentPartIndex = j;
                    return associatedParts[j];
                }
            }
            Inventory.CurrentPartIndex = -1;
            return null;

        }
    }
}
