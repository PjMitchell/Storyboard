/// <binding AfterBuild='sass, typeScript, copy' Clean='clean' ProjectOpened='watch' />

var gulp = require("gulp"),
  rimraf = require("rimraf"),
  sass = require("gulp-sass"),
  fs = require("fs"),
  tsc = require("gulp-typescript"),
  concat = require("gulp-concat"),
  flatten = require('gulp-flatten'),
  watch = require('gulp-watch'),
  tsd = require('gulp-tsd');

eval("var project = " + fs.readFileSync("./project.json"));

var paths = {
  bower: "./bower_components/",
  lib: "./" + project.webroot + "/lib/",
  css: "./" + project.webroot + "/css/",
  app: "./" + project.webroot + "/app/"
};

var tsOption = {
    sortOutput: true,
    target: 'ES5'
}

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
    gulp.src('./Scripts/AppBootstrapper.ts')
    .pipe(tsc().js).pipe(gulp.dest(paths.app));
    gulp.src(['./Scripts/Home/**/*.ts'])
    .pipe(tsc().js)
    .pipe(flatten())
    .pipe(concat('home.js'))
    .pipe(gulp.dest(paths.app));
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
    "angular-bootstrap": "angular-bootstrap/*.{js,map,css}"
  }

  for (var destinationDir in bower) {
    gulp.src(paths.bower + bower[destinationDir])
      .pipe(gulp.dest(paths.lib + destinationDir));
  }
});


