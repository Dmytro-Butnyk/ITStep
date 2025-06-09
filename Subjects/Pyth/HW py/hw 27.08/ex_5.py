from random import randint

def uniting(x, y):
    o = []
    o+=x+y
    
    return o
        
        
x = [randint(1,10) for i in range(5)]
y = [randint(1,10) for i in range(5)]
print(x,y)

print(uniting(x, y))