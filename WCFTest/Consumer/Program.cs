using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consumer.MyService;
using WCFTest;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new MyServiceClient())
            {
                var airlines = client.GetAllAirline();
                client.ConvertToString(10);
            }
        }
    }
}
