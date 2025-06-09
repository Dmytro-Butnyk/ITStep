n1 = int(input('Enter n1: '))
n2 = int(input('Enter n2: '))


if n1 < n2:
    for i in range(n1, n2+1):
        
        if i % 3 == 0 and i % 5 == 0:
            print('Fizz Buzz')
        elif i % 3 == 0: 
            print('Fizz')
        elif i % 5 == 0:
            print('Buzz')
        else:
            print(i)
elif n1 > n2:
    for i in range(n2, n1+1):
        
        if i % 3 == 0 and i % 5 == 0:
            print('Fizz Buzz')
        elif i % 3 == 0: 
            print('Fizz')
        elif i % 5 == 0:
            print('Buzz')
        else:
            print(i)