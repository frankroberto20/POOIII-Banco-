﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaIntegracion
{
    public class ClasePrueba
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        
        
        public static void Hello()
        {
            Logger.Info("Hello");
        }
    }

}