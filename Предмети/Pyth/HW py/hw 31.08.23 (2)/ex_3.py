x1 = open("hw 31.08.23 (2)/data/first.txt", encoding='utf-8')
x2 = open('hw 31.08.23 (2)/data/result(ex_3).txt', 'w', encoding='utf-8')

with x1, x2:
    x1_read = x1.readlines()
    del x1_read[-1]
    x2_text = ''
    for i in x1_read:
        x2_text += i
    x2.write(x2_text)