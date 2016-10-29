﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Services;

namespace Library
{
    public partial class AddBookForm : Form
    {
        private BookService _bookService;
        private BookCopyService _bookCopyService;
        private AuthorService _authorService;

        public AddBookForm(BookService bookservice, BookCopyService bookCopyService, AuthorService authorService)
        {
            _bookService = bookservice;
            _bookCopyService = bookCopyService;
            _authorService = authorService;
            InitializeComponent();
        }

        private void booksAdd_btn_Click(object sender, EventArgs e)
        {
            _bookService.AddNewBook(addBookTitle_textbox.Text, addBookIsbn_textbox.Text, addBookDescription_richTextBox.Text, addBookAuthor_textbox.Text);
            this.Close();
        }

        private void addBookAuthor_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBookForm_Load(object sender, EventArgs e)
        {

        }
    }
    /*
    public partial class EditBookForm : Form
    {
        private BookService _book;
        private AuthorService _author;
        private BookCopyService _bookCopy;

        public EditBookForm (BookService book, AuthorService author, BookCopyService bookCopy)
        {
            _book = book;
            _author = author;
            _bookCopy = bookCopy;

        }
    }
    */
}