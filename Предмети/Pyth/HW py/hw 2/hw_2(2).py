salary = int(input('Salary: '))
kredit = int(input('Month pay for kredit: '))
komun = int(input('Komunal service: '))

income = salary - kredit - komun

print(f'Your income is: {income}')