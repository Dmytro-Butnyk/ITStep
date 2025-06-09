def ispalindrom(x):
    if x == x[::-1]:
        return True
    else:
        return False


x = input('Is palindrom?: ')

print(ispalindrom(x))