n = int(input('Enter n (1 - 100): '))

if n > 100 or n < 1:
    print('Wrong number!')
elif n % 3 == 0 and n % 5 == 0:
    print('Fizz Buzz')
elif n % 3 == 0: 
    print('Fizz')
elif n % 5 == 0:
    print('Buzz')

else:
    print(n)