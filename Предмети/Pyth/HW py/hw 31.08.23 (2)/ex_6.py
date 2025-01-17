x1 = open("hw 31.08.23 (2)/data/text(ex_5,6).txt", encoding='utf-8')
x2 = open("hw 31.08.23 (2)/data/result(ex_6).txt", 'w',  encoding='utf-8')

with x1, x2:
    word_s = input('Enter a word for searching: ')
    word_r = input('Enter a word for replacement: ')
    
    x1_read = x1.read()
    x1_read = x1_read.replace('.', '')
    x1_read = x1_read.replace(',', '')
    x1_read = x1_read.split()
    
    x2_write = ''
    for i in x1_read:
        if word_s.upper() == i.upper():
            x2_write += f'{word_r} '
        else:
            x2_write += i
            x2_write += ' '
            
    x2.write(x2_write)
    