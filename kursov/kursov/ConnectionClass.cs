using kursov.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursov
{
    public class ConnectionClass
    {
        private EFContext context;

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
            foreach (var item in detailInfo)
            {
                context.DetailsClass.Add(item);
            }
            context.SaveChanges();
        }
    }
}
