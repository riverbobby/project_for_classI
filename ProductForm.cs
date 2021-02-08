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
            if (Inventory.CurrentProductIndex < 0) 
            {
                InitializeComponent();
                Inventory.CurrentPartIndex = -1;
                Inventory.CurrentAssociatedPartIndex = -1;
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
                associatedPartDGV.RowHeadersVisible = false;
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
                //populating temp.AssociatedParts with CurrentProduct contents
                for (int i = 0; i < Inventory.CurrentProduct.AssociatedParts.Count; i++)
                {
                    temp.addAssociatedPart(Inventory.CurrentProduct.AssociatedParts[i]);
                }
                //formatting for associatedPartDGV
                associatedPartDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                associatedPartDGV.DefaultCellStyle.SelectionBackColor = associatedPartDGV.DefaultCellStyle.BackColor;
                associatedPartDGV.DefaultCellStyle.SelectionForeColor = associatedPartDGV.DefaultCellStyle.ForeColor;
                associatedPartDGV.RowHeadersVisible = false;
                associatedPartDGV.DataSource = temp.AssociatedParts;
                //populating textboxes
                productIDTextBox.Text = Inventory.CurrentProduct.ProductID.ToString();
                productNameTextBox.Text = Inventory.CurrentProduct.Name;
                productInventoryTextBox.Text = Inventory.CurrentProduct.InStock.ToString();
                productPriceTextBox.Text = Inventory.CurrentProduct.Price.ToString();
                productMaxTextBox.Text = Inventory.CurrentProduct.Max.ToString();
                productMinTextBox.Text = Inventory.CurrentProduct.Min.ToString();

            }

        }

        private void productSaveButton_Click(object sender, EventArgs e)
        {
            string messageBuilder = "Please fix the following issues:\n";
            bool invalid = false;
            decimal numberDecimal;
            int numberMin = -2;
            int numberMax = -3;
            int numberInventory;
            //checking each field for validation
            //name
            if (string.IsNullOrWhiteSpace(productNameTextBox.Text))
            {
                invalid = true;
                messageBuilder += "Please enter a product name\n";
            }
            //price
            if (string.IsNullOrWhiteSpace(productPriceTextBox.Text) ||
            (!Decimal.TryParse(productPriceTextBox.Text, out numberDecimal)))
            {
                invalid = true;
                messageBuilder += "Please enter a valid price\n";
            }
            //min
            if (string.IsNullOrWhiteSpace(productMinTextBox.Text))
            {
                invalid = true;
                messageBuilder += "Please enter a min value\n";
            }
            else
            {
                if (!Int32.TryParse(productMinTextBox.Text, out numberMin))
                {
                    invalid = true;
                    messageBuilder += "Please enter a valid min value\n";
                }
            }
            //max
            if (string.IsNullOrWhiteSpace(productMaxTextBox.Text))
            {
                invalid = true;
                messageBuilder += "Please enter a max value\n";
            }
            else
            {
                if (!Int32.TryParse(productMaxTextBox.Text, out numberMax))
                {
                    invalid = true;
                    messageBuilder += "Please enter a valid min value\n";
                }
                else
                {
                    if (numberMax < numberMin)
                    {
                        invalid = true;
                        messageBuilder += "Please enter a max value greater than min value\n";
                    }
                }
            }
            //instock
            if (string.IsNullOrWhiteSpace(productInventoryTextBox.Text))
            {
                invalid = true;
                messageBuilder += "Please enter a inventory value\n";
            }
            else
            {
                if (!Int32.TryParse(productInventoryTextBox.Text, out numberInventory))
                {
                    invalid = true;
                    messageBuilder += "Please enter a valid inventory number value\n";
                }
                else
                {
                    if (numberInventory < numberMin || numberInventory > numberMax)
                    {
                        invalid = true;
                        messageBuilder += "Please enter an inventory number between min and max\n";
                    }
                }
            }
            //invalid path with messageBox
            if (invalid == true)
            {
                MessageBox.Show(messageBuilder);
            }
            //this path creates a new product or modifies an existing product
            else
            {
                //constructor called for new product and new product assigned to Products
                if (Inventory.CurrentProductIndex < 0)
                {
                    Inventory.addProduct(new Product(productNameTextBox.Text,
                        Decimal.Parse(productPriceTextBox.Text),
                        Int32.Parse(productInventoryTextBox.Text),
                        Int32.Parse(productMinTextBox.Text),
                        Int32.Parse(productMaxTextBox.Text)));
                    //copying contents of temp.AssociatedParts to new product
                    int index = Inventory.Products.Count - 1;
                    for (int i = 0; i < temp.AssociatedParts.Count; i++)
                    {
                        Inventory.Products[index].addAssociatedPart(temp.AssociatedParts[i]);
                    }

                }
                //constructor called for existing part and swapped for unmodified part in AllParts
                else
                {
                    Inventory.updateProduct(Inventory.CurrentProductIndex, 
                        new Product(Int32.Parse(productIDTextBox.Text),
                        productNameTextBox.Text,
                        Decimal.Parse(productPriceTextBox.Text),
                        Int32.Parse(productInventoryTextBox.Text),
                        Int32.Parse(productMinTextBox.Text),
                        Int32.Parse(productMaxTextBox.Text)));
                    //copying contents of temp.AssociatedParts to modified product
                    for (int i = 0; i < temp.AssociatedParts.Count; i++)
                    {
                        Inventory.Products[Inventory.CurrentProductIndex].addAssociatedPart(temp.AssociatedParts[i]);
                    }
                }
                this.Hide();
                InventoryForm inventoryForm = new InventoryForm();
                inventoryForm.Show();
            }

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
            if (Inventory.CurrentPartIndex >= 0)
            {
                temp.addAssociatedPart(Inventory.CurrentPart);
                associatedPartDGV.DataSource = temp.AssociatedParts;
            }
            else
            {
                MessageBox.Show("Please select a part to add");
            }
            
        }

        private void searchAvailablePartsButton_Click(object sender, EventArgs e)
        {
            availablePartDGV.ClearSelection();
            availablePartDGV.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            bool found = false;
            if (searchAvailablePartTextBox.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    if (Inventory.AllParts[i].Name.ToUpper().Contains(searchAvailablePartTextBox.Text.ToUpper()))
                    {
                        availablePartDGV.Rows[i].Selected = true;
                        found = true;
                    }
                }
                if (!found)
                {
                    MessageBox.Show("Nothing found");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please enter a part name to search");
            }

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
