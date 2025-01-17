cost = int(input('Enter cost per min: '))
time = int(input('How long will your conversation: '))

x = int(input('Enter\n1 - Kyivstar(+2% to cost per min)\n2 - Vodafone(+5% to cost per min)\n'))

if x == 1:
    conv = cost * time
    print(int(conv + conv*0.02))
elif x == 2:
    conv = cost * time
    print(int(conv + conv*0.05))
else:
    print('Wrong operator!')