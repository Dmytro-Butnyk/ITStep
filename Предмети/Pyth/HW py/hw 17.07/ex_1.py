x = int(input('Enter x: '))
y = int(input('Enter y: '))

res = x

if y != 0:
    for i in range(1, y):
        res *= x
else:
    res = 1

print(res)