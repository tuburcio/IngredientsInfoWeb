using System;
using System.Collections.Generic;
using StructureMap;
using System.Linq;
using System.Web;

namespace IngredientsInfo.DistSvc.IoC
{
    public sealed class Singleton
    {
        private static readonly object locker = new object();
        private static IContainer container;
        private Singleton() { }
        public static IContainer Container
        {
            get
            {
                if (container == null)
                {
                    lock (locker)
                    {
                        if (container == null)
                        {
                            container = new Container();
                        }
                    }
                }
                return container;
            }
        }
    }
}