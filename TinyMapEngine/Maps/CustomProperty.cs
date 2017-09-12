using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TinyMapEngine.Maps
{
    public class CustomProperty
    {
        [Description("The property name."), Category("Property")]
        public string Name { get; set; }
        [Description("The property value."), Category("Property")]
        public string Value { get; set; }

        #region Property grid crap
        private bool ShouldSerializeName() { return false; }
        private bool ShouldSerializeValue() { return false; }
        #endregion

        public CustomProperty()
        {

        }
    }
}
