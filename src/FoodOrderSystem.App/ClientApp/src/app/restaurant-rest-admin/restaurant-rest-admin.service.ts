import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { RestaurantModel, AddressModel } from '../restaurant/restaurant.model';

@Injectable()
export class RestaurantRestAdminService {
  private baseUrl: string = "api/v1/restaurantadmin";

  constructor(
    private http: HttpClient,
    private authService: AuthService
  ) { }

  public getRestaurantAsync(id: string): Observable<RestaurantModel> {
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + this.authService.getToken(),
      })
    };
    return this.http.get<RestaurantModel>(this.baseUrl + '/restaurants/' + encodeURIComponent(id), httpOptions);
  }

  public changeRestaurantNameAsync(id: string, name: string): Observable<RestaurantModel> {
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + this.authService.getToken(),
      })
    };
    return this.http.post<RestaurantModel>(this.baseUrl + '/restaurants/' + encodeURIComponent(id) + "/changename", { name: name }, httpOptions);
  }

  public changeRestaurantImageAsync(id: string, image: string): Observable<RestaurantModel> {
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + this.authService.getToken(),
      })
    };
    return this.http.post<RestaurantModel>(this.baseUrl + '/restaurants/' + encodeURIComponent(id) + "/changeimage", { image: image}, httpOptions);
  }

  public changeRestaurantAddressAsync(id: string, address: AddressModel): Observable<RestaurantModel> {
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + this.authService.getToken(),
      })
    };
    return this.http.post<RestaurantModel>(this.baseUrl + '/restaurants/' + encodeURIComponent(id) + "/changeaddress", address, httpOptions);
  }

  public changeRestaurantContactDetailsAsync(id: string, phone: string, webSite: string, imprint: string, orderEmailAddress: string): Observable<RestaurantModel> {
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + this.authService.getToken(),
      })
    };
    return this.http.post<RestaurantModel>(this.baseUrl + '/restaurants/' + encodeURIComponent(id) + "/changecontactdetails", { phone: phone, webSite: webSite, imprint: imprint, orderEmailAddress: orderEmailAddress }, httpOptions);
  }

  public changeRestaurantDeliveryDataAsync(id: string, minimumOrderValue: number, deliveryCosts: number): Observable<RestaurantModel> {
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + this.authService.getToken(),
      })
    };
    return this.http.post<RestaurantModel>(this.baseUrl + '/restaurants/' + encodeURIComponent(id) + "/changedeliverydata", { minimumOrderValue: minimumOrderValue, deliveryCosts: deliveryCosts }, httpOptions);
  }

  public addDeliveryTimeToRestaurantAsync(id: string, dayOfWeek: number, start: number, end: number): Observable<RestaurantModel> {
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + this.authService.getToken(),
      })
    };
    return this.http.post<RestaurantModel>(this.baseUrl + '/restaurants/' + encodeURIComponent(id) + "/adddeliverytime", { dayOfWeek: dayOfWeek, start: start, end: end }, httpOptions);
  }

  public removeDeliveryTimeFromRestaurantAsync(id: string, dayOfWeek: number, start: number): Observable<RestaurantModel> {
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + this.authService.getToken(),
      })
    };
    return this.http.post<RestaurantModel>(this.baseUrl + '/restaurants/' + encodeURIComponent(id) + "/removedeliverytime", { dayOfWeek: dayOfWeek, start: start }, httpOptions);
  }

}
