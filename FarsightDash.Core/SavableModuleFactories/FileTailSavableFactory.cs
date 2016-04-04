﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.Controls;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.SavableModuleFactories
{
    public class FileTailSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(FileTail); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new FileTail(savedString);
        }
    }
}