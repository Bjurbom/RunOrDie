using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.IO.IsolatedStorage;


namespace RunOrDie.LevelEditor
{
    public class XMLSave
    {

            
        public static void SaveDAta(object obj)
        {
            /*
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);

            sr.Serialize(writer, obj);
            writer.Close(); */

            
            using (Stream stream = File.Open(@"C:\Users\Tor.bjurbom\Documents\My Games\RunOrDie\RunOrDie\saveStates\file.lip", FileMode.Create))
            {
                var xmlFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                xmlFormatter.Serialize(stream, obj);
            }
        }

        public static void LoadData(object obj)
        {
            using(Stream stream = File.OpenRead(@"C:\Users\Tor.bjurbom\Documents\My Games\RunOrDie\RunOrDie\saveStates\file.lip"))
            {
                var xmlFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                xmlFormatter.AssemblyFormat.CompareTo(obj);
            }
        }
    }
}
