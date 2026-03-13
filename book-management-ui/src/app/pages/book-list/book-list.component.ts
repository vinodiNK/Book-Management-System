import { Component, OnInit } from '@angular/core';
import { Book } from '../../models/book';
import { BookService } from '../../services/book.service';

@Component({
  selector:'app-book-list',
  templateUrl:'./book-list.component.html'
})
export class BookListComponent implements OnInit{

  books:Book[]=[];

  constructor(private bookService:BookService){}

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(){
    this.bookService.getBooks().subscribe(data=>{
      this.books=data;
    });
  }

  deleteBook(id:number){
    if(confirm("Delete this book?")){
      this.bookService.deleteBook(id).subscribe(()=>{
        this.loadBooks();
      });
    }
  }

}
