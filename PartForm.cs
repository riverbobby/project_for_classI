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
    }
}
