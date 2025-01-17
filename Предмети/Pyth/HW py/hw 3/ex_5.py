n = int(input("Enter n: "))

reversed = 0

reversed += (n % 10) * 1000  
n //= 10 

reversed += (n % 10) * 100  
n //= 10 

reversed += (n % 10) * 10  
n //= 10  

reversed += n  

print("Reversed n:", reversed)
