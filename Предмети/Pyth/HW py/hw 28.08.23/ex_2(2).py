def fact(x):
    try:
        if x < 0:
            raise Exception
        fact = 1
        for i in range(1, x+1):
            fact *= i
        return fact    
    except Exception:
        print('Negative number can`t be used!!!')
        return 0



x = int(input('Enter n for factorial: '))
print(fact(x))