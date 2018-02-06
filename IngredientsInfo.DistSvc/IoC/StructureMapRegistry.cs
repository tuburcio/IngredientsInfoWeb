using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IngredientsInfo.DistSvc.IoC
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            Scan(
                scan =>
                {
                    scan.Assembly("IngredientsService");
                    scan.Assembly("IngredientsEntities");
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
        }
    }
}