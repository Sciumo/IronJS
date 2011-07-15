// Copyright 2009 the Sputnik authors.  All rights reserved.
// This code is governed by the BSD license found in the LICENSE file.

/**
* @name: S15.3.5.1_A4_T1;
* @section: 15.3.5.1;
* @assertion: the length property has the attributes { DontEnum };
* @description: Checking if enumerating the length property of Function("arg1,arg2,arg3", null) fails;
*/


// Converted for Test262 from original Sputnik source

ES5Harness.registerTest( {
id: "S15.3.5.1_A4_T1",

path: "TestCases/15_Native/15.3_Function_Objects/15.3.5_Properties_of_Function_Instances/S15.3.5.1_A4_T1.js",

assertion: "the length property has the attributes { DontEnum }",

description: "Checking if enumerating the length property of Function(\"arg1,arg2,arg3\", null) fails",

test: function testcase() {
   f = new Function("arg1,arg2,arg3", null);

//CHECK#1
if (!(f.hasOwnProperty('length'))) {
  $FAIL('#1: the function has length property.');
}

for(key in f)    
  if(key=="length")
      var lengthenumed=true;
      
//CHECK#2
if (lengthenumed) {
  $ERROR('#2: the length property has the attributes { DontEnum }');
}

 }
});
