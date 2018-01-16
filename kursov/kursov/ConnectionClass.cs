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
        public List<DetailsClass> DoConnect()
        {
            List<DetailsClass> brendList = new List<DetailsClass>();

            foreach (var item in context.DetailsClass.ToList())
            {
                brendList.Add(item);
            }

            return brendList;
        }
    }
}
