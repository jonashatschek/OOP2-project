﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Library.Models;
using Library.Repositories;

namespace Library.Services
{
    public class AuthorService : IService
    {
        AuthorRepository _authorRepository;
        Author _author = new Author();
        public event EventHandler Updated;

        public AuthorService(RepositoryFactory repoFactory)
        {
            _authorRepository = repoFactory.GetAuthorRepository();
        }

        /// <summary>
        /// calls the All-method in Author repository
        /// </summary>
        /// <returns>a collection of all Author type objects in database</returns>
        public IEnumerable<Author> All()
        {
            return _authorRepository.All();
        }

        /// <summary>
        /// calls the Add method in the Author repository sending in a new object
        /// </summary>
        /// <param name="name">author name</param>
        public void AddNewAuthor(string name)
        {
            _author.AuthorName = name;
            _authorRepository.Add(_author);

            OnUpdated();
        }

        protected virtual void OnUpdated()
        {
            Updated?.Invoke(this, EventArgs.Empty);
        }

    }
}