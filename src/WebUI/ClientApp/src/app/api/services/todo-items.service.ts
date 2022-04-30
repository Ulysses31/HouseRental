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

import { CreateTodoItemCommand } from "../models/create-todo-item-command";
import { PaginatedListOfTodoItemBriefDto } from "../models/paginated-list-of-todo-item-brief-dto";
import { UpdateTodoItemCommand } from "../models/update-todo-item-command";
import { UpdateTodoItemDetailCommand } from "../models/update-todo-item-detail-command";

@Injectable({
  providedIn: "root",
})
export class TodoItemsService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
    super(config, http);
  }

  /**
   * Path part for operation todoItemsGetTodoItemsWithPagination
   */
  static readonly TodoItemsGetTodoItemsWithPaginationPath = "/api/TodoItems";

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `todoItemsGetTodoItemsWithPagination()` instead.
   *
   * This method doesn't expect any request body.
   */
  todoItemsGetTodoItemsWithPagination$Response(params?: {
    ListId?: number;
    PageNumber?: number;
    PageSize?: number;
  }): Observable<StrictHttpResponse<PaginatedListOfTodoItemBriefDto>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      TodoItemsService.TodoItemsGetTodoItemsWithPaginationPath,
      "get"
    );
    if (params) {
      rb.query("ListId", params.ListId, {});
      rb.query("PageNumber", params.PageNumber, {});
      rb.query("PageSize", params.PageSize, {});
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
          return r as StrictHttpResponse<PaginatedListOfTodoItemBriefDto>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `todoItemsGetTodoItemsWithPagination$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  todoItemsGetTodoItemsWithPagination(params?: {
    ListId?: number;
    PageNumber?: number;
    PageSize?: number;
  }): Observable<PaginatedListOfTodoItemBriefDto> {
    return this.todoItemsGetTodoItemsWithPagination$Response(params).pipe(
      map(
        (r: StrictHttpResponse<PaginatedListOfTodoItemBriefDto>) =>
          r.body as PaginatedListOfTodoItemBriefDto
      )
    );
  }

  /**
   * Path part for operation todoItemsCreate
   */
  static readonly TodoItemsCreatePath = "/api/TodoItems";

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `todoItemsCreate()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  todoItemsCreate$Response(params: {
    body: CreateTodoItemCommand;
  }): Observable<StrictHttpResponse<number>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      TodoItemsService.TodoItemsCreatePath,
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
   * To access the full response (for headers, for example), `todoItemsCreate$Response()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  todoItemsCreate(params: { body: CreateTodoItemCommand }): Observable<number> {
    return this.todoItemsCreate$Response(params).pipe(
      map((r: StrictHttpResponse<number>) => r.body as number)
    );
  }

  /**
   * Path part for operation todoItemsUpdate
   */
  static readonly TodoItemsUpdatePath = "/api/TodoItems/{id}";

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `todoItemsUpdate()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  todoItemsUpdate$Response(params: {
    id: number;
    body: UpdateTodoItemCommand;
  }): Observable<StrictHttpResponse<Blob>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      TodoItemsService.TodoItemsUpdatePath,
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
   * To access the full response (for headers, for example), `todoItemsUpdate$Response()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  todoItemsUpdate(params: {
    id: number;
    body: UpdateTodoItemCommand;
  }): Observable<Blob> {
    return this.todoItemsUpdate$Response(params).pipe(
      map((r: StrictHttpResponse<Blob>) => r.body as Blob)
    );
  }

  /**
   * Path part for operation todoItemsDelete
   */
  static readonly TodoItemsDeletePath = "/api/TodoItems/{id}";

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `todoItemsDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  todoItemsDelete$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Blob>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      TodoItemsService.TodoItemsDeletePath,
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
   * To access the full response (for headers, for example), `todoItemsDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  todoItemsDelete(params: { id: number }): Observable<Blob> {
    return this.todoItemsDelete$Response(params).pipe(
      map((r: StrictHttpResponse<Blob>) => r.body as Blob)
    );
  }

  /**
   * Path part for operation todoItemsUpdateItemDetails
   */
  static readonly TodoItemsUpdateItemDetailsPath =
    "/api/TodoItems/UpdateItemDetails";

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `todoItemsUpdateItemDetails()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  todoItemsUpdateItemDetails$Response(params: {
    id?: number;
    body: UpdateTodoItemDetailCommand;
  }): Observable<StrictHttpResponse<Blob>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      TodoItemsService.TodoItemsUpdateItemDetailsPath,
      "put"
    );
    if (params) {
      rb.query("id", params.id, {});
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
   * To access the full response (for headers, for example), `todoItemsUpdateItemDetails$Response()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  todoItemsUpdateItemDetails(params: {
    id?: number;
    body: UpdateTodoItemDetailCommand;
  }): Observable<Blob> {
    return this.todoItemsUpdateItemDetails$Response(params).pipe(
      map((r: StrictHttpResponse<Blob>) => r.body as Blob)
    );
  }
}
