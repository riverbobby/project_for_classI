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
        Product temp = new Product();
        public ProductForm()
        {
            //BindingList<Part> tempAssociatedParts = new BindingList<Part>();
            //If adding a new product Inventory.CurrentPartIndex will be -1
            if (Inventory.CurrentProductIndex < 0) 
            {
                InitializeComponent();
                Inventory.CurrentPartIndex = -1;
                Inventory.CurrentAssociatedPartIndex = -1;
                //BindingList<Part> tempAssociatedParts = new BindingList<Part>();
                //formatting for availablePartDGV
                availablePartDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                availablePartDGV.DefaultCellStyle.SelectionBackColor = availablePartDGV.DefaultCellStyle.BackColor;
                availablePartDGV.DefaultCellStyle.SelectionForeColor = availablePartDGV.DefaultCellStyle.ForeColor;
                availablePartDGV.RowHeadersVisible = false;
                availablePartDGV.DataSource = Inventory.AllParts;
                //formatting for associatedPartDGV
                associatedPartDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                associatedPartDGV.DefaultCellStyle.SelectionBackColor = associatedPartDGV.DefaultCellStyle.BackColor;
                associatedPartDGV.DefaultCellStyle.SelectionForeColor = associatedPartDGV.DefaultCellStyle.ForeColor;
                associatedPartDGV.DataSource = temp.AssociatedParts;
                //formatting for textboxes
                productNameTextBox.BackColor = System.Drawing.Color.Crimson;
            }
            //If modifying an existing product
            else
            {
                InitializeComponent();
                Inventory.CurrentPartIndex = -1;
                availablePartDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                availablePartDGV.DefaultCellStyle.SelectionBackColor = availablePartDGV.DefaultCellStyle.BackColor;
                availablePartDGV.DefaultCellStyle.SelectionForeColor = availablePartDGV.DefaultCellStyle.ForeColor;
                availablePartDGV.RowHeadersVisible = false;
                availablePartDGV.DataSource = Inventory.AllParts;
                //formatting for associatedPartDGV
                temp = Inventory.CurrentProduct;
                associatedPartDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                associatedPartDGV.DefaultCellStyle.SelectionBackColor = associatedPartDGV.DefaultCellStyle.BackColor;
                associatedPartDGV.DefaultCellStyle.SelectionForeColor = associatedPartDGV.DefaultCellStyle.ForeColor;
                associatedPartDGV.RowHeadersVisible = false;
                associatedPartDGV.DataSource = temp.AssociatedParts;
                //formatting for textboxes
                //populating textboxes
                productIDTextBox.Text = temp.ProductID.ToString();
                productNameTextBox.Text = temp.Name;
                productInventoryTextBox.Text = temp.InStock.ToString();
                productPriceTextBox.Text = temp.Price.ToString();
                productMaxTextBox.Text = temp.Max.ToString();
                productMinTextBox.Text = temp.Min.ToString();

            }

        }

        private void partSaveButton_Click(object sender, EventArgs e)
        {

        }

        private void productCancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryForm inventoryForm = new InventoryForm();
            inventoryForm.Show();
        }

        private void deletePartProductButton_Click(object sender, EventArgs e)
        {
            if (Inventory.CurrentAssociatedPartIndex >= 0)
            {
                if (temp.removeAssociatedPart(Inventory.CurrentAssociatedPartIndex))
                {
                    MessageBox.Show("Part was successfully deleted.");
                }
                else
                {
                    MessageBox.Show("Part may or may not have been successfully deleted.");
                }
                Inventory.CurrentAssociatedPartIndex = -1;
            }
            else
            {
                MessageBox.Show("Please select a part to delete.");
            }

        }

        private void addPartProductButton_Click(object sender, EventArgs e)
        {
            temp.addAssociatedPart(Inventory.CurrentPart);
            associatedPartDGV.DataSource = temp.AssociatedParts;
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
            Inventory.CurrentAssociatedPartIndex = e.RowIndex;
            Inventory.CurrentAssociatedPartID = (int)associatedPartDGV.Rows[Inventory.CurrentAssociatedPartIndex].Cells[0].Value;
            Inventory.CurrentAssociatedPart = temp.lookupAssociatedPart(Inventory.CurrentAssociatedPartID);
            associatedPartDGV.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
        }
    }
}
