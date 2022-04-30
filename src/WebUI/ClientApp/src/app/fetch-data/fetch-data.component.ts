import { Component } from '@angular/core';
import { WeatherForecastDto } from '../api/models/weather-forecast-dto';
import { WeatherForecastService } from '../api/services/weather-forecast.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecastDto[];

  constructor(private client: WeatherForecastService) {
    client.weatherForecastGet().subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}
