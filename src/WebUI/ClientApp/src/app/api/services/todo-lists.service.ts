/* tslint:disable */
/* eslint-disable */
import { Injectable } from "@angular/core";
import { HttpClient, HttpResponse } from "@angular/common/http";
import { BaseService } from "../base-service";
import { ApiConfiguration } from "../api-configuration";
import { StrictHttpResponse } from "../strict-http-response";
import { RequestBuilder } from "../request-builder";
import { Observable } from "rxjs";
import { map, filter } from "rxjs/operators";

import { CreateTodoListCommand } from "../models/create-todo-list-command";
import { TodosViewModel } from "../models/todos-view-model";
import { UpdateTodoListCommand } from "../models/update-todo-list-command";

@Injectable({
  providedIn: "root",
})
export class TodoListsService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
    super(config, http);
  }

  /**
   * Path part for operation todoListsGet
   */
  static readonly TodoListsGetPath = "/api/TodoLists";

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `todoListsGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  todoListsGet$Response(params?: {}): Observable<
    StrictHttpResponse<TodosViewModel>
  > {
    const rb = new RequestBuilder(
      this.rootUrl,
      TodoListsService.TodoListsGetPath,
      "get"
    );
    if (params) {
    }

    return this.http
      .request(
        rb.build({
          responseType: "json",
          accept: "application/json",
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<TodosViewModel>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `todoListsGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  todoListsGet(params?: {}): Observable<TodosViewModel> {
    return this.todoListsGet$Response(params).pipe(
      map((r: StrictHttpResponse<TodosViewModel>) => r.body as TodosViewModel)
    );
  }

  /**
   * Path part for operation todoListsCreate
   */
  static readonly TodoListsCreatePath = "/api/TodoLists";

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `todoListsCreate()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  todoListsCreate$Response(params: {
    body: CreateTodoListCommand;
  }): Observable<StrictHttpResponse<number>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      TodoListsService.TodoListsCreatePath,
      "post"
    );
    if (params) {
      rb.body(params.body, "application/json");
    }

    return this.http
      .request(
        rb.build({
          responseType: "json",
          accept: "application/json",
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return (r as HttpResponse<any>).clone({
            body: parseFloat(String((r as HttpResponse<any>).body)),
          }) as StrictHttpResponse<number>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `todoListsCreate$Response()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  todoListsCreate(params: { body: CreateTodoListCommand }): Observable<number> {
    return this.todoListsCreate$Response(params).pipe(
      map((r: StrictHttpResponse<number>) => r.body as number)
    );
  }

  /**
   * Path part for operation todoListsGet2
   */
  static readonly TodoListsGet2Path = "/api/TodoLists/{id}";

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `todoListsGet2()` instead.
   *
   * This method doesn't expect any request body.
   */
  todoListsGet2$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Blob>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      TodoListsService.TodoListsGet2Path,
      "get"
    );
    if (params) {
      rb.path("id", params.id, {});
    }

    return this.http
      .request(
        rb.build({
          responseType: "blob",
          accept: "application/octet-stream",
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<Blob>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `todoListsGet2$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  todoListsGet2(params: { id: number }): Observable<Blob> {
    return this.todoListsGet2$Response(params).pipe(
      map((r: StrictHttpResponse<Blob>) => r.body as Blob)
    );
  }

  /**
   * Path part for operation todoListsUpdate
   */
  static readonly TodoListsUpdatePath = "/api/TodoLists/{id}";

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `todoListsUpdate()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  todoListsUpdate$Response(params: {
    id: number;
    body: UpdateTodoListCommand;
  }): Observable<StrictHttpResponse<Blob>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      TodoListsService.TodoListsUpdatePath,
      "put"
    );
    if (params) {
      rb.path("id", params.id, {});
      rb.body(params.body, "application/json");
    }

    return this.http
      .request(
        rb.build({
          responseType: "blob",
          accept: "application/octet-stream",
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<Blob>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `todoListsUpdate$Response()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  todoListsUpdate(params: {
    id: number;
    body: UpdateTodoListCommand;
  }): Observable<Blob> {
    return this.todoListsUpdate$Response(params).pipe(
      map((r: StrictHttpResponse<Blob>) => r.body as Blob)
    );
  }

  /**
   * Path part for operation todoListsDelete
   */
  static readonly TodoListsDeletePath = "/api/TodoLists/{id}";

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `todoListsDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  todoListsDelete$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Blob>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      TodoListsService.TodoListsDeletePath,
      "delete"
    );
    if (params) {
      rb.path("id", params.id, {});
    }

    return this.http
      .request(
        rb.build({
          responseType: "blob",
          accept: "application/octet-stream",
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<Blob>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `todoListsDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  todoListsDelete(params: { id: number }): Observable<Blob> {
    return this.todoListsDelete$Response(params).pipe(
      map((r: StrictHttpResponse<Blob>) => r.body as Blob)
    );
  }
}
