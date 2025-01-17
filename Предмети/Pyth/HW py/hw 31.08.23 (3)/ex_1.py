import math

def f(x):
    return 9.5 * math.sin(2*x) - 4 * math.cos(x)

def bisection_method(a, b, tol=1e-6, max_iter=100):
    if f(a) * f(b) >= 0:
        print("Метод бісекції не застосовний на даному проміжку.")
        return None
    
    iteration = 0
    while (b - a) / 2 > tol and iteration < max_iter:
        c = (a + b) / 2
        if f(c) == 0:
            return c
        elif f(c) * f(a) < 0:
            b = c
        else:
            a = c
        iteration += 1
    
    return (a + b) / 2

# Задаємо початковий проміжок
a = 0
b = 1

# Знаходимо корінь методом бісекції
root = bisection_method(a, b)

if root is not None:
    print(f"Корінь рівняння на проміжку [{a}, {b}] : {root}")
else:
    print("Не вдалося знайти корінь на даному проміжку.")
