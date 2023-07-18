import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Cnab } from '../models/cnab';

const URL_IMPORTACAO = '/api/v1/importacao';


@Injectable({
  providedIn: 'root'
})
export class CnabService {

  constructor(private http: HttpClient) { }

  getAll(dataImportacao: string): Observable<Cnab[]>{
    return this.http.get(`${environment.URL_API}${URL_IMPORTACAO}/?dataImportacao=${dataImportacao}`)
    .pipe(map((resp: any) => {
      return resp;
    }));
  }
}
