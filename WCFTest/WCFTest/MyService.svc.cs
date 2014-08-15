using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;

namespace WCFTest
{

    public class MyService : IMyService
    {
        public List<Airline> GetAllAirline()
        {
            try
            {
                //throw new Exception("I really dont like you");
                return new List<Airline>()
           {
               new Airline()
               {
                   Code="xyz",
                   Name="blah",
               }
           };
           }
            catch (Exception)
            {
               throw FaultException.CreateFault(MessageFault.CreateFault(new FaultCode("102"), "I still dont like you."));
            }
        }

        public string ConvertToString(int input)
        {
            return input.ToString();
        }
    }

}