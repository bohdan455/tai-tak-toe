import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {Configuration} from "../../environments/configuration";

export abstract class BaseService {
  protected constructor(private http: HttpClient) {
  }

  protected get<TModel>(url: string): Observable<TModel> {
    return this.http.get<TModel>(Configuration.baseUrl + url);
  }

  protected post<TRequestModel, TResponseModel>(url: string, body: TRequestModel): Observable<TResponseModel> {
    return this.http.post<TResponseModel>(Configuration.baseUrl + url, body);
  }

  protected put<TRequestModel, TResponseModel>(url: string, body: TRequestModel): Observable<TResponseModel> {
    return this.http.put<TResponseModel>(Configuration.baseUrl + url, body);
  }

  protected delete<TRequestModel, TResponseModel>(url: string, body: TRequestModel): Observable<TResponseModel> {
    return this.http.delete<TResponseModel>(Configuration.baseUrl + url, body);
  }
}
