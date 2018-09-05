using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FangZhouShuMa.Framework.Enums
{
    public enum ProductCustomFieldType
    {
        [Description("DropDown")]
        DropDown = 1,
        [Description("Numerical")]
        Numerical = 2,
        [Description("Currency")]
        Currency = 3,
        [Description("Text")]
        Text = 4,
        [Description("Boolean")]
        Boolean = 5,
        [Description("RadioSelect")]
        RadioSelect = 6,
        [Description("PseudoCode")]
        PseudoCode = 7
    }
}
