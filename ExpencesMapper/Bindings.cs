﻿using ExpensesMapper.Interfaces;
using ExpensesMapper.Lib;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesMapper
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IAggregator>().To<Aggregator>();
        }
    }
}