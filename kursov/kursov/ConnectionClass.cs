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

            //string supportedExtensions = "*.jpg,*.png";

            //int i = 0;

            //foreach (string imageFile in Directory.GetFiles(Environment.CurrentDirectory + @"\\Imagess", "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower())))
            //{
            //   detailInfo[i++].Picture = convert.MapInByte((Image.FromFile(imageFile)));
            //}

            //var files = Directory.GetFiles(Environment.CurrentDirectory + "\\Imagess", "*.mp3", SearchOption.AllDirectories).Union(Directory.GetFiles(Environment.CurrentDirectory + "\\Imagess", "*.jpg", SearchOption.AllDirectories));

            string dir = Environment.CurrentDirectory + "\\Imagess\\";
            string[] filePaths = Directory.GetFiles(dir, "*.jpg", SearchOption.AllDirectories);

            foreach (var item in detailInfo)
            {
                context.DetailsClass.Add(item);
            }
            context.SaveChanges();
        }
    }
}
