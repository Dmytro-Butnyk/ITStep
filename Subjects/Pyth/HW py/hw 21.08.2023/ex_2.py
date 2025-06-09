def par_mizh(x, y):
    for i in range(x+1, y):
        if i % 2 == 0:
            print(i, end='  ')
            
x = int(input('Enter f n: '))
y = int(input('Enter s n: '))

par_mizh(x, y)