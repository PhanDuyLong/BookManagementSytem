
﻿using BookManagementSystemData.Models;
using BookManagementSystemData.Repositories;
using BookManagementSystemData.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HMS.Data.DependencyInjection
{
    public static class DependencyInjectionResolverGen
    {
        public static void IntializerDI(this IServiceCollection services)
        {
            services.AddScoped<DbContext, BMSDBContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IBorrowTicketRepository, BorrowTicketRepository>();
            services.AddScoped<IBorrowTicketService, BorrowTicketService>();

            services.AddScoped<IBorrowTicketDetailRepository, BorrowTicketDetailRepository>();
            services.AddScoped<IBorrowTicketDetailService, BorrowTicketDetailService>();
        }
    }
}