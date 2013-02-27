namespace Map_Extractor
{
    partial class DropDownBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resultDropDown = new DropDownArrow();
            this.result = new FilteredTextBox();
            this.SuspendLayout();
            // 
            // resultDropDown
            // 
            this.resultDropDown.Location = new System.Drawing.Point(100, 0);
            this.resultDropDown.MaximumSize = new System.Drawing.Size(20, 20);
            this.resultDropDown.MinimumSize = new System.Drawing.Size(20, 20);
            this.resultDropDown.Name = "resultDropDown";
            this.resultDropDown.Size = new System.Drawing.Size(20, 20);
            this.resultDropDown.TabIndex = 1;
            this.resultDropDown.TabStop = false;
            this.resultDropDown.Click += new System.EventHandler(this.resultDropDown_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(0, 0);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(100, 20);
            this.result.TabIndex = 0;
            this.result.TextChanged += new System.EventHandler(this.result_TextChanged);
            // 
            // SelectField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.result);
            this.Controls.Add(this.resultDropDown);
            this.Name = "SelectField";
            this.Size = new System.Drawing.Size(120, 20);
            this.Enter += new System.EventHandler(this.SelectField_Enter);
            this.Resize += new System.EventHandler(this.SelectField_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DropDownArrow resultDropDown;
        private FilteredTextBox result;
    }
}
