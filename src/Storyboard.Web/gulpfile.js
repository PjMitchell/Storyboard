/// <binding AfterBuild='sass, typeScript, copy' Clean='clean' ProjectOpened='watch' />

var gulp = require("gulp"),
  rimraf = require("rimraf"),
  sass = require("gulp-sass"),
  fs = require("fs"),
  tsc = require("gulp-typescript"),
  concat = require("gulp-concat"),
  flatten = require('gulp-flatten'),
  watch = require('gulp-watch'),
  tsd = require('gulp-tsd'),
  jas =require('gulp-jasmine')
  npmFile = require('gulp-npm-files');

eval("var project = " + fs.readFileSync("./project.json"));

var paths = {
  bower: "./bower_components/",
  lib: "./" + project.webroot + "/lib/",
  css: "./" + project.webroot + "/css/",
  app: "./" + project.webroot + "/app/",
  webroot: "./" + project.webroot +"/"
};
var npmConfig = {
    libBase: 'node_modules',
    libs: [
         require.resolve('systemjs/dist/system.src.js'),
         require.resolve('zone.js/dist/zone.js'),
         require.resolve('angular2/bundles/angular2.dev.js'),
         require.resolve('angular2/bundles/router.dev.js'),        
         require.resolve('jasmine-core/lib/jasmine-core/jasmine.css'),
         require.resolve('jasmine-core/lib/jasmine-core/jasmine.js'),
         require.resolve('jasmine-core/lib/jasmine-core/jasmine-html.js'),
         require.resolve('jasmine-core/lib/jasmine-core/boot.js'),
         require.resolve('jasmine-es6-promise-matchers/jasmine-es6-promise-matchers.js'),
         require.resolve('rxjs/bundles/rx.js')
    ]
}
var tsProject = tsc.createProject('tsconfig.json');


gulp.task('declaration', function (callback) {
    tsd({
        command: 'reinstall',
        config: './tsd.json'
    }, callback);
});

gulp.task("clean", function (cb) {
  rimraf(paths.lib, cb);
});

gulp.task('sass', function(){
    gulp.src('./sass/*.scss')
    .pipe(sass())
    .pipe(gulp.dest(paths.css));
});

gulp.task('typeScript', function () {
    var tsResult = tsProject.src() 
            .pipe(tsc(tsProject));
    tsResult.js.pipe(gulp.dest(paths.webroot));
});

gulp.task('watch', function () {
    gulp.watch('./sass/*.scss', ['sass']);
    gulp.watch('./Scripts/**/*.ts', ['typeScript']);
   
});

gulp.task("copy", ["clean"], function () {
  var bower = {
    "bootstrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,eot}",
    "bootstrap-touch-carousel": "bootstrap-touch-carousel/dist/**/*.{js,css}",
    "hammer.js": "hammer.js/hammer*.{js,map}",
    "jquery": "jquery/jquery*.{js,map}",
    "jquery-validation": "jquery-validation/jquery.validate.js",
    "jquery-validation-unobtrusive": "jquery-validation-unobtrusive/jquery.validate.unobtrusive.js",
    "angular": "angular/angular.*{js,map}",
    "angular-route": "angular-route/angular-route.*{js,map}",
    "angular-bootstrap": "angular-bootstrap/*.{js,map,css}",
    "reflect-metadata": "reflect-metadata/*.{js,map}",
    "es6-shim": "es6-shim/*.{js,map}"
  }

  for (var destinationDir in bower) {
    gulp.src(paths.bower + bower[destinationDir])
      .pipe(gulp.dest(paths.lib + destinationDir));
  }
    gulp.src(npmConfig.libs, { base: npmConfig.libBase })
    .pipe(gulp.dest(paths.lib))
});


