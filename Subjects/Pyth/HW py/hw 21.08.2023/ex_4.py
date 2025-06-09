from random import randint

def minm(x1, x2, x3, x4, x5):
    min = x1
    if x2 < min:
        min = x2
    if x3 < min:
        min = x2
    if x4 < min:
        min = x2
    if x5 < min:
        min = x2
    return min

x1 = randint(-10, 20)
x2 = randint(-10, 20)
x3 = randint(-10, 20)
x4 = randint(-10, 20)
x5 = randint(-10, 20)
print(x1, x2, x3, x4, x5)

print(minm(x1,x2,x3,x4,x5))