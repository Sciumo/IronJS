// Copyright 2009 the Sputnik authors.  All rights reserved.
// This code is governed by the BSD license found in the LICENSE file.

/**
 * @name: S11.6.1_A3.1_T1.1;
 * @section: 11.6.1;
 * @assertion: If Type(Primitive(x)) is not String and Type(Primitive(y)) is not String, then operator x + y returns ToNumber(x) + ToNumber(y); 
 * @description: Type(Primitive(x)) and Type(Primitive(y)) vary between primitive boolean and Boolean object;
 */


// Converted for Test262 from original Sputnik source

ES5Harness.registerTest( {
id: "S11.6.1_A3.1_T1.1",

path: "TestCases/11_Expressions/11.6_Additive_Operators/11.6.1_The_Addition_operator/S11.6.1_A3.1_T1.1.js",

assertion: "If Type(Primitive(x)) is not String and Type(Primitive(y)) is not String, then operator x + y returns ToNumber(x) + ToNumber(y)",

description: "Type(Primitive(x)) and Type(Primitive(y)) vary between primitive boolean and Boolean object",

test: function testcase() {
   //CHECK#1
if (true + true !== 2) {
  $ERROR('#1: true + true === 2. Actual: ' + (true + true));
}

//CHECK#2
if (new Boolean(true) + true !== 2) {
  $ERROR('#2: new Boolean(true) + true === 2. Actual: ' + (new Boolean(true) + true));
}

//CHECK#3
if (true + new Boolean(true) !== 2) {
  $ERROR('#3: true + new Boolean(true) === 2. Actual: ' + (true + new Boolean(true)));
}

//CHECK#4
if (new Boolean(true) + new Boolean(true) !== 2) {
  $ERROR('#4: new Boolean(true) + new Boolean(true) === 2. Actual: ' + (new Boolean(true) + new Boolean(true)));
}

 }
});
