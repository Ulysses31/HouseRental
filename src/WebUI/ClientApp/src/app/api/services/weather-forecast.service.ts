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

import { WeatherForecastDto } from "../models/weather-forecast-dto";

@Injectable({
  providedIn: "root",
})
export class WeatherForecastService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
    super(config, http);
  }

  /**
   * Path part for operation weatherForecastGet
   */
  static readonly WeatherForecastGetPath = "/api/WeatherForecast";

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `weatherForecastGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  weatherForecastGet$Response(params?: {}): Observable<
    StrictHttpResponse<Array<WeatherForecastDto>>
  > {
    const rb = new RequestBuilder(
      this.rootUrl,
      WeatherForecastService.WeatherForecastGetPath,
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
          return r as StrictHttpResponse<Array<WeatherForecastDto>>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `weatherForecastGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  weatherForecastGet(params?: {}): Observable<Array<WeatherForecastDto>> {
    return this.weatherForecastGet$Response(params).pipe(
      map(
        (r: StrictHttpResponse<Array<WeatherForecastDto>>) =>
          r.body as Array<WeatherForecastDto>
      )
    );
  }
}
