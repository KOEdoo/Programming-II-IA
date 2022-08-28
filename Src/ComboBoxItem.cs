using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Src
{
    internal class ComboBoxItem
    {
        public string Value { get; set; }
        public string Key { get; set; }
        public ComboBoxItem(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
