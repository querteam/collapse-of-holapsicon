using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Localization
{

    public class LocalizationManager
    {
        public string LocalizationDirectory;

        public LocalizationManager(string dir)
        {
            if (string.IsNullOrWhiteSpace(dir))
            {
                throw new ArgumentException("Cannot run without predefined localization directory", dir);
            }

            LocalizationDirectory = dir;
        }

        public List<ILocalizationSerializer> serializers = new List<ILocalizationSerializer>()
        {
            new Parsers.XmlParser()
        };

        public List<ILocalizationDeserializer> deserializers = new List<ILocalizationDeserializer>()
        {
            new Parsers.XmlParser()
        };

        /// <summary>
        /// Search for a serializer for a file extension. If there're
        /// several classes with same extension then only the first one
        /// will be picked up
        /// </summary>
        /// <param name="extension"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        /// <returns></returns>
        protected ILocalizationSerializer FindSerializer(string extension)
        {
            if (!SerializableFileExtensions.Contains(extension))
            {
                throw new ArgumentException("Unsupported extension");
            }

            foreach (var ser in serializers)
            {
                var name = ser.GetType().ToString()
                        .Split('.')
                        .Last()
                        .ToLower()
                        .Replace("parser", "");
                if ("." + name == extension)
                {
                    return ser;
                }
            }

            // This cannot happen because it checked that such extension
            // is supported but if this exception will rise then
            // there's a bug
            throw new NullReferenceException("Serializer not found");
        }

        /// <summary>
        /// Search for a serializer for a file extension. If there're
        /// several classes with same extension then only the first one
        /// will be picked up
        /// </summary>
        /// <param name="extension"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        /// <returns></returns>
        protected ILocalizationDeserializer FindDeserializer(string extension)
        {
            if (!SerializableFileExtensions.Contains(extension))
            {
                throw new ArgumentException("Unsupported extension");
            }

            foreach (var des in deserializers)
            {
                var name = des.GetType().ToString()
                        .Split('.')
                        .Last()
                        .ToLower()
                        .Replace("parser", "");
                if ("." + name == extension)
                {
                    return des;
                }
            }

            // This cannot happen because it checked that such extension
            // is supported but if this exception will rise then
            // there's a bug
            throw new NullReferenceException("Serializer not found");
        }

        /// <summary>
        /// List of supported extensions. The list is built
        /// from parts of name of the handling class. Only
        /// both supported classes will be picked up.
        /// </summary>
        public string[] SupportedExtensions
        {
            get
            {
                var ser = SerializableFileExtensions;
                var des = DeserializableFileExtensions;

                var arr = new List<string>();

                for (int i = 0; i < ser.Length; i++)
                {
                    for (int j = 0; j < des.Length; j++)
                    {
                        if (ser[i] == des[i])
                        {
                            arr.Add(ser[i]);
                        }
                    }
                }

                return arr.ToArray();
            }
        }

        /// <summary>
        /// List of supported extensions. The list is built
        /// from parts of name of the handling class
        /// </summary>
        public string[] SerializableFileExtensions
        {
            get
            {
                var arr = new List<string>();
                foreach (var ser in serializers)
                {
                    var name = ser.GetType().ToString()
                        .Split('.')
                        .Last()
                        .ToLower()
                        .Replace("parser", "");
                    arr.Add("." + name);
                }
                return arr.ToArray();
            }
        }

        /// <summary>
        /// List of supported extensions. The list is built
        /// from parts of name of the handling class
        /// </summary>
        public string[] DeserializableFileExtensions
        {
            get
            {
                var arr = new List<string>();
                foreach (var desr in deserializers)
                {
                    var name = desr.GetType().ToString()
                        .Split('.')
                        .Last()
                        .ToLower()
                        .Replace("parser", "");
                    arr.Add("." + name);
                }
                return arr.ToArray();
            }
        }

        /// <summary>
        /// Get list of localization files from a directory
        /// </summary>
        /// <param name="dirname">Localization holder directory's path</param>
        /// <returns></returns>
        public string[] GetLocalizationFilesPath(string dirname = null)
        {
            if (dirname == null)
            {
                if (LocalizationDirectory == null)
                {
                    throw new ArgumentException("Localization directory not set");
                }

                dirname = LocalizationDirectory;
            }

            return new DirectoryInfo(dirname).GetFiles()
                .Where(file => SupportedExtensions.Contains(file.Extension))
                .Select(file => file.FullName)
                .ToArray();
        }

        /// <summary>
        /// Get all locales from Localization Directory
        /// </summary>
        /// <param name="debug">Throw exception if LocalizationDirectory not created</param>
        /// <returns></returns>
        public string[] GetLocales(bool debug = true)
        {
            if (LocalizationDirectory == null)
            {
                throw new NullReferenceException("Localization directory not set");
            }

            if (!Directory.Exists(LocalizationDirectory))
            {
                if (debug)
                {
                    throw new DirectoryNotFoundException("Localization directory not found");
                }

                Directory.CreateDirectory(LocalizationDirectory);
                return new string[0];
            }

            return Directory.GetFiles(LocalizationDirectory)
                .Where(file => SupportedExtensions.Contains(new FileInfo(file).Extension))
                .Select(file => new FileInfo(file).Name)
                .ToArray();

        }

        /// <summary>
        /// Deserialize localization file, if the localization file
        /// is supported
        /// </summary>
        /// <param name="filename">Localization file's path</param>
        /// <returns></returns>
        public Localization Deserialize(string filename)
        {
            return FindDeserializer(new FileInfo(filename).Extension)
                .Deserialize(filename);
        }

        /// <summary>
        /// Serialize localization object, you can pass your own serializer
        /// otherwise the FIRST of the serializer's list will be used.
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public string Serialize(Localization localization, ILocalizationSerializer serializer = null)
        {
            if (serializer == null)
            {
                serializer = serializers[0];
            }

            return serializer.Serialize(localization);
        }

        /// <summary>
        /// Serialize localization object, pass string that identify name of
        /// serializer or its extension
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="name"></param>
        /// <param name="IsExtension">Force extension or not</param>
        /// <returns></returns>
        public string Serialize(Localization localization, string name, bool IsExtension = false)
        {
            if (IsExtension && name[0] != '.')
            {
                name = '.' + name;
            }

            if (name[0] == '.')
            {
                var serializer = FindSerializer(name);
                return serializer.Serialize(localization);
            }
            else
            {
                foreach (var ser in serializers)
                {
                    var sname = ser.GetType().ToString()
                        .Split('.')
                        .Last()
                        .ToLower();
                    if (sname == name.ToLower())
                    {
                        return ser.Serialize(localization);
                    }
                }

                throw new NullReferenceException("No serializer has been found");
            }
        }

        /// <summary>
        /// Load localization from a local file
        /// </summary>
        /// <param name="language">Language name</param>
        /// <returns></returns>
        public Localization Load(string language)
        {
            var filename = GetLocalizationFilesPath(LocalizationDirectory)
                .FirstOrDefault(file =>
                {
                    var fileinfo = new FileInfo(file);
                    var lang = fileinfo.Name.Substring(0,
                        fileinfo.Name.Length - fileinfo.Extension.Length);
                    return language.ToLower() == lang.ToLower();
                });

            if (filename == null)
            {
                throw new FileNotFoundException($"Locale for {language} not found");
            }

            return Deserialize(filename);
        }

        /// <summary>
        /// Load localization from web source, it will save
        /// the locale file on the drive, then diserialize it.
        /// Default localization file format is XML
        /// </summary>
        /// <param name="url">URL to localization file</param>
        /// <param name="filename">
        ///     Filename where to save the file.
        ///     If it's null and localizationdirectory not null,
        ///     save it to the localization directory otherwise
        ///     save it to tmp
        /// </param>
        /// <returns></returns>
        public Localization Load(string url, string filename)
        {
            var bytes = GetBytes(url);
            if (filename != null)
            {
                File.WriteAllBytes(filename, bytes);
                return Deserialize(filename);
            }
            else
            {
                var tmpFilename = Path.GetTempPath() + "\\" +
                    GetHashCode() * UnityEngine.Random.Range(1, 100) + ".xml";

                var des = Deserialize(tmpFilename);

                if (LocalizationDirectory != null && Directory.Exists(LocalizationDirectory))
                {
                    var localeFilename = LocalizationDirectory + "\\" + des.Name + ".xml";
                    File.WriteAllBytes(localeFilename, bytes);
                }

                return des;
            }
        }

        /// <summary>
        /// Get bytes from URL
        /// </summary>
        /// <param name="url">URL to a web or local resource</param>
        /// <returns></returns>
        private static byte[] GetBytes(string url)
        {
            using (var www = new UnityEngine.WWW(url))
            {
                var i = 0;
                while (!www.isDone)
                {
                    if (www.error != null)
                    {
                        throw new System.Net.WebException(www.error);
                    }

                    i++;
                }

                return www.bytes;
            }
        }


    }

}
