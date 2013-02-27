/****************************************************************************************************
 * 
 *   Filename    : ConversionTable.cs
 *   
 *   Description : Form used to allow the user to specify static ID conversions
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
using System.Collections;
using System.Windows.Forms;

namespace Map_Extractor
{
    public partial class ConversionTable : Form
    {
        #region Constructor
        public ConversionTable()
        {
            InitializeComponent();
        }
        #endregion

        #region Initialize
        public void Initialize()
        {
            foreach (DictionaryEntry entry in Parameters.ItemConversions)
                staticsGrid.Rows.Add(entry.Key.ToString(), ((UInt16)entry.Value != 65535 ? entry.Value.ToString(): ""));

            staticsGrid.Sort(SourceItemID, System.ComponentModel.ListSortDirection.Ascending);
        }
        #endregion

        #region setButton_Click
        private void setButton_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();

            foreach (DataGridViewRow row in staticsGrid.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                    {
                        UInt16 oldItem = Convert.ToUInt16(row.Cells[0].Value);
                        UInt16 newItem = 65535;

                        if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                            newItem = Convert.ToUInt16(row.Cells[1].Value);

                        ht[oldItem] = newItem;
                    }
                }
                catch { }
            }

            Parameters.ItemConversions = ht;

            Close();
        }
        #endregion

        #region cancelButton_Click
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region staticsGrid_KeyUp
        private void staticsGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                try { staticsGrid.Rows.Remove(staticsGrid.CurrentRow); e.Handled = true; }
                catch { }
            }

            if (e.KeyCode == Keys.Insert)
            {
                try
                {
                    Int32 index = staticsGrid.CurrentRow.Index;

                    staticsGrid.Rows.Insert(index, 1);

                    staticsGrid.CurrentCell = staticsGrid.Rows[index].Cells[0];
                    staticsGrid.Rows[index].Selected = true;

                    e.Handled = true;
                }
                catch { }
            }
        }
        #endregion
    }
}
