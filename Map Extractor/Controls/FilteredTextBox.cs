/****************************************************************************************************
 * 
 *   Filename    : FilteredTextBox.cs
 *   
 *   Description : TextBox control that allows the developer to specify which characters are allowed
 *                 to be entered into the control and prevents the entry of any key not listed.
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Map_Extractor
{
    public class FilteredTextBox : TextBox
    {
        #region Properties
        private string allowedChars = "";

        [Description("Controls which characters are allowed to be entered in the edit control. Supercedes the DeniedChars list."), Category("Special"), DefaultValue("")]
        public string AllowedChars { get { return allowedChars; } set { allowedChars = value; } }

        [Browsable(false)]
        public Int32 Value
        {
            get
            {
                Int32 value = -1;

                if (Text != "")
                    Int32.TryParse(Text, out value);

                return value;
            }
            set
            {
                Text = (value != -1 ? value.ToString() : "");
            }
        }
        #endregion

        #region OnTextChanged
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (AllowedChars == "")
                return;

            List<char> invalid = new List<char>();

            foreach (char c in Text)
                if (AllowedChars.IndexOf(c) < 0 && !invalid.Contains(c))
                    invalid.Add(c);

            StringBuilder sb = new StringBuilder(Text);

            foreach (char c in invalid)
                sb.Replace(c.ToString(), "");

            Text = sb.ToString();
        }
        #endregion

        #region OnKeyPress
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == 8) // Backspace
            {
                e.Handled = false;
            }
            else if (AllowedChars != "")
            {
                e.Handled = true;

                foreach (char c in AllowedChars)
                    if (e.KeyChar == c)
                        e.Handled = false;
            }
        }
        #endregion
    }
}