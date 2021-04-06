import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Carbrand } from './carbrand';
import { GlobalConstants } from '../common/global-constants';

const httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};
const baseURL = GlobalConstants.baseURL;
const endpoint = GlobalConstants.carBrandEndpoint;

@Injectable({
  providedIn: 'root'
})
export class CarbrandService {
  url = baseURL + endpoint;
  
  /**
   * Creates an instance of the carbrand.service.
   * @param http The HttpClient.
   */
  constructor(private http: HttpClient) { }

  /**
   * Service to call the endpoint to get a Car Brand by name.
   * @param {string} name The Car Brand name.
   */
  getCarBrandByName(name: string): Observable<Carbrand> {  
    const apiurl = `${this.url}/${name}`;
    return this.http.get<Carbrand>(apiurl);  
  } 
  
  /**
   * Service to call the endpoint to create a Car Brand.
   * @param {string} name The Car Brand name.
   */
  createCarBrand(carBrand: Carbrand): Observable<Carbrand> {  
    return this.http.post<Carbrand>(this.url, carBrand, httpOptions);  
  }
}
