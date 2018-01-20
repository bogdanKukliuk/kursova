using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace kursov
{
    public class Converter
    {
        public byte[] InByte(Image img)
        {
            var binFormatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            binFormatter.Serialize(ms, img);
            return ms.ToArray();
        }
        /*
        public Image InImage(byte)
        {
            var binFormatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            binFormatter.Deserialize(ms);
        }
        */
    }
}
