while True:
    n = int(input('Enter n: '))
    if n == 7:
        print('Good bye!') 
        break
    elif n > 0: 
        print('Positive number')
    elif n < 0:
        print('Negative number')
    elif n == 0:
        print('Number is equal to zero')