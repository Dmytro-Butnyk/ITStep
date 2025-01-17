n = int(input('Enter choise (1 - 8): '))
s = int(input('Enter size (N x N): '))

if s % 2 == 0:
    s+=1

if n == 1:
    x = 0 
    y = s
    for j in range(s):
        print('  '*x, '* '*y)
        x+=1
        y-=1
elif n == 2:
    x = 1 
    for j in range(s):
        print('* '*x)
        x+=1
elif n == 3:
    x = 0 
    y = s
    for j in range(s):
        print('  '*x, '* '*y)
        x+=1
        y-=2
elif n == 4:
    x = int(s/2)
    y = 1
    for i in range(s):
        if i >= int(s/2):
            print('  '*x, '* '*y)
            x -=1
            y +=2
        else:
            print()
elif n == 5:
    x = int(s/2)
    y = 1
    o = 0
    u = s
    for i in range(s):
        if i >= int(s/2):
            print('  '*x, '* '*y)
            x -=1
            y +=2
        else:
            print('  '*o, '* '*u)
            o+=1
            u-=2
elif n == 6:
    x = 1
    y = s
    for i in range(s):
        if i != int(s/2):
            print('* '*x, '  '*(y-x*2), '* '*x, sep='')
        else:
            print('* '*x, '  '*(y-x*2), '* '*(x-1), sep='')
        if i < int(s/2):
            x+=1
        else:
            x-=1
elif n == 7:
    x = 1
    y = s-1
    for i in range(s):
        print('* '*x, '  '*y, sep='')
        if i < int(s/2):
            x+=1
            y-=1
        else:
            x-=1
            y+=1
elif n == 8:
    x = 1
    y = s-1
    for i in range(s):
        print('  '*y, '* '*x, sep='')
        if i < int(s/2):
            x+=1
            y-=1
        else:
            x-=1
            y+=1
elif n == 9:
    x = s
    for i in range(s):
        print('* '*x)
        x-=1
elif n == 10:
    x = s-1
    y = 1
    for i in range(s):
        print('  '*x, '* '*y, sep='')
        x-=1
        y+=1