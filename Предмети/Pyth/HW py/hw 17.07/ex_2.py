count = 0

for i in range(100, 1000):
    x1 = i // 100
    x2 = (i // 10) % 10
    x3 = i % 10
    
    if x1 == x2 or x2 == x3 or x3 == x1:
        count += 1

print(f'Count of numbers: {count}') 