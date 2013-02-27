/****************************************************************************************************
 * 
 *   Filename    : IDX.cs
 *   
 *   Description : Data structure that contains file index information
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
    public struct IDX
    {
        private UInt32 _Start;
        public UInt32 Start { get { return _Start; } }

        private UInt32 _Length;
        public UInt32 Length { get { return _Length; } }

        private UInt32 _Trailer;
        public UInt32 Trailer { get { return _Trailer; } }

        private StaticDef[] _Statics;
        public StaticDef[] Statics { get { return _Statics; } set { _Statics = value; } }

        public IDX(UInt32 start, UInt32 length, UInt32 trailer)
        {
            _Start = start;
            _Length = length;
            _Trailer = trailer;
            _Statics = new StaticDef[0];
        }
    }
}
