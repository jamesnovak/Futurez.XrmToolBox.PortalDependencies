﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futurez.XrmToolBox
{
    /// <summary>
    /// This class can help you to store settings for your plugin
    /// </summary>
    /// <remarks>
    /// This class must be XML serializable
    /// </remarks>
    public class Settings
    {
        // public string LastUsedOrganizationWebappUrl { get; set; }
        public int? VSplitterPos { get; set; }
        public int? HSplitterPos { get; set; }
    }
}