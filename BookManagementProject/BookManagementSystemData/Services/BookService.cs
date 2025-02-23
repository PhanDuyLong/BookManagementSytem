﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookManagementSystemData.Models;
using BookManagementSystemData.Parameters;
using BookManagementSystemData.Repositories;
using BookManagementSystemData.Utilities;
using BookManagementSystemData.ViewModels;
using BookManagementSystemData.ViewModels.Book;
using HMS.Data.Services.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystemData.Services
{
    public interface IBookService : IBaseService<Book>
    {
        void DeleteBook(Book book);
        Task<BookDetailViewModel> GetBookAsync(int id);
        Task<PaginatedList<BookDetailViewModel>> GetBooksAsync(BookParameters bookParameters);
        void UpdateBook(Book book, UpdateBookViewModel model);
        Task CreateBookAsync(CreateBookViewModel model);
    }
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowTicketDetailRepository _borrowTicketDetailRepository;
        public BookService(DbContext dbContext, IBookRepository repository, IMapper mapper,
            IBorrowTicketDetailRepository borrowTicketDetailRepository) : base(dbContext, repository)
        {
            _borrowTicketDetailRepository = borrowTicketDetailRepository;
            _mapper = mapper;
            _bookRepository = repository;
        }

        public List<T> MappingBookListDto<T>(List<Book> books)
        {
            var booksMapping = _mapper.Map<List<T>>(books);
            return booksMapping;
        }

        public void DeleteBook(Book book)
        {
            book.Status = "Deleted";
            Update(book);
        }

        public async Task<PaginatedList<BookDetailViewModel>> GetBooksAsync(BookParameters bookParameters)
        {
            var companies = _bookRepository.FindBooksAsync(bookParameters);

            var model = await companies.ProjectTo<BookDetailViewModel>(_mapper.ConfigurationProvider).ToListAsync();
            var item = _borrowTicketDetailRepository.Get();

            foreach(var b in model)
            {
                if(item.Where(a => a.BookId == b.Id).Any(a => a.IsReturned == false))
                {
                    b.Status = "Borrowing";
                }
            }

            return PaginatedList<BookDetailViewModel>.ToPagedList(model, bookParameters.PageNumber, bookParameters.PageSize);
        }

        public async Task<BookDetailViewModel> GetBookAsync(int id)
        {
            var book = await Get().Where(b => b.Id.Equals(id) && b.Status.Equals("Deleted")).ProjectTo<BookDetailViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            
            return book;
        }

        public void UpdateBook(Book book, UpdateBookViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Name)) book.Name = model.Name;
            if (!string.IsNullOrEmpty(model.Author)) book.Author = model.Author;
            if (model.PublishedDate != null) book.PublishedDate = model.PublishedDate.Value;
            if (!string.IsNullOrEmpty(model.Status)) book.Status = model.Status;
            if (model.CategoryId != null) book.CategoryId = model.CategoryId.Value;
            Update(book);
        }

        public async Task CreateBookAsync(CreateBookViewModel model)
        {
            var book = _mapper.Map<Book>(model);
            book.Status = "Active";
            await CreateAsyn(book);
        }
    }
}
