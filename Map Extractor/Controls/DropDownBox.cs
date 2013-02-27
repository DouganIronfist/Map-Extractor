/****************************************************************************************************
 * 
 *   Filename    : DropDownBox.cs
 *   
 *   Description : Customizable dropdown box with filtered input
 *
 *   Copyright (C) 2013  Dougan Ironfist
 *
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *   
 ***************************************************************************************************/

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Map_Extractor
{
    public partial class DropDownBox : UserControl
    {
        #region Properties
        [Description("Gets or sets the specific characters that will be eliminated from user input if DENY is not set"), Category("Special"), DefaultValue("")]
        public String AllowedChars { get { return result.AllowedChars; } set { result.AllowedChars = value; } }

        [Description("Gets or sets the option to control whether the textbox is enabled"), Category("Behavior"), DefaultValue(true)]
        public Boolean TextEnabled { get { return result.Enabled; } set { result.Enabled = value; } }

        [Description("Gets or sets the maximum length of the text that can be entered"), Category("Behavior"), DefaultValue(32767)]
        public Int32 MaxLength { get { return result.MaxLength; } set { result.MaxLength = value; } }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        public override String Text { get { return result.Text; } set { result.Text = value; } }

        [Description("Event fired when the DropDown is clicked"), Category("Custom")]
        public event EventHandler DropDownClicked;

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        [Description("Event raised when the value of the Text property is changed on Control"), Category("Property Changed")]
        public new event EventHandler TextChanged;
        #endregion

        #region Constructor
        public DropDownBox()
        {
            InitializeComponent();
        }
        #endregion

        #region resultDropDown_Click
        internal void resultDropDown_Click(object sender, EventArgs e)
        {
            if (DropDownClicked != null)
                DropDownClicked(this, e);
        }
        #endregion

        #region SelectField_Resize
        private void SelectField_Resize(object sender, EventArgs e)
        {
            result.Width = this.Width - 20;
            resultDropDown.Left = result.Width;
        }
        #endregion

        #region SelectField_Enter
        private void SelectField_Enter(object sender, EventArgs e)
        {
            result.Focus();
        }
        #endregion

        #region SelectAll
        public void SelectAll()
        {
            result.SelectAll();
        }
        #endregion

        #region result_TextChanged
        private void result_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
                TextChanged(this, e);
        }
        #endregion
    }
}
