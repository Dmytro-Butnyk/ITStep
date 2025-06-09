'use strict'

let x = +prompt("1: "), y = +prompt("2: ");
let symbol = prompt("operation: ");

let result;
switch(symbol) {
    case "+":
        {
        result = x + y;
        break;
        }
    case "-":
        {
        result = x - y;
        break;
        }
    case "*":
        {
        result = x * y;
        break;
        }
    case "/":
        {
        if (y == 0) {
            console.error("dividing on zero!");
            break;
        }
        result = x / y;
        break;
    }
}
console.log(result);