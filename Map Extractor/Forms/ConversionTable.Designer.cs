namespace Map_Extractor
{
    partial class ConversionTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConversionTable));
            this.label2 = new System.Windows.Forms.Label();
            this.staticsGrid = new System.Windows.Forms.DataGridView();
            this.SourceItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinationItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.staticsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Static Item ID Conversions";
            // 
            // staticsGrid
            // 
            this.staticsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.staticsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.staticsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SourceItemID,
            this.DestinationItemID});
            this.staticsGrid.Location = new System.Drawing.Point(6, 19);
            this.staticsGrid.MultiSelect = false;
            this.staticsGrid.Name = "staticsGrid";
            this.staticsGrid.Size = new System.Drawing.Size(335, 329);
            this.staticsGrid.TabIndex = 1;
            this.staticsGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.staticsGrid_KeyUp);
            // 
            // SourceItemID
            // 
            dataGridViewCellStyle1.Format = "N0";
            this.SourceItemID.DefaultCellStyle = dataGridViewCellStyle1;
            this.SourceItemID.HeaderText = "Source Item ID";
            this.SourceItemID.MaxInputLength = 5;
            this.SourceItemID.Name = "SourceItemID";
            this.SourceItemID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DestinationItemID
            // 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.DestinationItemID.DefaultCellStyle = dataGridViewCellStyle2;
            this.DestinationItemID.HeaderText = "Destination Item ID";
            this.DestinationItemID.MaxInputLength = 5;
            this.DestinationItemID.Name = "DestinationItemID";
            this.DestinationItemID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(87, 354);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 23);
            this.setButton.TabIndex = 2;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(180, 354);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ConversionTable
            // 
            this.AcceptButton = this.setButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(344, 379);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.staticsGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConversionTable";
            this.Text = "Statics Conversion Tables";
            ((System.ComponentModel.ISupportInitialize)(this.staticsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView staticsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinationItemID;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button cancelButton;

    }
}