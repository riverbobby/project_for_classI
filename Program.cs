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
            //pre-population of 5 parts for testing **please change line (public static int partCount = 5;) in Part.cs
            Inventory.AllParts.Add(new Inhouse(1, "Hose", 4.57m, 4, 2, 7, 56789));
            Inventory.AllParts.Add(new Outsourced(2, "Wheel", 10.89m, 4, 2, 7, "Troubador"));
            Inventory.AllParts.Add(new Inhouse(3, "Pedal", 3.24m, 4, 2, 7, 89446));
            Inventory.AllParts.Add(new Outsourced(4, "Chain", 5.82m, 4, 2, 7, "Madagar"));
            Inventory.AllParts.Add(new Inhouse(5, "Seat", 9.42m, 4, 2, 7, 40444));
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InventoryForm());
        }
    }
}
