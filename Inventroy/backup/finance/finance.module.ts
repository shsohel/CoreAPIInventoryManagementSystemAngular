import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../common/module/material.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataService } from '../common/services/data.service';
import { AppCommonModule } from '../common/app-common.module';
import { FinanceRoutingModule } from './finance-routing.module';
import { AddInternalTransferComponent } from './components/internal-transfer/add-internal-transfer/add-internal-transfer.component';
import { InternalTansferListComponent } from './components/internal-transfer/internal-tansfer-list/internal-tansfer-list.component';
import { InternalTansferDetailsComponent } from './components/internal-transfer/internal-tansfer-details/internal-tansfer-details.component';
import { ExternalTansferDetailsComponent } from './components/external-transfer/external-tansfer-details/external-tansfer-details.component';
import { AddExternalTansferComponent } from './components/external-transfer/add-external-tansfer/add-external-tansfer.component';
import { ExternalTansferListComponent } from './components/external-transfer/external-tansfer-list/external-tansfer-list.component';
import { InternalTransferService } from './services/internal-transfer.service';
import { ExternalTransferService } from './services/external-transfer.service';
import { BankTransferListComponent } from './components/bank-transfer/bank-transfer-list/bank-transfer-list.component';
import { BankTransferDetailsComponent } from './components/bank-transfer/bank-transfer-details/bank-transfer-details.component';
import { AddBankTransferComponent } from './components/bank-transfer/add-bank-transfer/add-bank-transfer.component';
import { BankTransferService } from './services/bank-transfer.service';
import { AddBankAccountComponent } from './components/bank-Account/add-bank-account/add-bank-account.component';
import { BankAccountListComponent } from './components/bank-Account/bank-account-list/bank-account-list.component';
import { BankAccountDetailsComponent } from './components/bank-Account/bank-account-details/bank-account-details.component';
import { BankAccountService } from './services/bank-account.service';
import { AddExternalPersonComponent } from './components/external-person/add-external-person/add-external-person.component';
import { ExternalPersonListComponent } from './components/external-person/external-person-list/external-person-list.component';
import { ExternalPersonDetailsComponent } from './components/external-person/external-person-details/external-person-details.component';
import { ExternalPersonService } from './services/external-person.service';
import { VatListComponent } from './components/vat/vat-list/vat-list.component';
import { AddVatComponent } from './components/vat/add-vat/add-vat.component';
import { MatRadioModule } from '@angular/material/radio';
import { VatDetailsComponent } from './components/vat/vat-details/vat-details.component';
import { BusinessRelativeDetailsComponent } from './components/business-relative/business-relative-details/business-relative-details.component';
import { BusinessRelativeListComponent } from './components/business-relative/business-relative-list/business-relative-list.component';
import { AddBusinessRelativeComponent } from './components/business-relative/add-business-relative/add-business-relative.component';
import { BusinessRelativeService } from './services/business-relative.service';


@NgModule({
  declarations: [
      AddInternalTransferComponent,
      InternalTansferListComponent,
      InternalTansferDetailsComponent,
      AddExternalTansferComponent,
      ExternalTansferListComponent,
      ExternalTansferDetailsComponent,
      BankTransferListComponent,
      BankTransferDetailsComponent,
      AddBankTransferComponent,
      AddBankAccountComponent,
      BankAccountListComponent,
      BankAccountDetailsComponent,
      AddExternalPersonComponent,
      ExternalPersonListComponent,
      ExternalPersonDetailsComponent,
      VatListComponent,
      AddVatComponent,
      VatDetailsComponent,
      BusinessRelativeDetailsComponent,
      BusinessRelativeListComponent,
      AddBusinessRelativeComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HttpClientModule,
    FinanceRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    AppCommonModule,   
    MatRadioModule 
  ],
  providers:[
    DataService,
    InternalTransferService,
    ExternalTransferService,
    BankTransferService,
    BankAccountService,
    ExternalPersonService,
    BusinessRelativeService
  ]
})
export class FinanceModule { }