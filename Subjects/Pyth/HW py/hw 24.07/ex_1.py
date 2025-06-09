s = input('Enter palindrom: ')

p = ''
for i in s:
    if i != ' ':
        p += i

if p.lower() == p[::-1].lower():
    print('Yes, it is a palindrom')
else: 
    print('No, it is not a palindrom')