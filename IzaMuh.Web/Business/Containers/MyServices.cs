using Business.Abstract;
using Business.Concrete;
using Business.FluentValidation;
using DataAccess.Concrete;
using DataAccess.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Containers
{
    public static class MyServices
    {
        public static IServiceCollection MyServiceInstance(this IServiceCollection services)
        {
            services.AddDbContext<IzaContext>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<ICommentsService, CommentsService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IPhotoService, PhotoService>();



            services.AddSingleton<IValidator<Comments>, ValidationComments>();
            services.AddSingleton<IValidator<News>, ValidationNews>();
            services.AddSingleton<IValidator<Service>, ValidationService>();
            services.AddSingleton<IValidator<Users>, ValidationUsers>();




            return services;

        }
    }
}
