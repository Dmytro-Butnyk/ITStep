x = int(input("Enter f n: "))
y = int(input("Enter s n: "))
z = int(input("Enter t n: "))

n = int(input('Enter\n1 - to min\n2 - to max\n3 - to avg\n'))

if n == 1:
    min = x
    if y < min:
        min = y
    if z < min:
        min = z
    print('Min: ', min)
elif n == 2:
    max = x
    if y > max:
        max = y
    if z > max:
        max = z
    print('Max: ', max)
elif n == 3:
    print(f'Avg: {(x+y+z)/3}')
else:
    print('Wrong choise')