x = int(input('Enter first: '))
y = int(input('Enter last: '))

for i in range(x, y+1):
    for j in range(1, 11):
        print(f'{i}*{j} = {i*j}; ', end='')
    print('\n', '.'*40)