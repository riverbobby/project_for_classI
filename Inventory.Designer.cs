
namespace JustinTownleySoftwareI
{
    partial class Inventory
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.partsDGV = new System.Windows.Forms.DataGridView();
            this.productDGV = new System.Windows.Forms.DataGridView();
            this.searchPartTextBox = new System.Windows.Forms.TextBox();
            this.searchProductTextBox = new System.Windows.Forms.TextBox();
            this.searchPartsButton = new System.Windows.Forms.Button();
            this.searchProductButton = new System.Windows.Forms.Button();
            this.addPartButton = new System.Windows.Forms.Button();
            this.modifyPartButton = new System.Windows.Forms.Button();
            this.deletePartButton = new System.Windows.Forms.Button();
            this.deleteProductButton = new System.Windows.Forms.Button();
            this.modifyProductButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.exitProgramButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.partsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventory Management System";
            // 
            // partsDGV
            // 
            this.partsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsDGV.Location = new System.Drawing.Point(37, 89);
            this.partsDGV.Name = "partsDGV";
            this.partsDGV.RowTemplate.Height = 25;
            this.partsDGV.Size = new System.Drawing.Size(582, 345);
            this.partsDGV.TabIndex = 1;
            // 
            // productDGV
            // 
            this.productDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDGV.Location = new System.Drawing.Point(668, 89);
            this.productDGV.Name = "productDGV";
            this.productDGV.RowTemplate.Height = 25;
            this.productDGV.Size = new System.Drawing.Size(582, 345);
            this.productDGV.TabIndex = 2;
            // 
            // searchPartTextBox
            // 
            this.searchPartTextBox.Location = new System.Drawing.Point(426, 49);
            this.searchPartTextBox.Name = "searchPartTextBox";
            this.searchPartTextBox.Size = new System.Drawing.Size(193, 23);
            this.searchPartTextBox.TabIndex = 3;
            // 
            // searchProductTextBox
            // 
            this.searchProductTextBox.Location = new System.Drawing.Point(1057, 49);
            this.searchProductTextBox.Name = "searchProductTextBox";
            this.searchProductTextBox.Size = new System.Drawing.Size(193, 23);
            this.searchProductTextBox.TabIndex = 4;
            // 
            // searchPartsButton
            // 
            this.searchPartsButton.Location = new System.Drawing.Point(327, 49);
            this.searchPartsButton.Name = "searchPartsButton";
            this.searchPartsButton.Size = new System.Drawing.Size(75, 23);
            this.searchPartsButton.TabIndex = 5;
            this.searchPartsButton.Text = "Search";
            this.searchPartsButton.UseVisualStyleBackColor = true;
            // 
            // searchProductButton
            // 
            this.searchProductButton.Location = new System.Drawing.Point(959, 48);
            this.searchProductButton.Name = "searchProductButton";
            this.searchProductButton.Size = new System.Drawing.Size(75, 23);
            this.searchProductButton.TabIndex = 6;
            this.searchProductButton.Text = "Search";
            this.searchProductButton.UseVisualStyleBackColor = true;
            // 
            // addPartButton
            // 
            this.addPartButton.Location = new System.Drawing.Point(382, 451);
            this.addPartButton.Name = "addPartButton";
            this.addPartButton.Size = new System.Drawing.Size(75, 34);
            this.addPartButton.TabIndex = 7;
            this.addPartButton.Text = "Add";
            this.addPartButton.UseVisualStyleBackColor = true;
            // 
            // modifyPartButton
            // 
            this.modifyPartButton.Location = new System.Drawing.Point(463, 451);
            this.modifyPartButton.Name = "modifyPartButton";
            this.modifyPartButton.Size = new System.Drawing.Size(75, 34);
            this.modifyPartButton.TabIndex = 8;
            this.modifyPartButton.Text = "Modify";
            this.modifyPartButton.UseVisualStyleBackColor = true;
            // 
            // deletePartButton
            // 
            this.deletePartButton.Location = new System.Drawing.Point(544, 451);
            this.deletePartButton.Name = "deletePartButton";
            this.deletePartButton.Size = new System.Drawing.Size(75, 34);
            this.deletePartButton.TabIndex = 9;
            this.deletePartButton.Text = "Delete";
            this.deletePartButton.UseVisualStyleBackColor = true;
            // 
            // deleteProductButton
            // 
            this.deleteProductButton.Location = new System.Drawing.Point(1175, 451);
            this.deleteProductButton.Name = "deleteProductButton";
            this.deleteProductButton.Size = new System.Drawing.Size(75, 34);
            this.deleteProductButton.TabIndex = 10;
            this.deleteProductButton.Text = "Delete";
            this.deleteProductButton.UseVisualStyleBackColor = true;
            // 
            // modifyProductButton
            // 
            this.modifyProductButton.Location = new System.Drawing.Point(1094, 451);
            this.modifyProductButton.Name = "modifyProductButton";
            this.modifyProductButton.Size = new System.Drawing.Size(75, 34);
            this.modifyProductButton.TabIndex = 11;
            this.modifyProductButton.Text = "Modify";
            this.modifyProductButton.UseVisualStyleBackColor = true;
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(1013, 451);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(75, 34);
            this.addProductButton.TabIndex = 12;
            this.addProductButton.Text = "Add";
            this.addProductButton.UseVisualStyleBackColor = true;
            // 
            // exitProgramButton
            // 
            this.exitProgramButton.Location = new System.Drawing.Point(1175, 506);
            this.exitProgramButton.Name = "exitProgramButton";
            this.exitProgramButton.Size = new System.Drawing.Size(75, 34);
            this.exitProgramButton.TabIndex = 13;
            this.exitProgramButton.Text = "Exit";
            this.exitProgramButton.UseVisualStyleBackColor = true;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 580);
            this.Controls.Add(this.exitProgramButton);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.modifyProductButton);
            this.Controls.Add(this.deleteProductButton);
            this.Controls.Add(this.deletePartButton);
            this.Controls.Add(this.modifyPartButton);
            this.Controls.Add(this.addPartButton);
            this.Controls.Add(this.searchProductButton);
            this.Controls.Add(this.searchPartsButton);
            this.Controls.Add(this.searchProductTextBox);
            this.Controls.Add(this.searchPartTextBox);
            this.Controls.Add(this.productDGV);
            this.Controls.Add(this.partsDGV);
            this.Controls.Add(this.label1);
            this.Name = "Inventory";
            this.Text = "Main Screen";
            ((System.ComponentModel.ISupportInitialize)(this.partsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView partsDGV;
        private System.Windows.Forms.DataGridView productDGV;
        private System.Windows.Forms.TextBox searchPartTextBox;
        private System.Windows.Forms.TextBox searchProductTextBox;
        private System.Windows.Forms.Button searchPartsButton;
        private System.Windows.Forms.Button searchProductButton;
        private System.Windows.Forms.Button addPartButton;
        private System.Windows.Forms.Button modifyPartButton;
        private System.Windows.Forms.Button deletePartButton;
        private System.Windows.Forms.Button deleteProductButton;
        private System.Windows.Forms.Button modifyProductButton;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Button exitProgramButton;
    }
}

