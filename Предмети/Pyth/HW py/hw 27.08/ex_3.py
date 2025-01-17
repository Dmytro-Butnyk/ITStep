from random import randint

def pr(x):
    count_pr = 0
    for i in x:
        cd = 0
        for j in range(2, i+1):
            if i % j == 0:
                cd+=1
        if cd == 1:
            count_pr+=1
    return count_pr
            
x = [randint(1,10) for i in range(5)]
print(x)

print(pr(x))