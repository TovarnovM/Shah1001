using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace xml_tst_console {
    class Program {
        static void Main(string[] args) {
            var xsd_path = @"E:\qt46\SIM\data\settings.xsd";
            var xml_path = @"E:\qt46\SIM\data\some.xml";
            var xdoc = XDocument.Load(xml_path);
            foreach (var e in GetAllElems(xdoc)
                                .Where(el=>el.HasAttributes)
                                .SelectMany(el=>el.Attributes())) {
                Console.WriteLine($"{e.Name} = {e.Value}");
                //var val = e.Attribute("xsi:type");
                //if(val != null)
                //    Console.WriteLine(val.Value);

            }

            //XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            //Settings set;
            //using (var reader = new StreamReader(xml_path)) {
            //    set = (Settings)serializer.Deserialize(reader);
            //}


            Console.ReadLine();
        }

        static IEnumerable<XElement> GetAllElems(XContainer container) {
            var childs = container.Elements();
            foreach (var c in childs) {
                yield return c;
                foreach (var cc in GetAllElems(c)) {
                    yield return cc;
                }
            }
        }
    }
}
