m = int(input("Enter m: "))

n = int(input('Enter\n1 - to miles\n2 - to inches\n3 - to yards\n'))

if n == 1:
    print(f'Miles: {round(m * 0.000621504, 3)}')
elif n == 2:
    print(f'Inches: {m * 39,37}')
elif n == 3:
    print(f'Yards: {m * 1.09}')
else: 
    print('Wrong choise')