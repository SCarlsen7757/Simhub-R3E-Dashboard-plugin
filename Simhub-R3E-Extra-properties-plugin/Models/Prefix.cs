using System.Collections.Generic;
using System.Linq;

namespace Simhub_R3E_Extra_properties_plugin.Models
{
    public abstract class Prefix
    {
        internal readonly List<string> _prefix = new List<string>();
        public Prefix() { }
        public Prefix(string prefix)
        {
            this._prefix.Add(prefix.Trim());
        }
        public Prefix(in List<string> prefixList)
        {
            this._prefix = prefixList.ToList();
        }
        public Prefix(in List<string> prefixList, string prefix)
        {
            this._prefix = prefixList.ToList();
            this._prefix.Add(prefix.Trim());
        }
        public string FullPrefix { get => string.Join(".", _prefix); }

        public string FullName(in string subfix)
        {
            string fullPrefix = FullPrefix;
            if (string.IsNullOrWhiteSpace(fullPrefix)) return subfix.Trim();
            else if (string.IsNullOrWhiteSpace(subfix)) return fullPrefix;
            return string.Join(".", fullPrefix, subfix.Trim());
        }
        public string FullName(List<string> subfixList)
        {
            return FullPrefix + "." + string.Join(".", subfixList);
        }
    }
}
