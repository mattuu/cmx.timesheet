var fs = require("fs");
var mkdirp = require("mkdirp");
var walk = require("walk");
var path = require("path");
var Builder = require("systemjs-builder");
var glob = require("glob");
var gulp = require("gulp");
var inject = require("gulp-inject");
var removeCode = require("gulp-remove-code");
var rimraf = require("rimraf");

var destRoot = "./dist";
var srcRoot = "./";
var tempDir = "./.tmp";
var indexFileName = "index.html";
var bundleFileName = "app.bundle." + Date.now() + ".js";

go();

function go() {
    rimraf(destRoot, (err) => {
        console.log("Deleting " + destRoot);
        if (err) {
            console.log("Error while deleting " + destRoot);
            return;
        }

        console.log("Deleted " + destRoot);
        bundle();
    });
}

function bundle() {
    var builder = new Builder("./", "./systemjs.config.js");
    console.log("bundling started");
    builder.buildStatic("app", path.join(tempDir, bundleFileName), { minify: true, sourceMaps: false, mangle: true })
	.then(() => {
	    console.log("bundle file " + bundleFileName + " created.")
	    console.log("bundling complete");
	    copy();
	})
	.catch((err) => {
	    console.log("error while bundling...");
	    console.log(err);
	});
}

function copy() {
    // copy files to web api project
    // relative to srcRoot
    var globalFilesToCopy =
        ["node_modules/bootstrap/dist/css/bootstrap.min.css",
         "node_modules/bootstrap/dist/css/bootstrap.min.css.map",
        "src/assets/styles/bootstrap.simplex.css",
        "node_modules/bootstrap-timepicker/css/bootstrap-timepicker.min.css",
        "node_modules/bootstrap-datepicker/dist/css/bootstrap-datepicker3.min.css",
        "node_modules/bootstrap-datepicker/dist/css/bootstrap-datepicker3.min.css.map",
        "src/assets/styles/style.css",
        "node_modules/core-js/client/shim.js",
        "node_modules/zone.js/dist/zone.min.js",
        "node_modules/reflect-metadata/Reflect.js",
        "node_modules/reflect-metadata/Reflect.js.map",
        "Web*.config",
		"IISBUILD-Shared.psm1",
		"PreDeploy.ps1",
		"PostDeploy.ps1",
        indexFileName,
        "favicon.ico"]

    var bundledFiles = [path.join(tempDir, bundleFileName)];
    var componentResourceGlobs = ["src/app/**/*.{html,css}"];
    var fontsGlobs = ["src/assets/**/*.{eot,svg,ttf,woff,woff2}"];
    var imagesGlob = ["src/assets/**/*.{png,jpg,gif}"];

    copyAllMatching(globalFilesToCopy, err => {
        if (err) {
            console.log("Error while copying global files.")
        }
        console.log("Global files are copied.");
            copyAllMatching(bundledFiles, err => {
                if (err) {
                    console.log("Error while copying bundle files.")
                }
                console.log("Bundle files are copied.");
                injectBundleFile();
            });

    });
    copyAllMatching(componentResourceGlobs, err => {
        if (err) {
            console.log("Error while copying component resources.")
        }
        console.log("Component Resources are copied.");
    });
    copyAllMatching(fontsGlobs, err => {
        if (err) {
            console.log("Error while copying fonts.")
        }
        console.log("Fonts are copied.");
    });
    copyAllMatching(imagesGlob, err => {
        if (err) {
            console.log("Error while copying images.")
        }
        console.log("Images are copied.");
    });
}

function copyAllMatching(globs, cb) {
    globs.forEach((globPattern, indx) => {
        glob(globPattern, (err, files) => {
            copyFilesTo(files, destRoot, (err) => {
                if (indx === globs.length - 1) {
                    cb(null);
                }
            });
        });
    });
}

function copyFilesTo(files, destRoot, cb) {
    files.forEach((file, indx) => {
        var destFile = path.join(destRoot, file);
        var tempDirSegments = tempDir.split("/");
        var tempDirName = tempDirSegments[tempDirSegments.length - 1];
        destFile = destFile.replace(tempDirName + "/", "");
        destFile = destFile.replace(tempDirName + "\\", "");
        mkdirp(path.dirname(destFile), function (err) {
            console.log("Copying " + file + " to " + destFile);
            fs.createReadStream(file).pipe(fs.createWriteStream(destFile));
            if (indx === files.length - 1) {
                cb(null);
            }
        });
    });
}

function injectBundleFile() {
    console.log("Injecting bundle file " + bundleFileName);
    var index = gulp.src(path.join(destRoot, indexFileName));
    var filesToInject = gulp.src([path.join(destRoot, bundleFileName)], { read: false });

    index.pipe(inject(filesToInject, {
        transform: function (filepath) {
            if (filepath.startsWith("/")) {
                return inject.transform(filepath.slice(filepath.lastIndexOf("/") + 1));
            }
            // Use the default transform as fallback: 
            return inject.transform.apply(inject.transform, arguments);
        }
    }))
        .pipe(removeCode({ nonDev: true }))
        .pipe(gulp.dest(destRoot));

    console.log("Injected bundle file " + bundleFileName);
}



