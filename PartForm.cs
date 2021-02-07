using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JustinTownleySoftwareI
{
    public partial class PartForm : Form
    {
        bool isInhouse;
        //form for adding a part
        public PartForm()
        {
            //If adding a new part Inventory.CurrentPartIndex will be -1
            if (Inventory.CurrentPartIndex == -1)
            {
                InitializeComponent();
                partIDTextBox.Text = "Created when Saved";
                inHouseRadioButton.Checked = true;
                partNameTextBox.BackColor = System.Drawing.Color.Crimson;
                partInventoryTextBox.BackColor = System.Drawing.Color.Crimson;
                partPriceTextBox.BackColor = System.Drawing.Color.Crimson;
                partMaxTextBox.BackColor = System.Drawing.Color.Crimson;
                partMinTextBox.BackColor = System.Drawing.Color.Crimson;
                partMachineCompanyTextBox.BackColor = System.Drawing.Color.Crimson;
            }
            //If modifying an existing part Inventory.CurrentPartIndex will have a value >=0
            else
            {
                InitializeComponent();
                partIDTextBox.Text = Inventory.CurrentPart.PartID.ToString();
                partNameTextBox.Text = Inventory.CurrentPart.Name;
                partInventoryTextBox.Text = Inventory.CurrentPart.InStock.ToString();
                partPriceTextBox.Text = Inventory.CurrentPart.Price.ToString();
                partMaxTextBox.Text = Inventory.CurrentPart.Max.ToString();
                partMinTextBox.Text = Inventory.CurrentPart.Min.ToString();
                if (Inventory.CurrentPart is Inhouse)
                {
                    Inhouse p = (Inhouse)Inventory.CurrentPart;
                    isInhouse = true;
                    inHouseRadioButton.Checked = true;
                    partMachineCompanyTextBox.Text = p.MachineID.ToString();
                }
                else
                {
                    Outsourced p = (Outsourced)Inventory.CurrentPart;
                    isInhouse = false;
                    outsourcedRadioButton.Checked = true;
                    partMachineCompanyTextBox.Text = p.CompanyName;
                    machineCompanyLabel.Text = "Company Name";
                }


            }
        }

        private void inHouseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isInhouse = true;
            machineCompanyLabel.Text = "Machine ID";
        }

        private void outsourcedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isInhouse = false;
            machineCompanyLabel.Text = "Company Name";
        }

        private void partNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(partNameTextBox.Text))
            {
                partNameTextBox.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                partNameTextBox.BackColor = System.Drawing.Color.White;
            }
        }

        private void partInventoryTextBox_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (string.IsNullOrWhiteSpace(partInventoryTextBox.Text) || 
                (!Int32.TryParse(partInventoryTextBox.Text, out number)))
            {
                partInventoryTextBox.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                partInventoryTextBox.BackColor = System.Drawing.Color.White;
            }
        }

        private void partPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal number;
            if (string.IsNullOrWhiteSpace(partPriceTextBox.Text) ||
            (!Decimal.TryParse(partPriceTextBox.Text, out number)))
            {
                partPriceTextBox.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                partPriceTextBox.BackColor = System.Drawing.Color.White;
            }
        }

        private void partMaxTextBox_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (string.IsNullOrWhiteSpace(partMaxTextBox.Text) ||
            (!Int32.TryParse(partMaxTextBox.Text, out number)))
            {
                partMaxTextBox.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                partMaxTextBox.BackColor = System.Drawing.Color.White;
            }
        }

        private void partMinTextBox_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (string.IsNullOrWhiteSpace(partMinTextBox.Text) ||
            (!Int32.TryParse(partMinTextBox.Text, out number)))
            {
                partMinTextBox.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                partMinTextBox.BackColor = System.Drawing.Color.White;
            }
        }

        private void partMachineCompanyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isInhouse == true)
            {
                int number;
                if (string.IsNullOrWhiteSpace(partMachineCompanyTextBox.Text) ||
                (!Int32.TryParse(partMachineCompanyTextBox.Text, out number)))
                {
                    partMachineCompanyTextBox.BackColor = System.Drawing.Color.Crimson;
                }
                else
                {
                    partMachineCompanyTextBox.BackColor = System.Drawing.Color.White;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(partMachineCompanyTextBox.Text))
                {
                    partMachineCompanyTextBox.BackColor = System.Drawing.Color.Crimson;
                }
                else
                {
                    partMachineCompanyTextBox.BackColor = System.Drawing.Color.White;
                }
            }
        }

        private void partSaveButton_Click(object sender, EventArgs e)
        {
            string messageBuilder ="Please fix the following issues:\n";
            bool invalid = false;
            decimal numberDecimal;
            int numberMin = -2;
            int numberMax = -3;
            int numberInventory;
            int numberMachineID;
            //checking each field for validation
            //name
            if (string.IsNullOrWhiteSpace(partNameTextBox.Text))
            {
                invalid = true;
                messageBuilder += "Please enter a part name\n";
            }
            //price
            if (string.IsNullOrWhiteSpace(partPriceTextBox.Text) ||
            (!Decimal.TryParse(partPriceTextBox.Text, out numberDecimal)))
            {
                invalid = true;
                messageBuilder += "Please enter a valid price\n";
            }            
            //min
            if (string.IsNullOrWhiteSpace(partMinTextBox.Text))
            {
                invalid = true;
                messageBuilder += "Please enter a min value\n";
            }
            else
            {
                if (!Int32.TryParse(partMinTextBox.Text, out numberMin))
                {
                    invalid = true;
                    messageBuilder += "Please enter a valid min value\n";
                }
            }
            //max
            if (string.IsNullOrWhiteSpace(partMaxTextBox.Text))
            {
                invalid = true;
                messageBuilder += "Please enter a max value\n";
            }
            else
            {
                if (!Int32.TryParse(partMaxTextBox.Text, out numberMax))
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
            if (string.IsNullOrWhiteSpace(partInventoryTextBox.Text))
            {
                invalid = true;
                messageBuilder += "Please enter a inventory value\n";
            }
            else
            {
                if (!Int32.TryParse(partInventoryTextBox.Text, out numberInventory))
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
            if (isInhouse == true)
            {
                 if (string.IsNullOrWhiteSpace(partMachineCompanyTextBox.Text)) 
                 {
                    invalid = true;
                    messageBuilder += "Please enter a Machine ID\n";
                 }
                 else
                {
                     if (!Int32.TryParse(partInventoryTextBox.Text, out numberMachineID))
                     {
                        invalid = true;
                        messageBuilder += "Please enter a number in Machine ID";
                     }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(partMachineCompanyTextBox.Text))
                {
                    invalid = true;
                    messageBuilder += "Please enter a Company Name";
                }
            }

            //invalid path with messageBox
            if (invalid == true)
            {
                MessageBox.Show(messageBuilder);
            }
            //this path creates a new part or modifies an existing part
            else
            {
                //constructor called for new part and new part assigned to AllParts
                if (Inventory.CurrentPartIndex < 0)
                {
                    //for testing
                    MessageBox.Show("New Part Constructor Called");
                }
                //constructor called for existing part and swapped for unmodified part in AllParts
                else
                {
                    //for testing
                    MessageBox.Show("Existing New Part Constructor Called");
                }
                //this.Hide();
                //InventoryForm inventoryForm = new InventoryForm();
                //inventoryForm.Show();
            }
        }

        private void partCancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryForm inventoryForm = new InventoryForm();
            inventoryForm.Show();
        }
    }
}
