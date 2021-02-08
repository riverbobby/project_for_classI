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
            //partsDVG formatting
            Inventory.CurrentPartIndex = -1;
            partsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            partsDGV.DefaultCellStyle.SelectionBackColor = partsDGV.DefaultCellStyle.BackColor;
            partsDGV.DefaultCellStyle.SelectionForeColor = partsDGV.DefaultCellStyle.ForeColor;
            partsDGV.RowHeadersVisible = false;
            partsDGV.DataSource = Inventory.AllParts;
            //productDVG formatting
            Inventory.CurrentProductIndex = -1;
            productDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productDGV.DefaultCellStyle.SelectionBackColor = productDGV.DefaultCellStyle.BackColor;
            productDGV.DefaultCellStyle.SelectionForeColor = productDGV.DefaultCellStyle.ForeColor;
            productDGV.RowHeadersVisible = false;
            productDGV.DataSource = Inventory.Products;
        }

        private void partsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventory.CurrentPartIndex = e.RowIndex;
            Inventory.CurrentPartID = (int)partsDGV.Rows[Inventory.CurrentPartIndex].Cells[0].Value;
            Inventory.CurrentPart = Inventory.lookupPart(Inventory.CurrentPartID);
            partsDGV.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
        }
        private void addPartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory.CurrentPartIndex = -1;
            PartForm partForm = new PartForm();
            partForm.Show();
        }
        private void modifyPartButton_Click(object sender, EventArgs e)
        {
            if (Inventory.CurrentPartIndex >=0)
            {
                this.Hide();
                PartForm partForm = new PartForm();
                partForm.Show();

            }
            else
            {
                MessageBox.Show("Please select a part to modify.");
            }
        }
        private void deletePartButton_Click(object sender, EventArgs e)
        {
            if (Inventory.CurrentPartIndex >= 0)
            {
                if (Inventory.deletePart(Inventory.CurrentPartIndex))
                {
                    MessageBox.Show("Part was successfully deleted.");
                }
                else
                {
                    MessageBox.Show("Part may or may not have been successfully deleted.");
                }
                Inventory.CurrentPartIndex = -1;
            }
            else
            {
                MessageBox.Show("Please select a part to delete.");
            }
        }

        private void searchPartsButton_Click(object sender, EventArgs e)
        {
            partsDGV.ClearSelection();
            partsDGV.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            bool found = false;
            if (searchPartTextBox.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    if (Inventory.AllParts[i].Name.ToUpper().Contains(searchPartTextBox.Text.ToUpper()))
                    {
                        partsDGV.Rows[i].Selected = true;
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
        private void productDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventory.CurrentProductIndex = e.RowIndex;
            Inventory.CurrentProductID = (int)productDGV.Rows[Inventory.CurrentProductIndex].Cells[0].Value;
            Inventory.CurrentProduct = Inventory.lookupProduct(Inventory.CurrentProductID);
            productDGV.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;

        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory.CurrentProductIndex = -1;
            ProductForm productForm = new ProductForm();
            productForm.Show();
        }

        private void modifyProductButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm productForm = new ProductForm();
            productForm.Show();
        }
        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            if (Inventory.CurrentProductIndex >= 0)
            {
                if (Inventory.CurrentProduct.AssociatedParts.Count == 0)
                {
                    if (Inventory.removeProduct(Inventory.CurrentProductIndex))
                    {
                        MessageBox.Show("Product was deleted!");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Product may or may not have been deleted!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("A Product with associated parts cannot be deleted!");
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("Please select a product to be deleted.");
            }
        }
        private void searchProductButton_Click(object sender, EventArgs e)
        {
            productDGV.ClearSelection();
            productDGV.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            bool found = false;
            if (searchProductTextBox.Text != "")
            {
                for (int i = 0; i < Inventory.Products.Count; i++)
                {
                    if (Inventory.Products[i].Name.ToUpper().Contains(searchProductTextBox.Text.ToUpper()))
                    {
                        productDGV.Rows[i].Selected = true;
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
                MessageBox.Show("Please enter a product name to search");
            }
        }

        private void exitProgramButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
