"use strict";
require('nodeHttpServer');
var Server = (function () {
    function Server() {
        console.log('ctor');
    }
    return Server;
}());
exports.Server = Server;
