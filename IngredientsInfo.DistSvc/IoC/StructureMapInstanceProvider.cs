using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace IngredientsInfo.DistSvc.IoC
{

    public class StructureMapInstanceProvider : IInstanceProvider
    {
        private Type serviceType;
        public StructureMapInstanceProvider(Type serviceType)
        {
            this.serviceType = serviceType;
        }
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return ((StructureMap.Container)Singleton.Container).GetInstance(serviceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            if (instance is IDisposable)
            {
                (instance as IDisposable).Dispose();
            }
        }

    }
}