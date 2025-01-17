x = open("hw 31.08.23 (2)/data/second.txt", encoding='utf-8')
x1 = open("hw 31.08.23 (2)/data/result(ex_2).txt", "w", encoding='utf-8')

with x, x1:
    numbers = 0
    rows = 0
    golosni = 0
    prygolosni = 0
    count_symv = 0
    x_read = x.readlines()

    for i in x_read:
        for j in i:
            if j.isdigit():
                numbers += 1
            if j.isalpha():
                if j.lower() in 'аеєиіїоу':
                    golosni += 1
                else:
                    prygolosni += 1
                count_symv += 1
        rows += 1

    x1.write(f"Count of symvols: {count_symv}\nCount of rows: {rows}\nCount of golosnyh letters: {golosni}\nCount of prygolosnyh letters: {prygolosni}\nCount of digits: {numbers}")