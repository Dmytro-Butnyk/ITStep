from random import randint

def minm(x):
    return min(x)

x = [randint(1,10) for i in range(10)]
print(x)

print(minm(x))