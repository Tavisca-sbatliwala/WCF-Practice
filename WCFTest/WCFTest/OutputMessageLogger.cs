using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;
using System.Web.Services.Description;

namespace WCFTest
{
    public class OutputMessageLogger :IDispatchMessageInspector,IServiceBehavior
    {

        public void ApplyDispatchBehavior(System.ServiceModel.Description.ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (var endpoint in dispatcher.Endpoints)
                {
                    endpoint.DispatchRuntime.MessageInspectors.Add(new OutputMessageLogger());
                }
            }
        }

        public void AddBindingParameters(System.ServiceModel.Description.ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(System.ServiceModel.Description.ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase)
        {
        }

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            Console.WriteLine("Service....Received");
            //Debug.Write(request.ToString());

            var action = OperationContext.Current.IncomingMessageHeaders.Action;
            var name = instanceContext.GetServiceInstance().GetType().Name;
            if (action != null)
            {
                var operationName = action.Substring(action.LastIndexOf("/", StringComparison.OrdinalIgnoreCase) + 1);
                File.AppendAllText(@"D:\rootdirectory\log.txt", operationName);
            }

            
            return null;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            //Console.WriteLine("Service....send");
            ////Debug.Write(reply.ToString());
            //var action = OperationContext.Current.IncomingMessageHeaders.Action;
            //var name = RequestContext.
            //if (action != null)
            //{
            //    var operationName = action.Substring(action.LastIndexOf("/", StringComparison.OrdinalIgnoreCase) + 1);
            //    File.AppendAllText(@"D:\rootdirectory\log.txt", operationName);
            //}
        }
    }
}