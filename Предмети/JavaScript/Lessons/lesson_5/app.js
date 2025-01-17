'use strict';

class Button {
    #width = 150;
    #height = 70;
    content;

    constructor( content) {
        this.content = content;
    }

    get width() {
        return this.#width;
    }
    get height() {
        return this.#height;
    }

    print() {
        document.write(`<button style="width: ${this.#width}px; height: ${this.#height}px;">
        ${this.content}
        </button>`);
    }
}

class ColorButton extends Button {
    constructor(content, color = '#ff0000') {
        super(content);
        this.color = color;
    }

    print() {
        document.write(`<button style="width: ${this.width}px; height: ${this.height}px; background-color: ${this.color};">
        ${this.content}
        </button>`);
    }
}

class Product {
    constructor(name, price, quantity = 1) {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }

    OverallPrice() {
        return this.price * this.quantity;
    }
}

class Basket {
    constructor(products = []) {
        this.products = products;
        this.totalPrice = products.reduce((a, product) => a + product.OverallPrice(), 0);
    }
    getTotalPrice() {
        let totalPrice = 0;
        for (let product of this.products) {
            totalPrice += product.OverallPrice();
        }
        return "Total price: " + totalPrice;
    }
    getTheMostExpensiveProductName() {
        let maxPrice = 0;
        let mostExpensiveProductName = '';
        for (let product of this.products) {
            if (product.OverallPrice() > maxPrice) {
                maxPrice = product.OverallPrice();
                mostExpensiveProductName = product.name;
            }
        }
        return "The most expensive product name: " + mostExpensiveProductName;
    }
    getProductsCount() {
        return "Count of products: " + this.products.length;
    }
}

const basket = new Basket([
    new Product('Apple', 1.99, 3),
    new Product('Banana', 0.99, 5),
    new Product('Orange', 2.99 , 1),
    new Product('Pear', 1.49 , 2),
]);

console.log(basket.getTotalPrice());
console.log(basket.getTheMostExpensiveProductName());
console.log(basket.getProductsCount());

for (let product of basket.products) {
    let colorButton = new ColorButton(product.name, 'rgba(255,0,0,0.18)');
    colorButton.print();
}

console.dir(basket);

