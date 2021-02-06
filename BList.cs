using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JustinTownleySoftwareI
{
    static class BList
    {
        private static BindingList<Part> parts = new BindingList<Part>();
        public static BindingList<Part> Parts { get { return parts; } set { parts = value; } }
        
        public static Part CurrentPart { get; set; }
        public static int CurrentPartID { get; set; }
        public static int CurrentPartIndex { get; set; }

        public static Part lookupPart(int i)
        {
            for (int j = 0; j < Parts.Count; ++j)
            {
                if (Parts[j].PartID.Equals(i))
                {
                    CurrentPartIndex = j;
                    return Parts[j];
                }
            }
            CurrentPartIndex = -1;
            return null;
        }

        internal static void swap(Part part)
        {
            Parts.Insert(CurrentPartIndex, part);
            Parts.RemoveAt(CurrentPartIndex + 1);
        }

        private static BindingList<Product> products = new BindingList<Product>();
        public static BindingList<Product> Products { get { return products; } set { products = value; } }

        public static Product CurrentProduct { get; set; }
        public static int CurrentProductID { get; set; }
        public static int CurrentProductIndex { get; set; }

        public static Product lookupProduct(int i)
        {
            for (int j = 0; j < Products.Count; ++j)
            {
                if (Products[j].ProductID.Equals(i))
                {
                    CurrentProductIndex = j;
                    return Products[j];
                }
            }
            CurrentProductIndex = -1;
            return null;
        }

        internal static void swap(Product product)
        {
            Products.Insert(CurrentProductIndex, product);
            Products.RemoveAt(CurrentProductIndex + 1);
        }
    }
}
