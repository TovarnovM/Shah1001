using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace xml_tst_console {
    class Program {
        static void Main(string[] args) {
            var xsd_path = @"D:\qt46\SIM\data\settings.xsd";
            var xml_path = @"D:\qt46\SIM\data\some.xml";
            var xdoc = XDocument.Load(xsd_path);
            foreach (var e in GetAllElems(xdoc)
                                .Where(el=>el.HasAttributes)) {
                
                Console.WriteLine(e.Attribute("name")?.Value);

            }
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
