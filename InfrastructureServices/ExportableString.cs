﻿using System;
using System.Data;
using System.Runtime.InteropServices.ComTypes;

namespace InfrastructureServices
{
    public class ExportableString : Exportable
    {
        protected string Item;

        public ExportableString()
        {
        }

        public ExportableString(string item)
        {
            this.Item = item;
        }
    }
}