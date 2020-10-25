import { UserInfo,Occupation } from './UserInfo.model';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PremiumCalcService {
  formData: UserInfo= {
    UserName: null,
    DOB: null,
    DeathCoverAmt: null,
    occupationId:null
  };
  
  readonly rootURL = 'http://localhost:56866/api/PremiumCalc';


  constructor(private http: HttpClient) { }




  GetOccupation(){
   return  this.http.get(this.rootURL + '/Occupations');
  }

  MonthlyPremiumCalc()
  {
    return this.http.post(this.rootURL + '/MonthlyPremiumCalculator', this.formData)
  }
}
