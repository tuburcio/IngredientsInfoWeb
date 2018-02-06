using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;

namespace IngredientsInfo.DistSvc.IoC
{
    public class StructureMapExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(StructureMapServiceBehavior);
            }
        }
        protected override object CreateBehavior()
        {
            return new StructureMapServiceBehavior();
        }
    }
}