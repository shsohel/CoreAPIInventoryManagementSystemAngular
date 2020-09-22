import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class MatTableService {
    showSearchBox(id: string, show: boolean) {
        if (show) {
            (<HTMLElement>document.getElementById(id)).style.display = "none";
        } else {
            (<HTMLElement>document.getElementById(id)).style.display = "block";
            (<HTMLElement>document.getElementsByClassName("table-search-form-div")[0]).style.display = "block";
            (<HTMLElement>document.getElementsByTagName("body")[0]).classList.add("stop-scrolling");
        }
    }
    closeSearchBox(show: boolean) {
        (<HTMLElement>document.getElementsByClassName("table-search-form-div")[0]).style.display = "none";
        var elements = document.getElementsByClassName("table-search-form");
        for (var i = 0; elements.length > i; i++) {
            (<HTMLElement>elements[i]).style.display = "none";
        }
        (<HTMLElement>document.getElementsByTagName("body")[0]).classList.remove("stop-scrolling");
    }
    isAssending = true;
    isDesending;
    showHideUpDowmIcon(event) {
        const itemsUp = document.getElementsByClassName("fa-sort-amount-down");
        const itemsDown = document.getElementsByClassName("fa-sort-amount-up");
        if (this.isAssending) {
            for (var i = 0; i < itemsDown.length; i++) {
                (<HTMLElement>itemsDown[i]).style.display = "none";
                (<HTMLElement>itemsUp[i]).style.display = "inline";
            }
            (<HTMLElement>itemsUp[event]).style.display = "none";
            (<HTMLElement>itemsDown[event]).style.display = "inline";
            this.isAssending = !this.isAssending;
        }
        else {
            for (var i = 0; i < itemsDown.length; i++) {
                (<HTMLElement>itemsDown[i]).style.display = "none";
                (<HTMLElement>itemsUp[i]).style.display = "inline";
            }
            (<HTMLElement>itemsUp[event]).style.display = "inline";
            (<HTMLElement>itemsDown[event]).style.display = "none";
            this.isAssending = !this.isAssending;
        }
    }
}