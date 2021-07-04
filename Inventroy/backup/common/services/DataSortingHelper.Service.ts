import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class DataSortingHelperService {
    sortNumericType(first: number, second: number, isAssending: boolean): number {
        if (isAssending) {
            return Number(first) - Number(second);
        }
        else {
            return Number(second) - Number(first);
        }
    }
    sortStringType(first: string, second: string, isAssending: boolean): number {
        var x = first != null? first.toLowerCase(): " ";
        var y = second != null? second.toLowerCase(): " ";
        if (isAssending) {
            return x < y ? -1 : x > y ? 1 : 0;
        }
        else {
            return x < y ? 1 : x > y ? -1 : 0;
        }
    }
    sortDateType(first: string, second: string, isAssending: boolean): number {
        var x = new Date(first);
        var y = new Date(second);
        if (isAssending) {
            return x < y ? -1 : x > y ? 1 : 0;
        }
        else {
            return x < y ? 1 : x > y ? -1 : 0;
        }
    }
    // sortsNumericType(objectToSort: any, columnToSort: number): any {
    //     objectToSort.sort((a, b) =>{
    //         a = "a."+columnToSort;
    //         b = "b."+columnToSort;
    //         return Number(a) - Number(b);
    //     })
    // }
}