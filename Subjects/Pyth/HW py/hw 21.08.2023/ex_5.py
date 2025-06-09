from random import randint


def dob(x, y):
    dob = 1
    if x < y:
        for i in range(x, y):
            dob *= i
    elif x > y:
        for i in range(y, x):
            dob *= i
    return dob

x1 = randint(1, 20)
x2 = randint(1, 20)

print(x1, x2, '\n',dob(x1, x2))