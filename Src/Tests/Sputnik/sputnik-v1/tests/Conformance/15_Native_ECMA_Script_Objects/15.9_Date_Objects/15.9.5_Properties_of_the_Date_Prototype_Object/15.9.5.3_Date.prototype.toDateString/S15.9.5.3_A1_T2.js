// Copyright 2009 the Sputnik authors.  All rights reserved.
// This code is governed by the BSD license found in the LICENSE file.

/**
 * @name: S15.9.5.3_A1_T2;
 * @section: 15.9.5.3;
 * @assertion: The Date.prototype property "toDateString" has { DontEnum } attributes;
 * @description: Checking absence of DontDelete attribute;
 */

if (delete Date.prototype.toDateString  === false) {
  $ERROR('#1: The Date.prototype.toDateString property has not the attributes DontDelete');
}

if (Date.prototype.hasOwnProperty('toDateString')) {
  $FAIL('#2: The Date.prototype.toDateString property has not the attributes DontDelete');
}

