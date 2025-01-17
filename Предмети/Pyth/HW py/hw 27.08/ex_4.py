from random import randint

def deleting(x):
    count = 0
    while True:
        j = int(input('Enter index of element that you wanna to delete or type -1 for end: '))
        if j != -1:
            del(x[j])
            count += 1
            print(x)
        else:
            break
    return count
        
        
x = [randint(1,10) for i in range(5)]
print(x)

print(deleting(x))