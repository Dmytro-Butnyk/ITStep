n = int(input('Enter n: '))

n1 = n // 1000
n2 = (n // 100) % 10
n3 = (n // 10) % 10
n4 = n % 10

print('Product of numbers: ', n1*n2*n3*n4)