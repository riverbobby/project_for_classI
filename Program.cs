using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JustinTownleySoftwareI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //pre-population of 5 parts for testing
            Inventory.AllParts.Add(new Inhouse("Hose", 4.57m, 4, 2, 7, 56789));
            Inventory.AllParts.Add(new Outsourced("Wheel", 10.89m, 4, 2, 7, "Troubador"));
            Inventory.AllParts.Add(new Inhouse("Pedal", 3.24m, 4, 2, 7, 89446));
            Inventory.AllParts.Add(new Outsourced("Chain", 5.82m, 4, 2, 7, "Madagar"));
            Inventory.AllParts.Add(new Inhouse("Seat", 9.42m, 4, 2, 7, 40444));
            Inventory.Products.Add(new Product("Huffy", 67.45m, 3, 1, 8));
            Inventory.Products[0].addAssociatedPart(Inventory.AllParts[1]);
            Inventory.Products[0].addAssociatedPart(Inventory.AllParts[0]);
            Inventory.Products.Add(new Product("BMX", 102.35m, 4, 2, 10));
            Inventory.Products[1].addAssociatedPart(Inventory.AllParts[4]);
            Inventory.Products[1].addAssociatedPart(Inventory.AllParts[3]);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InventoryForm());
        }
    }
}
