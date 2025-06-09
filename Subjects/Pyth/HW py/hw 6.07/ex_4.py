x = int(input('Enter f n: '))
y = int(input('Enter s n: '))

if x == y:
    print('X == Y')
elif x > y:
    print(f'{y}, {x}')
elif y > x:
    print(f'{x}, {y}')