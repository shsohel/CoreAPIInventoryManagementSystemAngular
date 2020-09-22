import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatTableModule} from '@angular/material/table'; 
import { MatPaginatorModule } from '@angular/material/paginator';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatCardModule} from '@angular/material/card';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatDialogModule} from '@angular/material/dialog';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatStepperModule} from '@angular/material/stepper';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { LayoutModule } from '@angular/cdk/layout';
import {MatBadgeModule} from '@angular/material/badge';
import {MatMenuModule} from '@angular/material/menu';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatDividerModule} from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { MatSortModule } from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatRadioModule } from '@angular/material/radio';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatTooltipModule } from '@angular/material/tooltip';

import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTabsModule } from '@angular/material/tabs';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
@NgModule({
  imports: [
    CommonModule, 
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatRippleModule,
    MatCheckboxModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatChipsModule,
    MatDatepickerModule,
    MatCardModule,
    MatAutocompleteModule,
    MatDialogModule,
    MatToolbarModule,
    MatStepperModule,
    MatProgressBarModule,
    LayoutModule,
    MatBadgeModule,
    MatMenuModule,
    MatSnackBarModule,
    MatSelectModule,
    MatDividerModule,
    MatRadioModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSidenavModule,
    MatListModule,
    MatGridListModule,
    MatTabsModule,
    MatExpansionModule,
    MatButtonToggleModule,
    MatProgressSpinnerModule,
    MatTooltipModule,
  ],
  exports:[
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatRippleModule,
    MatCheckboxModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatChipsModule,
    MatDatepickerModule,
    MatNativeDateModule ,
    MatCardModule,
    MatAutocompleteModule,
    MatDialogModule,
    MatToolbarModule,
    MatStepperModule,
    MatProgressBarModule,
    MatBadgeModule,
    MatMenuModule,
    MatSnackBarModule,
    MatSelectModule,
    MatDividerModule,
    MatRadioModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSidenavModule,
    MatListModule,
    MatGridListModule,
    MatTabsModule,
    MatExpansionModule,
    MatButtonToggleModule,
    MatProgressSpinnerModule,
    MatTooltipModule,
  ],
  providers: [
    MatDatepickerModule
  ],
  entryComponents:[
    //AppMatDialogComponent
  ]
})
export class MaterialModule { }
