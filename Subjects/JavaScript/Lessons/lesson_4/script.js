'use strict'

// const Person = function (name = "NoName", age = 0) {
//     this.name = name
//     this.age = age
//     this.print = function () {
//         console.log(`${this.name} is ${this.age} years old`)
//     }
// }

// class Person {
//     #gender
//     constructor(name = "NoName", age = 0, gender = "male") {
//         this.name = name
//         this.age = age
//         this.print = function () {
//             console.log(`${this.name} is ${this.age} years old`)
//         }
//     }
//
//     get gender() {
//         return this.#gender
//     }
//     set gender(value) {
//         this.#gender = value
//     }
//
//     print() {
//         console.log(`${this.name} is ${this.age} years old`)
//     }
// }

// class Rectangle {
//     constructor(width = 1, height = width) {
//         this.width = width
//         this.height = height
//     }
//     getArea() {
//         return this.width * this.height
//     }
//     getPerimeter() {
//         return 2 * (this.width + this.height)
//     }
// }
//
// const rect = new Rectangle(3, 4)
//
// console.log(rect.getArea())
// console.log(rect.getPerimeter())

class Figure {
    constructor() {}
    getArea() {}
    getPerimeter() {}
}

class Rectangle extends Figure {
    constructor(width = 1, height = width) {
        super()
        this.width = width
        this.height = height
    }

    getArea() {
        return this.width * this.height
    }

    getPerimeter() {
        return 2 * (this.width + this.height)
    }
}

class Circle extends Figure {
    constructor(radius = 1) {
        super()
        this.radius = radius
    }

    getArea() {
        return Math.PI * Math.pow(this.radius, 2)
    }

    getPerimeter() {
        return 2 * Math.PI * this.radius
    }
}

class RectTriangle extends Rectangle {
    constructor(width = 1, height = width) {
        super(width, height)
    }
    getArea() {
        return this.width * this.height / 2
    }
    getPerimeter() {
        return this.width + this.height + Math.sqrt(Math.pow(this.width, 2) + Math.pow(this.height, 2))
    }
}
