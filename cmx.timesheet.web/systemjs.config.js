var System = require('systemjs');

System.config({
  map: {
    nodeHttpServer: '/node_modules/node-http-server'
  }
});

System.import(process.argv[2])
    .catch(function (error) {
        setTimeout(function () {
            throw error;
        }, 0);
    });
