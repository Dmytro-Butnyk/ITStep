n1 = int(input('Start: '))
n2 = int(input('End: '))

for i in range(n1, n2+1):
    print(i, end=' ')
print('\n')

for i in range(n2, n1-1, -1):
    print(i, end=' ')
print('\n')

for i in range(n1, n2+1):
    if i % 7 == 0:
        print(i, end=' ')
print('\n')

count = 0
for i in range(n1, n2+1):
    if i % 5 == 0:
        count += 1
print(count)