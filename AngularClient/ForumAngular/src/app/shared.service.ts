import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable, retryWhen } from 'rxjs';
import { first, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "https://localhost:44392/api";
  
    constructor(private http: HttpClient) { }
}
