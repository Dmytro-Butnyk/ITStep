while True:
    n1 = int(input("Enter n1 (7 end): "))
    n2 = int(input('Enter n2 (7 end): '))
    
    if n1 == 7 or n2 == 7:
        print('Good bye!')
        break
    
    print(f'Sum = {n1 + n2}')
    if n1 > n2:
        print(f'Max: {n1}\nMin: {n2}')
    else:
        print(f'Max: {n2}\nMin: {n1}')
    