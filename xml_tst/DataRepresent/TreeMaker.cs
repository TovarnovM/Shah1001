using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace xml_tst.DataRepresent {
    public class TreeMaker {
        public TreeMaker(XDocument doc, XmlSchemaSet schema) {
            Doc = doc;
            Schema = schema;
            if (!IsValid)
                throw new ArgumentException("xml соответству ет схеме: " + ValidMsg);
        }

        public XDocument Doc { get; }
        public XmlSchemaSet Schema { get; }

        public string ValidMsg { get; private set; }
        public bool IsValid {
            get {
                string msg = "";
                Doc.Validate(Schema, (o, e1) => {
                    msg += e1.Message + Environment.NewLine;
                }, true);
                ValidMsg = msg == "" ? "Document is valid" : "Document invalid: " + msg;
                return msg == "";
            }
        }

        
    }
}
