x1 = open("hw 31.08.23 (2)/data/text(ex_5,6).txt", encoding='utf-8')

with x1:
    word = input('Enter a word for searching: ')
    count = 0
    x1_read = x1.read()
    x1_read = x1_read.replace('.', '')
    x1_read = x1_read.replace(',', '')
    x1_read = x1_read.split()
    for i in x1_read:
        if word.upper() == i.upper():
            count += 1
    
print(f'Count of "{word}" in text: {count}')