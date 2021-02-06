﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JustinTownleySoftwareI
{
    static class Inventory
    {
        private static BindingList<Product> products = new BindingList<Product>();
        private static BindingList<Part> allParts = new BindingList<Part>();

        public static BindingList<Product> Products { get { return products; } set { products = value; } }
        public static BindingList<Part> AllParts { get { return allParts; } set { allParts = value; } }
        
        //global static variables
        public static Part CurrentPart { get; set; }
        public static int CurrentPartID { get; set; }
        public static int CurrentPartIndex { get; set; }
        public static Product CurrentProduct { get; set; }
        public static int CurrentProductID { get; set; }
        public static int CurrentProductIndex { get; set; }

        //global static methods
        public static void addProduct(Product product)
        {
            Products.Add(product);
        }
        
        //The UML Class Diagram indicated this function to 
        //have a bool return type and I saw no reason for this so I changed it to void
        public static void removeProduct(int i)
        {
            Products.RemoveAt(i);
        }

        public static Product lookupProduct(int i)
        {
            for (int j = 0; j < Products.Count; ++j)
            {
                if (Products[j].ProductID.Equals(i))
                {
                    CurrentPartIndex = j;
                    return Products[j];
                }
            }
            CurrentProductIndex = -1;
            return null;
        }

        public static void updateProduct(int i, Product product)
        {
            Products.Insert(i, product);
            Products.RemoveAt(i + 1);
        }

        public static void addPart(Part part)
        {
            AllParts.Add(part);
        }

        //The UML Class Diagram indicated this function to 
        //have a bool return type and I saw no reason for this so I changed it to void
        public static void deletePart(int i)
        {
            AllParts.RemoveAt(i);
        }

        public static Part lookupPart(int i)
        {
            for (int j = 0; j < AllParts.Count; ++j)
            {
                if (AllParts[j].PartID.Equals(i))
                {
                    CurrentPartIndex = j;
                    return AllParts[j];
                }
            }
            CurrentPartIndex = -1;
            return null;
        }

        public static void updatePart(int i, Part part)
        {
            AllParts.Insert(i, part);
            AllParts.RemoveAt(i + 1);
        }
    }
}
