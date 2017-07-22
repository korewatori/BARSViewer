using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BARSViewer
{
    public class BMETA
    {

        public header hdr = new header();
        public List<byte[]> amtaData = new List<byte[]>();
        public List<byte[]> fwavData = new List<byte[]>();
        public List<STRG> strgList = new List<STRG>();

        public class header
        {
            public char[] id;
            public UInt32 size;
            public UInt16 BOM;
            public byte unknown1;
            public byte unknown2;
            public UInt32 amtaCount;
            public List<UInt32> hashes = new List<UInt32>();
            public List<UInt32> offsets = new List<UInt32>();

            public void parseHeader(BinaryReader br)
            {
                id = br.ReadChars(4);
                if (new string(id) != "BARS") throw new Exception("Invalid file.");
                size = br.ReadUInt32();
                BOM = br.ReadUInt16();
                unknown1 = br.ReadByte();
                unknown2 = br.ReadByte();
                amtaCount = br.ReadUInt32();
                for (int i = 0; i < amtaCount; i++) hashes.Add(br.ReadUInt32());
                offsets.Add(br.ReadUInt32());
                while (br.BaseStream.Position < offsets[0]) offsets.Add(br.ReadUInt32());
                offsets.Sort();
            }
        }

        public class AMTA
        {
            public char[] id;
            public UInt16 BOM;
            public UInt16 unknown1;
            public UInt32 size;
            public UInt32 dataOffset;
            public UInt32 markOffset;
            public UInt32 extOffset;
            public UInt32 strgOffset; // We need this to grab FWAV names

            public void parseAMTA(BinaryReader br)
            {
                id = br.ReadChars(4);
                if (new string(id) != "AMTA") throw new Exception("AMTA chunk doesn't match. Something isn't right here..");
                BOM = br.ReadUInt16();
                unknown1 = br.ReadUInt16();
                size = br.ReadUInt32();
                dataOffset = br.ReadUInt32();
                markOffset = br.ReadUInt32();
                extOffset = br.ReadUInt32();
                strgOffset = br.ReadUInt32();
            }
        }

        public class DATA
        {
            public char[] id;
            public UInt32 size;
            public UInt64 unknown1;
            public UInt16 unknown2;
            public UInt16 unknown3;
            public UInt32 unknown4;
            public UInt32 unknown5;
            public UInt32 unknown6;
            public UInt32 unknown7;
            public UInt64 unknown8;
            // Floating-point stuff
            public float[] f1;
            public UInt32[] u1;

            public void parseDATA(BinaryReader br)
            {
                id = br.ReadChars(4);
                if (new string(id) != "DATA") throw new Exception("DATA chunk is invalid.");
                size = br.ReadUInt32();
                unknown1 = br.ReadUInt64();
                unknown2 = br.ReadUInt16();
                unknown3 = br.ReadUInt16();
                unknown4 = br.ReadUInt32();
                unknown5 = br.ReadUInt32();
                unknown6 = br.ReadUInt32();
                unknown7 = br.ReadUInt32();
                unknown8 = br.ReadUInt64();
                f1 = new float[8];
                u1 = new UInt32[8];
                for (int i = 0; i < 8; i++)
                {
                    f1[i] = br.ReadSingle();
                    u1[i] = br.ReadUInt32();
                }
            }
        }

        public class MARK
        {
            public char[] id;
            public UInt32 size;

            public void parseMARK(BinaryReader br)
            {
                id = br.ReadChars(4);
                if (new string(id) != "MARK") throw new Exception("MARK chunk is invalid.");
                size = br.ReadUInt32();
                br.ReadUInt32();
            }
        }

        public class EXT_
        {
            public char[] id;
            public UInt32 size;

            public void parseEXT_(BinaryReader br)
            {
                id = br.ReadChars(4);
                if (new string(id) != "EXT_") throw new Exception("EXT_ chunk is invalid.");
                size = br.ReadUInt32();
                br.ReadUInt32();
            }
        }

        public class STRG
        {
            public char[] id;
            public UInt32 stringSize;
            public char[] fwavName;

            public void parseSTRG(BinaryReader br)
            {
                id = br.ReadChars(4);
                if (new string(id) != "STRG") throw new Exception("STRG chunk is invalid.");
                stringSize = br.ReadUInt32();
                fwavName = br.ReadChars((int)stringSize);
            }
        }

        public void load(string file)
        {
            byte[] f = File.ReadAllBytes(file);
            BinaryReader br = new BinaryReader(new MemoryStream(f, 0, f.Length));
            hdr.parseHeader(br);
            readEntries(br);

            for (int i = 0; i < amtaData.Count; i++)
            {
                f = amtaData[i];
                br = new BinaryReader(new MemoryStream(f, 0, f.Length));
                AMTA amta = new AMTA();
                amta.parseAMTA(br);
                DATA data = new DATA();
                data.parseDATA(br);
                MARK mark = new MARK();
                mark.parseMARK(br);
                EXT_ ext = new EXT_();
                ext.parseEXT_(br);
                STRG strg = new STRG();
                strg.parseSTRG(br);
                strgList.Add(strg);
                br.Close();
            }
        }

        private void readEntries(BinaryReader br)
        {
            for (int i = 0; i < hdr.offsets.Count; i++)
            {
                int size;
                if (i != (hdr.offsets.Count - 1)) size = (int)hdr.offsets[i + 1] - (int)hdr.offsets[i];
                else size = (int)br.BaseStream.Length - (int)hdr.offsets[i];
                br.BaseStream.Seek(hdr.offsets[i], SeekOrigin.Begin);
                headerCheck(br, size);
            }
            br.Close();
        }

        private void headerCheck(BinaryReader br, int size)
        {
            char[] temp = br.ReadChars(4);
            string temp2 = new string(temp);
            switch(temp2)
            {
                case "AMTA": br.BaseStream.Position -= 0x4; amtaData.Add(br.ReadBytes(size)); break;
                case "FWAV": br.BaseStream.Position -= 0x4; fwavData.Add(br.ReadBytes(size)); break;
                default: throw new Exception("Unknown chunk: " + temp2);
            }
        }

        public void unpack(string file)
        {
            Directory.CreateDirectory(file);
            for (int i = 0; i < fwavData.Count; i++)
            {
                FileStream f = File.Create(file + "/" + new string(strgList[i].fwavName).Remove(strgList[i].fwavName.Length - 1) + ".bfwav");
                f.Write(fwavData[i], 0, fwavData[i].Length);
                f.Close();
            }

            Directory.CreateDirectory(file + "/meta");
            for (int i = 0; i < amtaData.Count; i++)
            {
                FileStream f = File.Create(file + "/meta/" + new string(strgList[i].fwavName).Remove(strgList[i].fwavName.Length - 1) + ".bamta");
                f.Write(amtaData[i], 0, amtaData[i].Length);
                f.Close();
            }
        }
    }
}
