try: 
    name = input('Enter your name: ')
    age = int(input('Enter your age: '))
    if age > 130 or age < 0:
        raise Exception
    print(f'Привіт, {name}! Твій вік - {age}')
except Exception:
    print('Wrong age!!!')
    