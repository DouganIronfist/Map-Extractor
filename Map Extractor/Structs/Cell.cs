/****************************************************************************************************
 * 
 *   Filename    : Cell.cs
 *   
 *   Description : Data structure that contains file cell information
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

namespace Map_Extractor
{
    public struct Cell
    {
        private UInt16 _Color;
        public UInt16 Color { get { return _Color; } set { _Color = value; } }

        private SByte _Altitude;
        public SByte Altitude { get { return _Altitude; } set { _Altitude = value; } }

        public Cell(UInt16 color, SByte altitude)
        {
            _Color = color;
            _Altitude = altitude;
        }
    }
}
