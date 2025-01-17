count = 0

for i in range(100, 1000):
    if i >= 100 and i < 1000:
        x1 = i // 100
        x2 = (i // 10) % 10
        x3 = i % 10
    elif i >= 1000 and i <= 9999:
        x1 = i // 1000
        x2 = (i // 100) % 10
        x3 = (i // 10) % 10
        x4 = i % 10
    
    if x1 != x2 != x3 or  x1 != x2 != x3 != x4:
        count += 1

print(f'Count of numbers: {count}')