f = open('introduction', 'r')
file = open('sketchy.txt', 'w')

for line in f.readlines():
    file.write('Queue.Add(' + "\"" + line[:-1].replace('\"', '') + "\"" + ')' + ";\n")