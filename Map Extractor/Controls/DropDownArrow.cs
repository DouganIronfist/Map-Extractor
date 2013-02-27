/****************************************************************************************************
 * 
 *   Filename    : DropDownArrow.cs
 *   
 *   Description : DropDown Arrow usable in other components
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
    [DefaultEvent("Click")]
    public partial class DropDownArrow : UserControl
    {
        #region Constructor
        public DropDownArrow()
        {
            InitializeComponent();

            // Define operating parameters
            SetStyle(ControlStyles.FixedHeight, true);
            SetStyle(ControlStyles.FixedWidth, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.StandardClick, true);
            SetStyle(ControlStyles.StandardDoubleClick, false);
            SetStyle(ControlStyles.UserMouse, true);
            SetStyle(ControlStyles.UserPaint, true);

            // Prevent tabbing to this control
            this.TabStop = false;
        }
    #endregion

        #region Variables
        // Determines if the mouse button is currently being pressed
        private Boolean _pressed = false;
        #endregion

        #region OnMouseDown
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Indicate that the mouse button is currently being pressed
            _pressed = true;

            // Redraw the control
            Invalidate();

            // Perform standard functions
            base.OnMouseDown(e);
        }
        #endregion

        #region OnMouseUp
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Perform standard functions
            base.OnMouseUp(e);

            // Indicate that the mouse button is no longer being pressed
            _pressed = false;

            // Redraw the control
            Invalidate();
        }
        #endregion

        #region OnPaint
        protected override void OnPaint(PaintEventArgs e)
        {
            // Perform standard functions
            base.OnPaint(e);

            // Set the state to not clicked
            ButtonState _state = ButtonState.Normal;

            // If the mouse button is currently being pressed, set the state to clicked
            if (_pressed)
                _state = ButtonState.Pushed;

            // Draw a combo button for the specified button state
            ControlPaint.DrawComboButton(e.Graphics, ClientRectangle, _state);
        }
        #endregion

        #region OnClick
        /// <summary>
        /// Send a click event for this control
        /// </summary>
        internal void OnClick()
        {
            // Send the click event
            InvokeOnClick(this, new EventArgs());
        }
        #endregion
    }
}
