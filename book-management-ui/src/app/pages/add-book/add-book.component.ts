import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Book } from '../../models/book';
import { BookService } from '../../services/book.service';

@Component({
selector:'app-add-book',
templateUrl:'./add-book.component.html'
})
export class AddBookComponent{

book:Book={
title:'',
author:'',
isbn:'',
publicationDate:''
};

constructor(private bookService:BookService,
private router:Router){}

addBook(){

this.bookService.addBook(this.book).subscribe(()=>{
this.router.navigate(['/']);
});

}

}
