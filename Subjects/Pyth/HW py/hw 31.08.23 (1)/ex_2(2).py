def ageCheck(x):
    try: 
        if x > 130 or x < 0:
            raise Exception
        print(f'Привіт, {name}! Твій вік - {age}')
    except Exception:
        print('Wrong age!!!')
    

age = int(input('Enter your age: '))
name = input('Enter your name: ')
ageCheck(age)