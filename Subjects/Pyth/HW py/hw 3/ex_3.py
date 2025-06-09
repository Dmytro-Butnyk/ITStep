x = int(input('Enter count of meters: '))

sm = x * 100
dm = x * 10
mm = x * 1000
miles = round(x * 0.000621504, 3)

print(f'Sm = {sm}\nDm = {dm}\nMm = {mm}\nMiles = {miles}')