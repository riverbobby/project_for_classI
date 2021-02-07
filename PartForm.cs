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
                partIDTextBox.Text = "000";
                inHouseRadioButton.Checked = true;
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
        
    }
}
