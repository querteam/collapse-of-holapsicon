using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Localization.Parsers
{
    class XmlParser : ILocalizationDeserializer, ILocalizationSerializer
    {
        public Localization Deserialize(string filename)
        {
            var text = File.ReadAllText(filename);

            var localization = new Localization();

            using (var reader = new StreamReader(filename))
            {
                var serializer = new XmlSerializer(typeof(Localization),
                    new XmlRootAttribute(nameof(Localization)));
                localization = (Localization)serializer.Deserialize(reader);
            }

            return localization;
        }

        public string Serialize(Localization localization)
        {
            throw new NotImplementedException();
        }
    }
}
