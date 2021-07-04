import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/administration/model/category.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { CategoryService } from 'src/app/administration/services/category.service';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {
  category: Category = new Category();
  lstCategory:any;
  addCategoryForm: FormGroup;
  reset: any = [{}];
  categoryId: number;
  //document: ImageDetails = new ImageDetails();
  response: ResponseMessage = new ResponseMessage();
  isDisable: boolean = false;
  constructor(private _formBuilder: FormBuilder, private categroyService:CategoryService,  private dataService: DataService,private matSnakBar: MatSnackBar,
    private router: Router, private activeRoute: ActivatedRoute) {
    this.addCategoryForm = this._formBuilder.group({
      id: [''],
      parentId: [''],
      // categoryNo: ['', Validators.required],
      priority: ['', Validators.required],
      name: ['', Validators.required],
      description: ['', Validators.required]
    })
  }

  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.categoryId = +param.get("id");
      console.log(this.categoryId)
      if (this.categoryId > 0) {
        this.categroyService.getById(this.categoryId).subscribe((suc: any) => {
          console.log("hi")
          console.log(suc);
          //console.log(suc.vendor)
          this.category = suc.obj;
          this.addCategoryForm.patchValue(this.category);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
    this.categroyService.GetTableData().subscribe((res: any) => {
      this.lstCategory = <Category>res.obj;
      console.log(this.lstCategory);
    })
  }
  onSubmit() {
    this.category = this.addCategoryForm.value;
    if (this.categoryId > 0) {
      this.category.id = this.categoryId;
      this.categroyService.put(this.category).subscribe((res: any) => {
       this.workWithResponse(res);
      })
    }
    else {
      this.categroyService.post(this.category).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
  }
  workWithResponse(res: ResponseMessage) {
    this.response.message = res.message;
    this.response.statusCode = res.statusCode;
    if (this.response.statusCode == ResponseStatusCodeEnum.Success) {
      this.dataService.setValueToResponseMessageProperty(this.response);
      
    }
    else {
      this.matSnakBar.open(this.response.message, 'Ok', {
        duration: 10000
      })
      this.router.navigateByUrl("/administration/categoryList");
    }
  }
}
