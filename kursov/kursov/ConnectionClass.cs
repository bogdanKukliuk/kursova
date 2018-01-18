using kursov.Context;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursov
{
    public class ConnectionClass
    {
        private EFContext context;
        private Converter convert;

        public ConnectionClass()
        {
            context = new EFContext();
        }

        public List<DetailsClass> DoReadClassDetal()
        {
            List<DetailsClass> detailInfo = new List<DetailsClass>();

            foreach (var item in context.DetailsClass.ToList())
            {
                detailInfo.Add(item);
            }

            return detailInfo;
        }

        public void DoWriteDetalClass(List<DetailsClass> detailInfo)
        {
            convert = new Converter();
            
            string dir = Environment.CurrentDirectory + "\\Imagess\\";
            string[] filePaths = Directory.GetFiles(dir, "*.jpg", SearchOption.AllDirectories);

            foreach (var item in detailInfo)
            {
                Image img =  Image.FromFile(filePaths[0]);
                item.Picture = convert.InByte(img);
                item.BrendCarId = 1;
                
                context.DetailsClass.Add(item);
            }
            context.SaveChanges();
        }
    }
}
