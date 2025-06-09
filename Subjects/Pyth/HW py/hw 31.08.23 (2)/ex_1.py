x1 = open("hw 31.08.23 (2)/data/first.txt", encoding='utf-8')
x2 = open("hw 31.08.23 (2)/data/second.txt", encoding='utf-8')

x1_read = x1.readlines()
x2_read = x2.readlines()

for i in range(len(x1_read)):
    if x1_read[i] != x2_read[i]:
        print(f'From first file: {x1_read[i]}\nFrom second file: {x2_read[i]}')