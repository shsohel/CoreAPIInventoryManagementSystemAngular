import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';


@Component({
  selector: 'app-app-mat-dialog',
  templateUrl: './app-mat-dialog.component.html',
  styleUrls: ['./app-mat-dialog.component.css']
})
export class AppMatDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<AppMatDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) { }

  onNoClick(): void {
    this.dialogRef.close(this.data);
  }
}
export class DialogData {
  name: string;
  message: string;
  action: string;
  no: string;
}
