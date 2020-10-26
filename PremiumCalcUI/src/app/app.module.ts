import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbDateAdapter, NgbDateParserFormatter, NgbModule } from '@ng-bootstrap/ng-bootstrap';
 
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { PremiumUserComp } from './PremiumUser/PremiumUser.component';

import { PremiumCalcService } from "./shared/PremiumCalc.service"
import { CustomAdapter, CustomDateParserFormatter } from './NgbDateCustomParserFormatter';

@NgModule({
  declarations: [
    AppComponent,
    PremiumUserComp

  ],
  imports: [
    BrowserModule,
    FormsModule,
    NgbModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [PremiumCalcService,
    {provide: NgbDateAdapter, useClass: CustomAdapter},
    {provide: NgbDateParserFormatter, useClass: CustomDateParserFormatter}],
  bootstrap: [AppComponent]
})
export class AppModule { }
