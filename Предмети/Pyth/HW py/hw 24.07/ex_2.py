x = input('Enter text: ')

n = int(input('Enter count of reserved words: '))

result = x

for i in range(n):
    y = input('Enter reserved word: ')
    
    result = result.replace(y, y.upper())

print('Edited string: ',result)