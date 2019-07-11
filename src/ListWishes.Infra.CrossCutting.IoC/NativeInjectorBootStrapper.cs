using ListWishes.Application.Interfaces;
using ListWishes.Application.Services;
using ListWishes.Domain.CommandHandlers;
using ListWishes.Domain.Commands;
using ListWishes.Domain.Core.Bus;
using ListWishes.Domain.Core.Events;
using ListWishes.Domain.Core.Notifications;
using ListWishes.Domain.EventHandlers;
using ListWishes.Domain.Events;
using ListWishes.Domain.Interfaces;
using ListWishes.Infra.CrossCutting.Bus;
using ListWishes.Infra.Data.Context;
using ListWishes.Infra.Data.EventSourcing;
using ListWishes.Infra.Data.Repository;
using ListWishes.Infra.Data.Repository.EventSourcing;
using ListWishes.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ListWishes.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<UserRegisteredEvent>, UserEventHandler>();
            services.AddScoped<INotificationHandler<UserUpdatedEvent>, UserEventHandler>();
            services.AddScoped<INotificationHandler<UserRemovedEvent>, UserEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUserCommand, bool>, UserCommandHandler>();

            // Infra - Data
            services.AddScoped<IUserRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EquinoxContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}