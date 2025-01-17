def ageCheck(x):
        print(f'Привіт, {name}! Твій вік - {age}')
    

try: 
    age = int(input('Enter your age: '))
    name = input('Enter your name: ')
    if age > 130 or age < 0:
        raise Exception
    ageCheck()
except Exception:
    print('Wrong age!!!')

    