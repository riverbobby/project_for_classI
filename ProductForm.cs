using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JustinTownleySoftwareI
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            Inventory.CurrentPartIndex = -1;
            availablePartDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            availablePartDGV.DefaultCellStyle.SelectionBackColor = availablePartDGV.DefaultCellStyle.BackColor;
            availablePartDGV.DefaultCellStyle.SelectionForeColor = availablePartDGV.DefaultCellStyle.ForeColor;
            availablePartDGV.RowHeadersVisible = false;
            availablePartDGV.DataSource = Inventory.AllParts;
        }

        private void partSaveButton_Click(object sender, EventArgs e)
        {

        }

        private void productCancelButton_Click(object sender, EventArgs e)
        {

        }

        private void deletePartProductButton_Click(object sender, EventArgs e)
        {

        }

        private void addPartProductButton_Click(object sender, EventArgs e)
        {

        }

        private void searchAvailablePartsButton_Click(object sender, EventArgs e)
        {

        }

        private void availablePartDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventory.CurrentPartIndex = e.RowIndex;
            Inventory.CurrentPartID = (int)availablePartDGV.Rows[Inventory.CurrentPartIndex].Cells[0].Value;
            Inventory.CurrentPart = Inventory.lookupPart(Inventory.CurrentPartID);
            availablePartDGV.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
        }

        private void associatedPartDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
