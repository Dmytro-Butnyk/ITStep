import random
from sympy import isprime

def generate_prime(bits=512):
    while True:
        num = random.getrandbits(bits)
        if isprime(num):
            return num

def gcd(a, b):
    while b:
        a, b = b, a % b
    return a

def mod_inverse(e, phi):
    for d in range(3, phi, 2):
        if (d * e) % phi == 1:
            return d
    return None

def generate_keypair(bits=512):
    p = generate_prime(bits)
    q = generate_prime(bits)
    n = p * q
    phi = (p - 1) * (q - 1)
    e = 65537
    while gcd(e, phi) != 1:
        e += 2
    d = mod_inverse(e, phi)
    return ((e, n), (d, n))

def encrypt(plaintext, public_key):
    e, n = public_key
    return [pow(ord(char), e, n) for char in plaintext]

def decrypt(ciphertext, private_key):
    d, n = private_key
    return ''.join(chr(pow(char, d, n)) for char in ciphertext)

public_key, private_key = generate_keypair()
message = "Hello, Web 3.0!"
encrypted = encrypt(message, public_key)
decrypted = decrypt(encrypted, private_key)

print("Оригінальне повідомлення:", message)
print("Зашифроване:", encrypted)
print("Розшифроване:", decrypted)
