def x(x):
    try:
        sum = 0
        for i in s:
            if 0 > i:
                raise Exception
            if i >= 0:
                sum+=i
        print('Suma: ', sum)
    except Exception:
        print('There is a negative number!!!')        

s = [int(input(f'Enter ({i}): ')) for i in range(1, 6)]

x(s)