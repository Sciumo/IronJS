// Copyright 2009 the Sputnik authors.  All rights reserved.
// This code is governed by the BSD license found in the LICENSE file.

/**
 * @name: S7.8.1_A1_T1;
 * @section: 7.8.1;
 * @assertion: Literal :: NullLiteral;
 * @description: Check null === null;   
*/


// Converted for Test262 from original Sputnik source

ES5Harness.registerTest( {
id: "S7.8.1_A1_T1",

path: "TestCases/07_Lexical_Conventions/7.8_Literals/7.8.1_Null_Literals/S7.8.1_A1_T1.js",

assertion: "Literal :: NullLiteral",

description: "Check null === null",

test: function testcase() {
   //CHECK#1
if (null !== null) {
  $ERROR('#1: null === null');
} 

 }
});
