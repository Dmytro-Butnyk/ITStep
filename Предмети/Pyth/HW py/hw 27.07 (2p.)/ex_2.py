import random

s = [random.randint(-10, 11) for i in range(10)]

print(s)

print(f'Min: {min(s)};\nMax: {max(s)}\n')

v = 0
d = 0
n = 0
for i in s:
    if i < 0:
        v += 1
    elif i == 0:
        n += 1
    elif i > 0:
        d += 1

print(f'Dod el: {d};\nVid el: {v};\n Nul el: {n}')