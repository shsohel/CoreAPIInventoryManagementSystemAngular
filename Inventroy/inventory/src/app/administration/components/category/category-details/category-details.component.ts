import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from 'src/app/administration/services/category.service';
import { CategoryStatusCode } from 'src/app/administration/enums/category-status-code.enum';
import { Category } from 'src/app/administration/model/category.model';
import { PriorityCode } from 'src/app/administration/enums/priority.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrls: ['./category-details.component.css']
})
export class CategoryDetailsComponent implements OnInit {
  categoryId: number;
  lstParentCategory: Category []=[];
  categoryDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private categoryService: CategoryService, private matSnackBar: MatSnackBar, ) { }

  ngOnInit() {
    this.getCategoryDetails();
    this.getCategroyParent();
  }
  getCategoryDetails(): void {
    this.activatedRoute.paramMap.subscribe(e => {
      this.categoryId = +e.get('id');
      if (this.categoryId != null) {
        this.categoryService.GetDetails(this.categoryId).subscribe((res: any) => {
          this.categoryDetails = res.obj;
          console.log(this.categoryDetails)
        }, e => {
          this.matSnackBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  getCategroyParent(): void {
    this.categoryService.GetTableData().subscribe((res: any) => {
      this.lstParentCategory = <Category[]>res.obj;
      console.log(this.lstParentCategory);
    })
  }
  getStatus(id: number): string {
    if (id != 0) {
      return CategoryStatusCode[id];
    }
    return ""
  }
  getPrioriyt(id: number): string {
    if (id != 0) {
      return PriorityCode[id];
    }
    return ""
  }
  getParenCategory(idd: number) {
    //console.log('parentid: '+idd)
    if (idd <= 0 || idd == undefined) {
      return "It is a Parent Category";
    }
    let parentNamename;
    if (this.lstParentCategory != undefined) {
      let obj = this.lstParentCategory.filter(x => {
        if (x.id == idd) {
          parentNamename = x.name
        }
        //console.log('parentName : '+parentNamename)
      });
    }
    return parentNamename;
  }

  // getParenCategory(idd: number) {
  //   console.log(idd)
  //   if (idd != 0) {
  //     return Category[idd]
  //   }
  //   return ""
  // }
}
