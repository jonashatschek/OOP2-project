﻿using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services {
    public class BookService : IService
    {
        BookRepository _bookRepository;
        Book _book = new Book();
        Author _author = new Author();

        public event EventHandler Updated;

        public BookService(RepositoryFactory repoFactory)
        {
            _bookRepository = repoFactory.GetBookRepository();
        }

        public IEnumerable<Book> All()
        {
            return _bookRepository.All();
        }

        public void AddNewBook(string title, string isbn, string description, string authorName)
        {
            _book.BookTitle = title;
            _book.BookIsbn = isbn;
            _book.BookDescription = description;
            _author.AuthorName = authorName;
            _book.BookAuthor = _author;

            _bookRepository.Add(_book);
            OnUpdated();

        }

        public void RemoveBook(Book book)
        {

            _bookRepository.Remove(book);
            OnUpdated();
        }

        public void EditBook(Book book)
        {
            _bookRepository.Edit(book);
        }


        public void ListAvailableBooks()
        {
            var query = from b in _bookRepository.All()
                where b.BookCopy.Count > 0
                select b;

            foreach (Book b in query)
            {
                //add to listbox when created
            }
        }

        public void ListAllBooksByAuthor(Author authorName, Book bookId)
        {
            var query = from m in _bookRepository.All()
                where m.BookAuthor.Equals(authorName)
                select m;

            foreach (Book book in query)
            {
                //add to listbox when created
            }
        }

        public void EditBook(int id)
        {
            _bookRepository.Find(id);
        }

        protected virtual void OnUpdated()
        {
            Updated?.Invoke(this, EventArgs.Empty);
        }

    }
}