try:
    x = int(input('Enter n for factorial: '))
    if x < 0:
        raise Exception
    fact = 1
    for i in range(1, x+1):
        fact *= i
    print(f'Factorial: {fact}')
except Exception:
    print('Negative number can`t be used!!!')