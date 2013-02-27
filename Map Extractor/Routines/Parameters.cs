/****************************************************************************************************
 * 
 *   Filename    : Parameters.cs
 *   
 *   Description : Utility class that manages the application settings
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
using System.Drawing;
using System.Xml;

namespace Map_Extractor
{
    public class Parameters
    {
        #region Variables
        private static String _SourcePath = "";
        public static String SourcePath { get { return _SourcePath; } set { _SourcePath = value; } }

        private static String _DestinationPath = "";
        public static String DestinationPath { get { return _DestinationPath; } set { _DestinationPath = value; } }

        private static Int32 _SourceMap = -1;
        public static Int32 SourceMap { get { return _SourceMap; } set { _SourceMap = value; } }

        private static Int32 _DestinationMap = -1;
        public static Int32 DestinationMap { get { return _DestinationMap; } set { _DestinationMap = value; } }

        private static Boolean _CopyStatics = true;
        public static Boolean CopyStatics { get { return _CopyStatics; } set { _CopyStatics = value; } }

        private static Boolean _EntireMap = true;
        public static Boolean EntireMap { get { return _EntireMap; } set { _EntireMap = value; } }

        private static Rectangle _SourceArea = new Rectangle(-1, -1, -1, -1);
        public static Rectangle SourceArea { get { return _SourceArea; } set { _SourceArea = value; } }

        private static Point _DestinationLocation = new Point(-1, -1);
        public static Point DestinationLocation { get { return _DestinationLocation; } set { _DestinationLocation = value; } }

        private static Hashtable _ItemConversions = new Hashtable();
        public static Hashtable ItemConversions { get { return _ItemConversions; } set { _ItemConversions = value; } }

        public static Boolean CustomSource { get { return SourceMap == 8; } }

        private static Int32 _SourceFileIndex = -1;
        public static Int32 SourceFileIndex { get { return _SourceFileIndex; } set { _SourceFileIndex = value; } }

        private static Size _SourceSize = new Size(-1,-1);
        public static Size SourceSize { get { return _SourceSize; } set { _SourceSize = value; } }

        public static Boolean CustomDestination { get { return DestinationMap == 8; } }

        private static Int32 _DestinationFileIndex = -1;
        public static Int32 DestinationFileIndex { get { return _DestinationFileIndex; } set { _DestinationFileIndex = value; } }

        private static Size _DestinationSize = new Size(-1,-1);
        public static Size DestinationSize { get { return _DestinationSize; } set { _DestinationSize = value; } }
        #endregion

        #region LoadParameters
        public static void LoadParameters()
        {
            if (!System.IO.File.Exists("params.xml"))
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load("params.xml");

            XmlElement root = doc["Extractor"];

            if (root == null)
                return;

            SourcePath = ReadString(root["source"], "path");
            SourceMap = ReadInt32(root["source"], "index");
            EntireMap = ReadBoolean(root["source"], "copyall", true);

            Int32 x = ReadInt32(root["source"], "x");
            Int32 y = ReadInt32(root["source"], "y");
            Int32 w = ReadInt32(root["source"], "width");
            Int32 h = ReadInt32(root["source"], "height");
            SourceArea = new Rectangle(x, y, w, h);

            DestinationPath = ReadString(root["destination"], "path");
            DestinationMap = ReadInt32(root["destination"], "index");
            
            x = ReadInt32(root["destination"], "x");
            y = ReadInt32(root["destination"], "y");
            DestinationLocation = new Point(x, y);

            CopyStatics = ReadBoolean(root["statics"], "copy", true);

            SourceFileIndex = ReadInt32(root["custom_source"], "index");

            w = ReadInt32(root["custom_source"], "w");
            h = ReadInt32(root["custom_source"], "h");
            SourceSize = new Size(w, h);

            DestinationFileIndex = ReadInt32(root["custom_destination"], "index");

            w = ReadInt32(root["custom_destination"], "w");
            h = ReadInt32(root["custom_destination"], "h");
            DestinationSize = new Size(w, h);

            XmlElement conv = root["itemconversion"];

            if (conv != null)
            {
                foreach (XmlElement xmlConvert in conv.SelectNodes("convert"))
                {
                    UInt16 oldId = ReadUInt16(xmlConvert, "oldid");
                    UInt16 newId = ReadUInt16(xmlConvert, "newid");

                    ItemConversions[oldId] = newId;
                }
            }
        }
        #endregion

        #region SaveParameters
        public static void SaveParameters()
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter("params.xml", System.Text.Encoding.UTF8);

                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();

                writer.WriteStartElement("Extractor");

                if (SourcePath != "" || SourceMap != -1)
                {
                    writer.WriteStartElement("source");

                    if (SourcePath != "")
                    {
                        writer.WriteStartAttribute("path");
                        writer.WriteValue(SourcePath);
                        writer.WriteEndAttribute();
                    }

                    if (SourceMap != -1)
                    {
                        writer.WriteStartAttribute("index");
                        writer.WriteValue(SourceMap);
                        writer.WriteEndAttribute();
                    }

                    writer.WriteStartAttribute("copyall");
                    writer.WriteValue(EntireMap);
                    writer.WriteEndAttribute();

                    if (SourceArea.X != -1)
                    {
                        writer.WriteStartAttribute("x");
                        writer.WriteValue(SourceArea.X);
                        writer.WriteEndAttribute();
                    }

                    if (SourceArea.Y != -1)
                    {
                        writer.WriteStartAttribute("y");
                        writer.WriteValue(SourceArea.Y);
                        writer.WriteEndAttribute();
                    }

                    if (SourceArea.Width != -1)
                    {
                        writer.WriteStartAttribute("width");
                        writer.WriteValue(SourceArea.Width);
                        writer.WriteEndAttribute();
                    }

                    if (SourceArea.Height != -1)
                    {
                        writer.WriteStartAttribute("height");
                        writer.WriteValue(SourceArea.Height);
                        writer.WriteEndAttribute();
                    }

                    writer.WriteEndElement();
                }

                if (DestinationPath != "" || DestinationMap != -1)
                {
                    writer.WriteStartElement("destination");

                    if (DestinationPath != "")
                    {
                        writer.WriteStartAttribute("path");
                        writer.WriteValue(DestinationPath);
                        writer.WriteEndAttribute();
                    }

                    if (DestinationMap != -1)
                    {
                        writer.WriteStartAttribute("index");
                        writer.WriteValue(DestinationMap);
                        writer.WriteEndAttribute();
                    }

                    if (DestinationLocation.X != -1)
                    {
                        writer.WriteStartAttribute("x");
                        writer.WriteValue(DestinationLocation.X);
                        writer.WriteEndAttribute();
                    }

                    if (DestinationLocation.Y != -1)
                    {
                        writer.WriteStartAttribute("y");
                        writer.WriteValue(DestinationLocation.Y);
                        writer.WriteEndAttribute();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteStartElement("statics");
                writer.WriteStartAttribute("copy");
                writer.WriteValue(CopyStatics);
                writer.WriteEndAttribute();
                writer.WriteEndElement();

                writer.WriteStartElement("custom_source");

                writer.WriteStartAttribute("index");
                writer.WriteValue(SourceFileIndex);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("w");
                writer.WriteValue(SourceSize.Width);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("h");
                writer.WriteValue(SourceSize.Height);
                writer.WriteEndAttribute();

                writer.WriteEndElement();

                writer.WriteStartElement("custom_destination");

                writer.WriteStartAttribute("index");
                writer.WriteValue(DestinationFileIndex);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("w");
                writer.WriteValue(DestinationSize.Width);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("h");
                writer.WriteValue(DestinationSize.Height);
                writer.WriteEndAttribute();

                writer.WriteEndElement();

                if (ItemConversions.Count > 0)
                {
                    writer.WriteStartElement("itemconversion");

                    foreach (DictionaryEntry entry in ItemConversions)
                    {
                        writer.WriteStartElement("convert");

                        writer.WriteStartAttribute("oldid");
                        writer.WriteValue(entry.Key.ToString());
                        writer.WriteEndAttribute();

                        writer.WriteStartAttribute("newid");
                        writer.WriteValue(entry.Value.ToString());
                        writer.WriteEndAttribute();

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();

                writer.WriteEndDocument();

                writer.Close();
            }
            catch { }
        }
        #endregion

        #region GetAttribute
        protected static String GetAttribute(XmlElement xml, String attribute)
        {
            if (xml == null)
                return null;
            else if (xml.HasAttribute(attribute))
                return xml.GetAttribute(attribute);
            else
                return null;
        }
        #endregion

        #region ReadString
        protected static String ReadString(XmlElement xml, String attribute)
        {
            return GetAttribute(xml, attribute);
        }
        #endregion

        #region ReadInt32
        protected static Int32 ReadInt32(XmlElement xml, String attribute)
        {
            String s = GetAttribute(xml, attribute);

            if (s == null)
                return -1;

            try
            {
                return XmlConvert.ToInt32(s);
            }
            catch { }

            return 9999;
        }
        #endregion

        #region ReadUInt16
        protected static UInt16 ReadUInt16(XmlElement xml, String attribute)
        {
            String s = GetAttribute(xml, attribute);

            if (s == null)
                return 65535;

            try
            {
                return XmlConvert.ToUInt16(s);
            }
            catch { }

            return 65535;
        }
        #endregion

        #region ReadBoolean
        protected static Boolean ReadBoolean(XmlElement xml, String attribute, Boolean defaultValue)
        {
            String s = GetAttribute(xml, attribute);

            if (s == null)
                return defaultValue;

            try
            {
                return XmlConvert.ToBoolean(s);
            }
            catch { }

            return defaultValue;
        }
        #endregion
    }
}
