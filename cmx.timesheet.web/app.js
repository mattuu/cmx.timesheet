System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Num, instance;
    return {
        setters:[],
        execute: function() {
            // var app = express();
            Num = (function () {
                function Num() {
                }
                Num.prototype.run = function () {
                    console.log('test');
                };
                return Num;
            }());
            exports_1("Num", Num);
            instance = new Num();
            instance.run();
        }
    }
});
//# sourceMappingURL=app.js.map