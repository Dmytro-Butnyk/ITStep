def kc(x):
    o = ''
    o += str(x)
    c = 0
    for i in o:
        if i.isdigit() == True:
            c+=1
    return c

x = int(input('Enter number: '))

print(kc(x))