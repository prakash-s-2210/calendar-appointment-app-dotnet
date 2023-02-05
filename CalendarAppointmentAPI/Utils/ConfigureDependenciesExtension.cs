using CalendarEvents.Business;
using CalendarEvents.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CalendarEvents.Utils
{
    public static class ConfigureDependenciesExtension
    {
        public static void ConfigureDependencyInjections(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IUserDAL, UserDAL>();
            services.AddScoped<ICalendarEventsBL, CalendarEventsBL>();
            services.AddScoped<ICalendarEventsDAL, CalendarEventsDAL>();
        }
    }
}