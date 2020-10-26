import { Component, OnInit } from '@angular/core'
import { formArrayNameProvider } from '@angular/forms/src/directives/reactive_directives/form_group_name';
import { PremiumCalcService } from "../shared/PremiumCalc.service"
import { Occupation } from "../shared/UserInfo.model";
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { analyzeAndValidateNgModules } from '@angular/compiler';


@Component({
  selector: 'user-details',
  templateUrl: './PremiumUser.component.html',
  styles: []
})

export class PremiumUserComp implements OnInit {
  occupations: Occupation[];
  selectedOccupation: Occupation;
  MonthlyPremiumAmt: string;
  ErrorTitle: string = 'Monthly Premium Calculator';
  DOB: any;
  maxDate: any;
  now: Date=new Date();
  constructor(private service: PremiumCalcService, private toastr: ToastrService) {
    // this.maxDate={year:new Date().getFullYear(),month: 12, day: 31}
this.maxDate={year: this.now.getFullYear(), month: this.now.getMonth()+1, day: this.now.getDate()}
    this.service.GetOccupation().subscribe((res: any) => {
      this.occupations = res.occupations;      
    });
  }
 
  onSelect(occupationId) {
    let dte:any;
    if (this.service.formData.UserName == null || this.service.formData.UserName == '') {
      this.toastr.error("Please enter the user name", this.ErrorTitle);
    }
    else if (this.DOB == null) {
      this.toastr.error("Please select the Date of Birth", this.ErrorTitle);
    }
    else if (this.service.formData.DeathCoverAmt == null) {
      this.toastr.error("Please enter the death cover amount", this.ErrorTitle);
    }
    else if (occupationId == 'undefined') {
      this.toastr.error("Please select the occupation", this.ErrorTitle);
      this.MonthlyPremiumAmt = null;
    }    
    else {
      dte = this.DOB.split('-');
      this.service.formData.DOB = dte[1] + "/" +dte[0] + "/" + dte[2];
      this.service.formData.occupationId = occupationId;
      this.GetPremiumAmt();
      this.selectedOccupation = this.occupations.find(occ => occ.occupationId == occupationId);
    }
  }


  GetPremiumAmt() {
    this.service.MonthlyPremiumCalc().subscribe(
      (res: any) => {
        this.MonthlyPremiumAmt =' $' + res.monthlyPremiumAmout + ' cents';
      },
      err => {
        this.MonthlyPremiumAmt = null;
        if (err.error.DOB) {
          err.error.DOB.forEach(element => {
            this.toastr.error(element, this.ErrorTitle);
          });
        }
        else if (err.error.DeathCoverAmt) {
          err.error.DeathCoverAmt.forEach(element => {
            this.toastr.error(element, this.ErrorTitle);
          });
        }
        else {
          this.toastr.error("Server error occured", this.ErrorTitle);
        }
      }
    )
  }
  ngOnInit() {
  }
}
