from lxml import etree
xmlschema_doc = etree.parse('resourses\\settings_old.xsd')
xmlschema = etree.XMLSchema(xmlschema_doc)
doc = etree.parse('resourses\\some_old.xml')
xmlschema.validate(doc)
root = doc.getroot()

a = 10
