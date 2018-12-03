
import xmlschema

xs = xmlschema.XMLSchema('resourses\\settings.xsd')
for t in xs.types:
    print(t, type(t), xs.types[t])
    break

tp = xs.types['Membership']
a = 10