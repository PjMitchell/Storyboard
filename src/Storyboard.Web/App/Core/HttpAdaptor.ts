import {Injectable} from 'angular2/core';
export interface IHttpAdaptor {
    get<Tresult>(url: string): Promise<Tresult>;
    delete(url: string): Promise<void>;
    post(url: string, data: any): Promise<void>;
    put(url: string, data: any): Promise<void>;
}
@Injectable()
export class HttpAdaptor implements IHttpAdaptor {

    constructor() { }

    public get<Tresult>(url: string) {
        var request = new XMLHttpRequest(),
            promise = new Promise<Tresult>((success, reject) => {
                request.open('GET', url, true);
                request.onload = function () {
                    if (request.status >= 200 && request.status < 400) {
                        success(<Tresult>JSON.parse(request.responseText));
                    } else {
                        reject();
                    }
                };
                request.onerror = function () {
                    reject();
                };
                request.send();
            });
            return promise;
    }
    public post(url: string, data: any) {
        return this.sendData(url, 'POST', data);
    }
    public put(url: string, data: any) {
        return this.sendData(url, 'PUT', data);
    }
    public delete(url: string) {
        var request = new XMLHttpRequest(),
            promise = new Promise<void>((success, reject) => {
                request.open('DELETE', url, true);
                request.onload = function () {
                    if (request.status >= 200 && request.status < 400) {
                        success();
                    } else {
                        reject();
                    }
                };

                request.onerror = function () {
                    reject();
                };

                request.send();
            });
        return promise;
    }

    private sendData(url: string, verb: string, data: any) {
        var request = new XMLHttpRequest(),
            promise = new Promise<void>((success, reject) => {
                request.open(verb, url, true);
                request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded; charset=UTF-8');
                request.onload = function () {
                    if (request.status >= 200 && request.status < 400) {
                        success();
                    } else {
                        reject();
                    }
                };

                request.onerror = function () {
                    reject();
                };

                request.send(data);
            });
        return promise;
    }
}