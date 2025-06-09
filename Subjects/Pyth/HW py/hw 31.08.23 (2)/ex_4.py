x1 = open("hw 31.08.23 (2)/data/first.txt", encoding='utf-8')

with x1:
    x1_read = x1.readlines()
    max_len = len(x1_read[0])
    for i in x1_read:
        if max_len < len(i):
            max_len = len(i)
            
print('The longest count of symvols in a row is: ', max_len)