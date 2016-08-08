// ReSharper disable UseOfImplicitGlobalInFunctionScope
// ReSharper disable once PossiblyUnassignedProperty
// ReSharper disable once ThisInGlobalContext

(function(global) {
    var map = {
        "app": "src",
        "rxjs": "node_modules/rxjs",
        "@angular": "node_modules/@angular",
        "jquery": "node_modules/jquery/dist/jquery.js",
        "panzoom": "src/app/lib/jquery.panzoom.js",
        "bootstrap": "node_modules/bootstrap/dist/js/bootstrap.js",
        "bootstrap-datepicker": "node_modules/bootstrap-datepicker/dist/js/bootstrap-datepicker.js",
        "bootstrap-timepicker": "node_modules/bootstrap-timepicker/js/bootstrap-timepicker.js",
        "moment": "node_modules/moment/min/moment.min.js",
        "ng2-bootstrap": "node_modules/ng2-bootstrap"
    };

    // packages tells the System loader how to load when no filename and/or no extension
    var packages = {
        "app": {
            main: "main.js",
            defaultExtension: "js"
        },
        "rxjs": {
            defaultExtension: "js"
        },
        "ng2-bootstrap": {
            defaultExtension: "js"
        }
    };

    var packageNames = [
        "@angular/common",
        "@angular/compiler",
        "@angular/core",
        "@angular/http",
        "@angular/platform-browser",
        "@angular/platform-browser-dynamic",
        "@angular/router",
        "@angular/router-deprecated",
        "@angular/testing",
        "@angular/upgrade"
    ];

    // add package entries for angular packages in the form "@angular/common": { main: "index.js", defaultExtension: "js" }
    packageNames.forEach(function(pkgName) {
        packages[pkgName] = {
            main: "index.js",
            defaultExtension: "js"
        };
    });

    var metas = {
        "src/app/lib/jquery.panzoom.js": {
            format: "global",
            exports:"$.panzoom",
            deps: ["jquery"]
        },
        "node_modules/bootstrap/dist/js/bootstrap.js": {
            format: "global",
            deps: ["jquery"]
        },
        "node_modules/bootstrap-datepicker/dist/js/bootstrap-datepicker.js": {
            format: "global",
            deps: ["jquery"]
        },
        "node_modules/bootstrap-timepicker/js/bootstrap-timepicker.js": {
            format: "global",
            deps: ["jquery"]
        }
    };

    var config = {
        map: map,
        packages: packages,
        meta:metas
    }

    // filterSystemConfig - index.html"s chance to modify config before we register it.
    if (global.filterSystemConfig) {
        global.filterSystemConfig(config);
    }

    System.config(config);



})(this);