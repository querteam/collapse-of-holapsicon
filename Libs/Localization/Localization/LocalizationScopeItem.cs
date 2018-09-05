using System.Xml.Serialization;

namespace Localization
{
    public class LocalizationScopeItem
    {
        [XmlAttribute("name")]
        public string Name;
        [XmlText]
        public string Text;
    }
}
