def x(x):
    sum = 0
    for i in s:
        sum+=i
    return sum

s = [int(input(f'Enter ({i}): ')) for i in range(1, 6)]
try:
    for i in s:
        if 0 > i:
            raise Exception
    print('Suma: ', x(s))
except Exception:
    print('There is a negative number!!!')            
