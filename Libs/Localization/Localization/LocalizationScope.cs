using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Localization
{
    public class LocalizationScope
    {
        [XmlAttribute("name")]
        public string Name;
        [XmlElement("Item")]
        public List<LocalizationScopeItem> items;

        public string Find(string name)
        {
            return items.FirstOrDefault(item => item.Name == name).Text;
        }
        

    }
}
