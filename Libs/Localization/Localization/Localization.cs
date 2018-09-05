using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Localization
{
    public class Localization
    {
        [XmlAttribute("name")]
        public string Name;
        [XmlAttribute("version")]
        public string _version;
        [XmlElement("Scope")]
        public List<LocalizationScope> _scopes = new List<LocalizationScope>();


        public System.Version Version => new System.Version(_version);
        public LocalizationScope[] Scopes => _scopes.ToArray();

        public LocalizationScope Scope(string name)
        {
            return _scopes.FirstOrDefault(scope => scope.Name == name);
        }

        public string Find(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new System.ArgumentException("message", nameof(query));
            }

            var tmp = query.Split(':');
            if (tmp.Length != 2)
            {
                throw new System.ArgumentException("Query format must be scope:name");
            }

            return Scope(tmp[0])?.Find(tmp[1]);
        }

        public string Find(string scope, string name)
        {
            if (string.IsNullOrWhiteSpace(scope))
            {
                throw new System.ArgumentException("message", nameof(scope));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException("message", nameof(name));
            }

            return Find(scope + ":" + name);
        }


    }
}
