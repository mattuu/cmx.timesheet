import * as express from "express";
import Server from "@api/server";

// var app = express();
export class Num {
	constructor() {
	}

	run(): void {
		console.log('test');
	}
}

var instance = new Num();
instance.run();