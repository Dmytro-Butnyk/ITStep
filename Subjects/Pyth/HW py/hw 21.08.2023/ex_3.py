def square(x, y, o):
    if x == True:
        for i in range(o):
            print(f'{y} '*o)
    elif x == False:
        for i in range(o):
            if i == 0 or i == (o-1):
                print(f'{y} '*o)
            else:
                print(f'{y} ', '  '*(o-3), f'{y} ')


x = input('Enter 1(true) or 0(false): ')
if x == "1":
    x = True
elif x == "0":
    x = False
y = input('Enter one symvol: ')
o = int(input('Enter lenght: '))

square(x, y, o)