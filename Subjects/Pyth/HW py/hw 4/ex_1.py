x = int(input("Enter f n: "))
y = int(input("Enter s n: "))
z = int(input("Enter t n: "))

n = int(input('Enter\n1 - to sum\n2 - to multiplication\n'))

if n == 1:
    print(f'Sum is: {x+y+z}')
elif n == 2:
    print(f'Multi is: {x*y*z}')
else:
    print('Wrong choise')