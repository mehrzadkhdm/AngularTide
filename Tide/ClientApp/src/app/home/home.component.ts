
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})

export class HomeComponent {
    public forecasts: WeatherForecast[];
    public ports: PortName[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<PortName[]>(baseUrl + 'port').subscribe(result => {
            this.ports = result;
        }, error => console.error(error));

    }
}

interface WeatherForecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

interface PortName {
    name: string;
}

