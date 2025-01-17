n1 = int(input('Start: '))
n2 = int(input('End: '))

for i in range(n1, n2+1):
    if i % 7 == 0:
        print(i, end=' ')