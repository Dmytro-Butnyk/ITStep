from random import randint

def dob(x):
    dob = 1
    for i in x:
        dob *= i
    return dob

x = [randint(1, 10) for i in range(5)]

print(dob(x))