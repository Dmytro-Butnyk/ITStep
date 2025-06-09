n = input('Enter n: ')

res = ''

for i in n:
    if int(i) == 3 or int(i) == 6:
        continue
    else:
        res += i

print(int(res))