using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JustinTownleySoftwareI
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();

            partsDGV.DataSource = Inventory.AllParts;
        }
        private void partsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void addPartButton_Click(object sender, EventArgs e)
        {

        }
        private void modifyPartButton_Click(object sender, EventArgs e)
        {

        }
        private void deletePartButton_Click(object sender, EventArgs e)
        {

        }

        private void searchPartsButton_Click(object sender, EventArgs e)
        {

        }
        private void productDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addProductButton_Click(object sender, EventArgs e)
        {

        }

        private void modifyProductButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteProductButton_Click(object sender, EventArgs e)
        {

        }
        private void searchProductButton_Click(object sender, EventArgs e)
        {

        }

        private void exitProgramButton_Click(object sender, EventArgs e)
        {

        }

    }
}
