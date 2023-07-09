using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Models
{
    public abstract class Prefix
    {
        internal readonly List<string> _prefix = new List<string>();
        public Prefix() { }
        public Prefix(string prefix)
        {
            this._prefix.Add(prefix);
        }
        public Prefix(in List<string> prefixList)
        {
            this._prefix = prefixList.ToList();
        }
        public Prefix(in List<string> prefixList, string prefix)
        {
            this._prefix = prefixList.ToList();
            this._prefix.Add(prefix);
        }
        public string FullPrefix { get => GetFullPrefix(); }
        private string GetFullPrefix()
        {
            string name = string.Empty;
            foreach (string value in this._prefix)
            {
                if (string.IsNullOrEmpty(name))
                {
                    name = value;
                }else
                {
                    name += $".{value}";
                }
                
            }
            return name;
        }
        public string FullName(string subfix)
        {
            return $"{GetFullPrefix()}.{subfix}";
        }
    }
}
