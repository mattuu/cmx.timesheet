"use strict";
require('nodeHttpServer');
require('system-js');
var Server = (function () {
    function Server() {
        console.log('ctor');
    }
    return Server;
}());
exports.Server = Server;
