using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        public string FullPrefix { get => string.Join(".", _prefix); }

        public string FullName(string subfix)
        {
            string fullPrefix = FullPrefix;
            if (string.IsNullOrEmpty(fullPrefix)) return subfix;
            else if (string.IsNullOrEmpty(subfix)) return fullPrefix;
            return string.Join(".", fullPrefix, subfix);
        }
        public string FullName(List<string> subfixList)
        {
            return FullPrefix + "." + string.Join(".", subfixList);
        }
    }
}
