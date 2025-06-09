from random import randint

def st(x, y):
    o = [i**y for i in x]
    
    return o
        
        
x = [randint(1,10) for i in range(5)]
y = int(input('Enter stupin`: '))
print(x)

print(st(x, y))