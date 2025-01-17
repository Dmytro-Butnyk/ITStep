import random

s1 = [random.randint(-10, 11) for i in range(10)]
s2 = [random.randint(-10, 11) for i in range(10)]
s3 = []

print(s1)
print(s2)

# Task 1
s3 = s1+s2
print('Task 1: ', s3)
s3.clear()

# Task 2
# s3 = list(set(s1).union(set(s2)))
s3 = s1[:]
for i in s2:
    if i not in s3:
        s3.append(i)
print('Task 2: ', s3)
s3.clear()

# # Task 3
for i in s1:
    for j in s2:
        if i == j:
            s3.append(i)
print('Task 3: ', s3)

# # Task 4
s4 = s1+s2
for i in s4:
    if i in s3:
        s4.remove(i)
print('Task 4', s4)
s3.clear()
del s4

# Task 5
s3 = [max(s1), min(s1), max(s2), min(s2)]
print('Task 5', s3)