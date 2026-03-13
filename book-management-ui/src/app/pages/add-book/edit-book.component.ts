import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../../models/book';
import { BookService } from '../../services/book.service';

@Component({
selector:'app-edit-book',
templateUrl:'./edit-book.component.html'
})
export class EditBookComponent implements OnInit{

book:Book={
title:'',
author:'',
isbn:'',
publicationDate:''
};

id:number=0;

constructor(
private route:ActivatedRoute,
private router:Router,
private bookService:BookService
){}

ngOnInit(){

this.id=Number(this.route.snapshot.paramMap.get('id'));

this.bookService.getBook(this.id).subscribe(data=>{
this.book=data;
});

}

updateBook(){

this.bookService.updateBook(this.id,this.book).subscribe(()=>{
this.router.navigate(['/']);
});

}

}
