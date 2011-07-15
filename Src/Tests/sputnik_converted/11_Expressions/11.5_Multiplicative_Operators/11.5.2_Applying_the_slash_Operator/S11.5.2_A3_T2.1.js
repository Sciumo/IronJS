// Copyright 2009 the Sputnik authors.  All rights reserved.
// This code is governed by the BSD license found in the LICENSE file.

/**
 * @name: S11.5.2_A3_T2.1;
 * @section: 11.5.2;
 * @assertion: Operator x / y returns ToNumber(x) / ToNumber(y); 
 * @description: Type(x) is different from Type(y) and both types vary between Number (primitive or object) and Boolean (primitive and object);
 */


// Converted for Test262 from original Sputnik source

ES5Harness.registerTest( {
id: "S11.5.2_A3_T2.1",

path: "TestCases/11_Expressions/11.5_Multiplicative_Operators/11.5.2_Applying_the_slash_Operator/S11.5.2_A3_T2.1.js",

assertion: "Operator x / y returns ToNumber(x) / ToNumber(y)",

description: "Type(x) is different from Type(y) and both types vary between Number (primitive or object) and Boolean (primitive and object)",

test: function testcase() {
   //CHECK#1
if (true / 1 !== 1) {
  $ERROR('#1: true / 1 === 1. Actual: ' + (true / 1));
}

//CHECK#2
if (1 / true !== 1) {
  $ERROR('#2: 1 / true === 1. Actual: ' + (1 / true));
}

//CHECK#3
if (new Boolean(true) / 1 !== 1) {
  $ERROR('#3: new Boolean(true) / 1 === 1. Actual: ' + (new Boolean(true) / 1));
}

//CHECK#4
if (1 / new Boolean(true) !== 1) {
  $ERROR('#4: 1 / new Boolean(true) === 1. Actual: ' + (1 / new Boolean(true)));
}

//CHECK#5
if (true / new Number(1) !== 1) {
  $ERROR('#5: true / new Number(1) === 1. Actual: ' + (true / new Number(1)));
}

//CHECK#6
if (new Number(1) / true !== 1) {
  $ERROR('#6: new Number(1) / true === 1. Actual: ' + (new Number(1) / true));
}

//CHECK#7
if (new Boolean(true) / new Number(1) !== 1) {
  $ERROR('#7: new Boolean(true) / new Number(1) === 1. Actual: ' + (new Boolean(true) / new Number(1)));
}

//CHECK#8
if (new Number(1) / new Boolean(true) !== 1) {
  $ERROR('#8: new Number(1) / new Boolean(true) === 1. Actual: ' + (new Number(1) / new Boolean(true)));
}

 }
});
