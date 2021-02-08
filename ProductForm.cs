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
                productIDTextBox.Text = "Created when Saved";
                productNameTextBox.BackColor = System.Drawing.Color.Crimson;
                productInventoryTextBox.BackColor = System.Drawing.Color.Crimson;
                productPriceTextBox.BackColor = System.Drawing.Color.Crimson;
                productMaxTextBox.BackColor = System.Drawing.Color.Crimson;
                productMinTextBox.BackColor = System.Drawing.Color.Crimson;
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
                for (int i = 0; i < Inventory.CurrentProduct.AssociatedParts.Count; i++)
                {
                    temp.addAssociatedPart(Inventory.CurrentProduct.AssociatedParts[i]);
                }
                associatedPartDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                associatedPartDGV.DefaultCellStyle.SelectionBackColor = associatedPartDGV.DefaultCellStyle.BackColor;
                associatedPartDGV.DefaultCellStyle.SelectionForeColor = associatedPartDGV.DefaultCellStyle.ForeColor;
                associatedPartDGV.RowHeadersVisible = false;
                associatedPartDGV.DataSource = temp.AssociatedParts;
                //formatting for textboxes
                //populating textboxes
                productIDTextBox.Text = Inventory.CurrentProduct.ProductID.ToString();
                productNameTextBox.Text = Inventory.CurrentProduct.Name;
                productInventoryTextBox.Text = Inventory.CurrentProduct.InStock.ToString();
                productPriceTextBox.Text = Inventory.CurrentProduct.Price.ToString();
                productMaxTextBox.Text = Inventory.CurrentProduct.Max.ToString();
                productMinTextBox.Text = Inventory.CurrentProduct.Min.ToString();

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

        private void productNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productNameTextBox.Text))
            {
                productNameTextBox.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                productNameTextBox.BackColor = System.Drawing.Color.White;
            }
        }

        private void productInventoryTextBox_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (string.IsNullOrWhiteSpace(productInventoryTextBox.Text) ||
                (!Int32.TryParse(productInventoryTextBox.Text, out number)))
            {
                productInventoryTextBox.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                productInventoryTextBox.BackColor = System.Drawing.Color.White;
            }
        }

        private void productPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal number;
            if (string.IsNullOrWhiteSpace(productPriceTextBox.Text) ||
            (!Decimal.TryParse(productPriceTextBox.Text, out number)))
            {
                productPriceTextBox.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                productPriceTextBox.BackColor = System.Drawing.Color.White;
            }
        }

        private void productMaxTextBox_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (string.IsNullOrWhiteSpace(productMaxTextBox.Text) ||
            (!Int32.TryParse(productMaxTextBox.Text, out number)))
            {
                productMaxTextBox.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                productMaxTextBox.BackColor = System.Drawing.Color.White;
            }
        }

        private void productMinTextBox_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (string.IsNullOrWhiteSpace(productMinTextBox.Text) ||
            (!Int32.TryParse(productMinTextBox.Text, out number)))
            {
                productMinTextBox.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                productMinTextBox.BackColor = System.Drawing.Color.White;
            }
        }
    }
}
