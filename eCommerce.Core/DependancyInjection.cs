using eCommerce.Core.Services;
using eCommerce.Core.ServicesContract;
using eCommerce.Core.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core;
    public static class DependancyInjection
    {
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IUserServices, UserServices>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }

}

