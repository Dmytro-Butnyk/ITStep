def showByIndex(x):
        print(x[s1])
def deleteByIndex(x):
        del x[s1]

s = [input(f'Enter element ({i}):') for i in range(1, 6)]

while True:
    n = int(input("Enter\n1 - to show list\n2 - to find max el\n3 - to find min el\n4 - to show element by index\n5 - to delete element by index\n0 - stop program\n"))

    if n == 1:
        print(s)
    elif n == 2:
        print(max(s))
    elif n == 3:
        print(min(s))
    elif n == 4:
        try:
            s1 = int(input("Enter index: "))
            showByIndex(s)
        except IndexError:
            print('Index out of range!!!')
    elif n == 5:
        try:
            s1 = int(input("Enter index: "))
            deleteByIndex(s)
        except IndexError:
            print('Index out of range!!!')
    elif n == 0:
        exit()