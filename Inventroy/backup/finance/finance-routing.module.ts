import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddInternalTransferComponent } from './components/internal-transfer/add-internal-transfer/add-internal-transfer.component';
import { InternalTansferListComponent } from './components/internal-transfer/internal-tansfer-list/internal-tansfer-list.component';
import { InternalTansferDetailsComponent } from './components/internal-transfer/internal-tansfer-details/internal-tansfer-details.component';
import { AddExternalTansferComponent } from './components/external-transfer/add-external-tansfer/add-external-tansfer.component';
import { ExternalTansferListComponent } from './components/external-transfer/external-tansfer-list/external-tansfer-list.component';
import { ExternalTansferDetailsComponent } from './components/external-transfer/external-tansfer-details/external-tansfer-details.component';
import { AddBankTransferComponent } from './components/bank-transfer/add-bank-transfer/add-bank-transfer.component';
import { BankTransferListComponent } from './components/bank-transfer/bank-transfer-list/bank-transfer-list.component';
import { BankTransferDetailsComponent } from './components/bank-transfer/bank-transfer-details/bank-transfer-details.component';
import { AddBankAccountComponent } from './components/bank-Account/add-bank-account/add-bank-account.component';
import { BankAccountListComponent } from './components/bank-Account/bank-account-list/bank-account-list.component';
import { BankAccountDetailsComponent } from './components/bank-Account/bank-account-details/bank-account-details.component';
import { AddExternalPersonComponent } from './components/external-person/add-external-person/add-external-person.component';
import { ExternalPersonListComponent } from './components/external-person/external-person-list/external-person-list.component';
import { ExternalPersonDetailsComponent } from './components/external-person/external-person-details/external-person-details.component';
import { VatListComponent } from './components/vat/vat-list/vat-list.component';
import { AddVatComponent } from './components/vat/add-vat/add-vat.component';
import { VatDetailsComponent } from './components/vat/vat-details/vat-details.component';
import { AddBusinessRelativeComponent } from './components/business-relative/add-business-relative/add-business-relative.component';
import { BusinessRelativeListComponent } from './components/business-relative/business-relative-list/business-relative-list.component';
import { BusinessRelativeDetailsComponent } from './components/business-relative/business-relative-details/business-relative-details.component';

const routes: Routes = [
  { path: "addInternalTransfer", component: AddInternalTransferComponent},
  { path: "addInternalTransfer/:id", component: AddInternalTransferComponent},
  { path: "internalTransferList", component: InternalTansferListComponent},
  { path: "internalTransferDetails/:id", component: InternalTansferDetailsComponent},
  { path: "addExternalTransfer", component: AddExternalTansferComponent},
  { path: "addExternalTransfer/:id", component: AddExternalTansferComponent},
  { path: "externalTransferList", component: ExternalTansferListComponent},
  { path: "externalTransferDetails/:id", component: ExternalTansferDetailsComponent},
  { path: "addBankTransfer", component: AddBankTransferComponent},
  { path: "addBankTransfer/:id", component: AddBankTransferComponent},
  { path: "bankTransferList", component: BankTransferListComponent},
  { path: "bankTransferDetails/:id", component: BankTransferDetailsComponent},
  { path: "addBankAccount", component: AddBankAccountComponent},
  { path: "addBankAccount/:id", component: AddBankAccountComponent},
  { path: "bankAccountList", component: BankAccountListComponent},
  { path: "bankAccountDetails/:id", component: BankAccountDetailsComponent},
  { path: "addExternalPerson", component: AddExternalPersonComponent},
  { path: "addExternalPerson/:id", component: AddExternalPersonComponent},
  { path: "externalPersonList", component: ExternalPersonListComponent},
  { path: "externalPersonDetails/:id", component: ExternalPersonDetailsComponent},
  { path: "vatList", component: VatListComponent},
  { path: "addVat", component: AddVatComponent},
  { path: "addVat/:id", component: AddVatComponent},
  { path: "vatDetails/:id", component: VatDetailsComponent},
  { path: "addBusinessRelative", component: AddBusinessRelativeComponent},
  { path: "addBusinessRelative/:id", component: AddBusinessRelativeComponent},
  { path: "businessRelativeList", component: BusinessRelativeListComponent},  
  { path: "businessRelativeDetails/:id", component: BusinessRelativeDetailsComponent},




]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class FinanceRoutingModule { }