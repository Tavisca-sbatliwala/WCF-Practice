using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFTest
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        List<Airline> GetAllAirline();
        [OperationContract]
        string ConvertToString(int number);
    }


    [DataContract]
    public class Airline
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}

