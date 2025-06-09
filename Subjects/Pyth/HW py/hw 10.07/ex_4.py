n1 = int(input('Sales of first: '))
n2 = int(input('Sales of second: '))
n3 = int(input('Sales of third: '))

max = n1
if max < n2:
    max = n2
if max < n3:
    max = n3
     
if n1 < 500:
    n1 += n1 * 0.03 + 200
elif n1 < 1000 and n1 > 500:
    n1 += n1 * 0.05 + 200
elif n1 > 1000:
    n1 += n1 * 0.08 + 200
    
if n2 < 500:
    n2 += n2 * 0.03 + 200
elif n2 < 1000 and n2 > 500:
    n2 += n2 * 0.05 + 200
elif n2 > 1000:
    n2 += n2 * 0.08 + 200
    
if n3 < 500:
    n3 += n3 * 0.03 + 200
elif n3 < 1000 and n3 > 500:
    n3 += n3 * 0.05 + 200
elif n3 > 1000:
    n3 += n3 * 0.08 + 200
    
if max == n1:
    print(f'First the best {n1 + 200}, second {n2}, third {n3}')
elif max == n2:
    print(f'Second the best {n2 + 200}, first {n1}, third {n3}')
elif max == n3:
    print(f'Third the best {n3 + 200}, first  {n1}, second {n2}')