/****************************************************************************************************
 * 
 *   Filename    : Map.cs
 *   
 *   Description : Utility class that manages the reading and writing of map files
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
using System.IO;

namespace Map_Extractor
{
    public class Map
    {
        #region Variables
        private Int32 _fileIndex;
        public Int32 FileIndex { get { return _fileIndex; } }

        private Int32 _width;
        public Int32 Width { get { return _width; } }

        private Int32 _height;
        public Int32 Height { get { return _height; } }

        private FileStream fs;

        private Boolean _FileOpen = false;
        public Boolean FileOpen { get { return _FileOpen; } }
        #endregion

        #region Constructor
        public Map(Int32 fileindex, Int32 width, Int32 height)
        {
            _fileIndex = fileindex;
            _width = width / 8;
            _height = height / 8;
        }
        #endregion

        #region OpenMap
        public Boolean OpenMap(String path, Boolean writing)
        {
            if (!writing)
            {
                if (!File.Exists(String.Format("{0}\\map{1}.mul", path, FileIndex)))
                    return false;
            }

            FileMode mode = FileMode.Open;

            if (writing && Parameters.EntireMap)
                mode = FileMode.Create;
            else
                mode = FileMode.OpenOrCreate;

            try
            {
                fs = new FileStream(String.Format("{0}\\map{1}.mul", path, FileIndex), mode, FileAccess.ReadWrite, FileShare.ReadWrite);

                return (writing ? fs.CanWrite : fs.CanRead);
            }
            catch { return false; }
        }
        #endregion

        #region BackupMap
        public void BackupMap(String path)
        {
            _FileOpen = false;

            if (!File.Exists(String.Format("{0}\\map{1}.mul", path, FileIndex)))
                return;

            if (File.Exists(String.Format("{0}\\map{1}.mul.bck", path, FileIndex)))
                File.Delete(String.Format("{0}\\map{1}.mul.bck", path, FileIndex));

            File.Move(String.Format("{0}\\map{1}.mul", path, FileIndex), String.Format("{0}\\map{1}.mul.bck", path, FileIndex));

            FileMode mode = FileMode.Open;

            try
            {
                fs = new FileStream(String.Format("{0}\\map{1}.mul.bck", path, FileIndex), mode, FileAccess.ReadWrite, FileShare.ReadWrite);

                if (fs.CanRead)
                    _FileOpen = true;
            }
            catch { }
        }
        #endregion

        #region Close
        public void Close()
        {
            _FileOpen = false;

            try
            {
                fs.Close();
            }
            catch { }
        }
        #endregion

        #region ReadBlock
        public Block ReadBlock(Int32 x, Int32 y)
        {
            try
            {
                fs.Position = ((x * Height) + y) * 196;
                BinaryReader reader = new BinaryReader(fs);

                Block b = new Block();
                b.Cells = new Cell[8, 8];

                b.Header = reader.ReadInt32();

                for (Int32 xx = 0; xx < 8; xx++)
                    for (Int32 yy = 0; yy < 8; yy++)
                        b.Cells[xx, yy] = new Cell(reader.ReadUInt16(), reader.ReadSByte());

                return b;
            }
            catch
            {
                return new Block(); 
            }
        }
        #endregion

        #region WriteBlock
        public void WriteBlock(Block b, Int32 x, Int32 y)
        {
            try
            {
                fs.Position = ((x * Height) + y) * 196;
                BinaryWriter writer = new BinaryWriter(fs);

                writer.Write((Int32)b.Header);

                for (Int32 xx = 0; xx < 8; xx++)
                {
                    for (Int32 yy = 0; yy < 8; yy++)
                    {
                        writer.Write((UInt16)b.Cells[xx, yy].Color);
                        writer.Write((SByte)b.Cells[xx, yy].Altitude);
                    }
                }
            }
            catch { }
        }
        #endregion

        #region WriteEmptyBlock
        public void WriteEmptyBlock(Int32 x, Int32 y)
        {
            Block b = new Block();
            b.Cells = new Cell[8, 8];

            b.Header = 0;

            for (Int32 xx = 0; xx < 8; xx++)
            {
                for (Int32 yy = 0; yy < 8; yy++)
                {
                    b.Cells[xx, yy] = new Cell(580, 0);
                }
            }

            WriteBlock(b, x, y);
        }
        #endregion
    }
}
