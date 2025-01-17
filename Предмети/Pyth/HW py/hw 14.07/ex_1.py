n1 = int(input('Start: '))
n2 = int(input('End: '))

par = 0
count_par = 0
for i in range(n1, n2+1):
    if i % 2 == 0:
        par+=i
        count_par += 1
print(f'Sum = {par}\nAvg par = {par/count_par}\n')

npar = 0
count_npar = 0
for i in range(n1, n2+1):
    if i % 2 != 0:
        npar+=i
        count_npar += 1
print(f'Sum = {npar}\nAvg npar = {npar/count_npar}\n')

nine_crat = 0
count_nine_crat = 0
for i in range(n1, n2+1):
    if i % 9 == 0:
        nine_crat += i
        count_nine_crat += 1
print(f'Sum = {nine_crat}\nAvg nine crat = {nine_crat/count_nine_crat}\n')
