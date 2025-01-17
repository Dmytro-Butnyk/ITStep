n = input('Enter math expresion: ')

x = ''
s = ''
x1 = 0
x2 = 0

for i in range(len(n)):
    if n[i].isdigit() == True:
        x += n[i]
    elif n[i] == '+' or '-' or '*' or '/':
        x1 = int(x)
        x = ''
        s = n[i]
        
    if i == len(n)-1:
        x2 = int(x)

if s == '+':
    print(x1 + x2) 
elif s == '-':
    print(x1 - x2) 
elif s == '*':
    print(x1 * x2) 
elif s == '/':
    print(x1 / x2)