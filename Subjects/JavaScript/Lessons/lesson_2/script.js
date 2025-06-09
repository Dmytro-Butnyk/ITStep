'use strict'

// TASK 1
// let n = +prompt("Enter number (1 - 10): ");
// let sum = 0;
// if(n > 10 && n < 1){
//     alert(`Number out of bonds!\n
//     Max: 10`)
//     n = 10
// }

// for(let i = 1; i <= n; i++){
//     sum+=i;
// }

// alert(`The sum from 1 to ${n} is ${sum}`);

// TASK 2
// let n = +prompt("Enter number (1 - 20): ");
// if(n > 20 && n < 1){
//     alert(`Number out of bonds!\n
//     Max: 20 / Min: 1`)
//     n = 20
// }

// for(let i = 1; i <= n; i++){
//     if(i % 2 == 0){
//         console.log(i);
//     }
// }

// TASK 3
// function func_1(a, b){
//     return a+b;
// }

// const func_2 = function(a,b){
//     return a+b;
// }

// let func_3 = a => Console.Log(a);

// let userName = prompt(`Enter your name: `);

// const hello = function(){
//     let counter = 0;
//     return function test(){
//         counter++;
//     }
// }
// let c = hello();
// console.log(c);

// function sum(a=0, b=0){
//     return a+b;
// }

// console.log(sum(4+5));

// function sum(){
//     let res = 0;
//     for(let i = 0; i < arguments.length; i++){
//         res += arguments[i];
//     }
//     return res;
// };
// console.log(sum(1,4,8,8));

// TASK 4

// const c = +prompt("Enter 1-st number: ");

// const isNumber = function(n){
//     if(!isNaN(n) && isFinite(n)){
//         return true;
//     }
//     return false;
// }

// console.log(isNumber(c));


// TASK 5

// function isValidNumber(){
//     const c = +prompt("Enter number (1 - 12): ");

//     if(c < 1 || c > 12 || isNaN(c)){
//         alert(`Number out of bonds or not a number!\n
//         Max: 12 / Min: 1`)
//         isValidNumber();
//     }
//     else{
//         alert(`The number is ${c}`);
//     }
// }

// isValidNumber();


// TASK 6
const n = Math.round(Math.random() * 20) + 1;
alert(n);

function guessTheNumber(n, tries = 1) {
    let guess = prompt(`Enter your guess (1 - 20): `);

    if (isNaN(guess)) {
        alert(`Not a number!\n`);
        guessTheNumber(n, tries + 1);
    }

    if (guess > n) {
        alert(`Your guess is too high!\n`);
        guessTheNumber(n, tries + 1);
    }
    else if (guess < n) {
        alert(`Your guess is too low!\n`);
        guessTheNumber(n, tries + 1);
    }
    else {
        alert(`You guessed the number ${n}!\n
        It took you ${tries} tries.`);
        return;
    }
}

guessTheNumber(n);



