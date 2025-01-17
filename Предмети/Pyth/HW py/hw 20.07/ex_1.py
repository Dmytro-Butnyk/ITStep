x = int(input('Enter start: '))
y = int(input('Enter end: '))

for i in range(x, y+1):
    d = 0
    for j in range(1, i+1):
        if i % j == 0:
            d += 1
    if d == 2:
        print(i)