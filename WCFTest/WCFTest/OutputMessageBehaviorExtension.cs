using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;

namespace WCFTest
{
    public class OutputMessageBehaviorExtension : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new OutputMessageLogger();
        }

        public override Type BehaviorType
        {
            get
            {
                return typeof(OutputMessageLogger);
            }
        }
    }
}