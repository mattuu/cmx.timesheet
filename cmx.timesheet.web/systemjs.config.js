// ReSharper disable UseOfImplicitGlobalInFunctionScope
// ReSharper disable once PossiblyUnassignedProperty
// ReSharper disable once ThisInGlobalContext

(function (global) {
    var map = {
        // "app": "src",
        "@api": "api"
        "rxjs": "node_modules/rxjs",
        "nodeHttpServer": "node_modules/nodeHttpServer",
        "@angular": "node_modules/@angular",
        // "jquery": "node_modules/jquery/dist/jquery.js",
        // "bootstrap": "node_modules/bootstrap/dist/js/bootstrap.js",
        // "bootstrap-datepicker": "node_modules/bootstrap-datepicker/dist/js/bootstrap-datepicker.js",
        // "bootstrap-timepicker": "node_modules/bootstrap-timepicker/js/bootstrap-timepicker.js",
        // "ng2-bootstrap": "node_modules/ng2-bootstrap",
        // "moment": "node_modules/moment/moment.js",
        // "toastr": "node_modules/toastr/toastr.js",
        // "angular2-datatable": "node_modules/angular2-datatable",
        // "lodash": "node_modules/lodash/lodash.js",
        // "filesave": "node_modules/filesaver.js-npm/FileSaver.js"
    };

    // packages tells the System loader how to load when no filename and/or no extension
    var packages = {
        // "app": {
        //     main: "main.js",
        //     defaultExtension: "js"
        // },
        "api": {
        	main: "api/server",
            defaultExtension: "js"
        }
        "rxjs": {
            defaultExtension: "js"
        },
        // "angular2-datatable": {
        //     defaultExtension: "js"
        // },
        // "lodash": {
        //     defaultExtension: "js"
        // },
        // 'ng2-bootstrap': { defaultExtension: "js" },
        // 'moment': { defaultExtension: "js" }
    };

    var ng2PackageNames = [
        // "common",
        // "compiler",
        // "core",
        // "http",
        // "platform-browser",
        // "platform-browser-dynamic",
        // "forms",
        // "router",
    ];

    var ng2TestingPackageNames = [
        // "core",
        // "common",
        // "platform-browser-dynamic",
        // "compiler",
        // "platform-browser",
        // "router"
    ];

    ng2PackageNames.forEach(function (pkgName) {
        packages["@angular/" + pkgName] = {
            main: "/bundles/" + pkgName + ".umd.js",
            defaultExtension: "js"
        };
    });

    ng2TestingPackageNames.forEach(function (pkgName) {
        packages["@angular/" + pkgName + "/testing"] = {
            main: "../bundles/" + pkgName + "-testing.umd.js",
            defaultExtension: "js"
        };
    });

    // add package entries for angular packages in the form "@angular/common": { main: "index.js", defaultExtension: "js" }
    var metas = {
        // "node_modules/bootstrap/dist/js/bootstrap.js": {
        //     format: "global",
        //     deps: ["jquery"]
        // },
        // "node_modules/bootstrap-datepicker/dist/js/bootstrap-datepicker.js": {
        //     format: "global",
        //     deps: ["jquery"]
        // },
        // "node_modules/bootstrap-timepicker/js/bootstrap-timepicker.js": {
        //     format: "global",
        //     deps: ["jquery"]
        // },
        // "node_modules/toastr/toastr.js": {
        //     format: "global",
        //     deps: ["jquery"]
        // },
        // "node_modules/angular2-datatable": {
        //     deps: ["lodash"]
        // },
        // "node_modules/filesaver.js-npm/FileSaver.js": {
        //     format: "global"
        // },
    };

    var config = {
        map: map,
        packages: packages,
        meta: metas
    };

    // filterSystemConfig - index.html"s chance to modify config before we register it.
    if (global.filterSystemConfig) {
        global.filterSystemConfig(config);
    }

    System.config(config);
})(this);