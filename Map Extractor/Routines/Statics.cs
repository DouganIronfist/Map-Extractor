/****************************************************************************************************
 * 
 *   Filename    : Statics.cs
 *   
 *   Description : Utility class that manages the reading and writing of static files
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
    public class Statics
    {
        #region Variables
        private Int32 _fileIndex;
        public Int32 FileIndex { get { return _fileIndex; } }

        private Int32 _width;
        public Int32 Width { get { return _width; } }

        private Int32 _height;
        public Int32 Height { get { return _height; } }

        private FileStream fsIDX;
        private FileStream fsStatics;

        private Int32 position = 0;

        private Boolean _FileOpen = false;
        public Boolean FileOpen { get { return _FileOpen; } }
        #endregion

        #region Constructor
        public Statics(Int32 fileindex, Int32 width, Int32 height)
        {
            _fileIndex = fileindex;
            _width = width / 8;
            _height = height / 8;
        }
        #endregion

        #region OpenStatics
        public Boolean OpenStatics(String path, Boolean writing)
        {
            if (!writing)
            {
                if (!File.Exists(String.Format("{0}\\staidx{1}.mul", path, FileIndex)))
                    return false;

                if (!File.Exists(String.Format("{0}\\statics{1}.mul", path, FileIndex)))
                    return false;
            }

            FileMode mode = FileMode.Open;

            if (writing && Parameters.EntireMap)
                mode = FileMode.Create;
            else
                mode = FileMode.OpenOrCreate;

            try
            {
                fsIDX = new FileStream(String.Format("{0}\\staidx{1}.mul", path, FileIndex), mode, FileAccess.ReadWrite, FileShare.ReadWrite);
                fsStatics = new FileStream(String.Format("{0}\\statics{1}.mul", path, FileIndex), mode, FileAccess.ReadWrite, FileShare.ReadWrite);

                return (writing ? fsStatics.CanWrite : fsStatics.CanRead);
            }
            catch { return false; }
        }
        #endregion

        #region BackupStatics
        public void BackupStatics(String path)
        {
            _FileOpen = false;

            if (!File.Exists(String.Format("{0}\\staidx{1}.mul", path, FileIndex)))
                return;

            if (!File.Exists(String.Format("{0}\\statics{1}.mul", path, FileIndex)))
                return;

            if (File.Exists(String.Format("{0}\\staidx{1}.mul.bck", path, FileIndex)))
                File.Delete(String.Format("{0}\\staidx{1}.mul.bck", path, FileIndex));

            if (File.Exists(String.Format("{0}\\statics{1}.mul.bck", path, FileIndex)))
                File.Delete(String.Format("{0}\\statics{1}.mul.bck", path, FileIndex));

            File.Move(String.Format("{0}\\staidx{1}.mul", path, FileIndex), String.Format("{0}\\staidx{1}.mul.bck", path, FileIndex));
            File.Move(String.Format("{0}\\statics{1}.mul", path, FileIndex), String.Format("{0}\\statics{1}.mul.bck", path, FileIndex));

            FileMode mode = FileMode.Open;

            try
            {
                fsIDX = new FileStream(String.Format("{0}\\staidx{1}.mul.bck", path, FileIndex), mode, FileAccess.ReadWrite, FileShare.ReadWrite);
                fsStatics = new FileStream(String.Format("{0}\\statics{1}.mul.bck", path, FileIndex), mode, FileAccess.ReadWrite, FileShare.ReadWrite);

                if (fsStatics.CanRead && fsIDX.CanRead)
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
                fsIDX.Close();
                fsStatics.Close();
            }
            catch { }
        }
        #endregion

        #region ReadBlock
        public IDX ReadBlock(Int32 x, Int32 y)
        {
            try
            {
                fsIDX.Position = ((x * Height) + y) * 12;
                BinaryReader readerIDX = new BinaryReader(fsIDX);

                IDX idx = new IDX(readerIDX.ReadUInt32(), readerIDX.ReadUInt32(), readerIDX.ReadUInt32());

                if (idx.Start != 0xFFFFFFFF)
                {
                    idx.Statics = new StaticDef[idx.Length / 7];

                    fsStatics.Position = idx.Start;
                    BinaryReader readerStatics = new BinaryReader(fsStatics);

                    for (Int32 xx = 0; xx < idx.Statics.Length; xx++)
                    {
                        idx.Statics[xx] = new StaticDef(readerStatics.ReadUInt16(), readerStatics.ReadByte(), readerStatics.ReadByte(),
                            readerStatics.ReadSByte(), readerStatics.ReadInt16());

                        try
                        {
                            if (Parameters.ItemConversions[idx.Statics[xx].Color] != null)
                                idx.Statics[xx].Color = (UInt16)Parameters.ItemConversions[idx.Statics[xx].Color];
                        }
                        catch { }
                    }
                }

                Int32 realItems = 0;

                foreach (StaticDef sd in idx.Statics)
                    if (sd.Color != 65535)
                        realItems++;

                if (realItems != idx.Statics.Length)
                {
                    StaticDef[] newStatics = new StaticDef[realItems];
                    Int32 counter = 0;

                    foreach (StaticDef sd in idx.Statics)
                        if (sd.Color != 65535)
                        {
                            newStatics[counter] = sd;
                            counter++;
                        }

                    idx.Statics = newStatics;
                }

                return idx;
            }
            catch
            {
                return new IDX(0xFFFFFFFF, 0, 0);
            }
        }
        #endregion

        #region WriteBlock
        public void WriteBlock(IDX idx, Int32 x, Int32 y)
        {
            try
            {
                fsIDX.Position = ((x * Height) + y) * 12;
                BinaryWriter writerIDX = new BinaryWriter(fsIDX);

                writerIDX.Write((UInt32)position);
                writerIDX.Write((UInt32)(idx.Statics.Length * 7));
                writerIDX.Write((UInt32)idx.Trailer);

                fsStatics.Position = position;
                BinaryWriter writerStatics = new BinaryWriter(fsStatics);

                foreach (StaticDef sd in idx.Statics)
                {
                    writerStatics.Write((UInt16)sd.Color);
                    writerStatics.Write((Byte)sd.X);
                    writerStatics.Write((Byte)sd.Y);
                    writerStatics.Write((SByte)sd.Altitude);
                    writerStatics.Write((Int16)sd.Trailer);

                    position += 7;
                }
            }
            catch { }
        }
        #endregion

        #region WriteEmptyBlock
        public void WriteEmptyBlock(Int32 x, Int32 y)
        {
            WriteBlock(new IDX(0xFFFFFFFF, 0, 0), x, y);
        }
        #endregion

        #region ClearStaticArea
        public void ClearStaticArea()
        {
            if (Parameters.EntireMap)
                return;

            try
            {
                IDX[,] oldTiles = new IDX[Width, Height];

                for (Int32 x = 0; x < Width; x++)
                {
                    for (Int32 y = 0; y < Height; y++)
                    {
                        if (x >= Parameters.DestinationLocation.X && x < Parameters.DestinationLocation.X + Parameters.SourceArea.Width &&
                            y >= Parameters.DestinationLocation.Y && x < Parameters.DestinationLocation.Y + Parameters.SourceArea.Height)
                        {
                            oldTiles[x, y] = new IDX(0xFFFFFFFF, 0, 0);
                        }
                        else
                        {
                            oldTiles[x, y] = ReadBlock(x, y);
                        }
                    }
                }

                position = 0;


                for (Int32 x = 0; x < Width; x++)
                {
                    for (Int32 y = 0; y < Height; y++)
                    {
                        WriteBlock(oldTiles[x, y], x, y);
                    }
                }
            }
            catch { }
        }
        #endregion
    }
}