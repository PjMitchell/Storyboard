import {Injectable} from 'angular2/core';
export interface IHttpAdaptor {
    get<Tresult>(url: string): Promise<Tresult>;
    delete(url: string): Promise<void>;
    post<T>(url: string, data: any): Promise<IPostResult<T>>;
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
    public post<T>(url: string, data: any) {
        var request = new XMLHttpRequest(),
            promise = new Promise<IPostResult<T>>((success, reject) => {
                request.open('POST', url, true);
                request.setRequestHeader('Content-Type', 'application/json; charset=utf-8');
                request.onload = function () {
                    if (request.status >= 200 && request.status < 400) {
                        let location = request.getResponseHeader('Location'),
                            value = <T>JSON.parse(request.responseText);
                        success({
                            location: location,
                            value: value
                        });
                    } else {
                        reject();
                    }
                };

                request.onerror = function () {
                    reject();
                };

                request.send(JSON.stringify(data));
            });
        return promise;
    }
    public put(url: string, data: any) {
        var request = new XMLHttpRequest(),
            promise = new Promise<void>((success, reject) => {
                request.open('PUT', url, true);
                request.setRequestHeader('Content-Type', 'application/json; charset=utf-8');
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

                request.send(JSON.stringify(data));
            });
        return promise;
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
       
}

export interface IPostResult<T> {
    location: string;
    value: T;
}