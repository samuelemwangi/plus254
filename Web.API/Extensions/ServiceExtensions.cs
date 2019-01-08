using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;

namespace Web.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //Check later
        }

        public static void ConfigureEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            var SMTPSettings = configuration.GetSection("SMTPServer");
            
            var smtpClient = new SmtpClient
            {
                Host = SMTPSettings["Uri"],
                Port = Int32.Parse(SMTPSettings["Port"]),
                UseDefaultCredentials = false,
                Credentials =  new NetworkCredential(SMTPSettings["AccountName"],SMTPSettings["AccountPassword"])

            };

            services.AddFluentEmail(SMTPSettings["SenderEmail"])
                .AddRazorRenderer()
                .AddSmtpSender(smtpClient);


        }
    }
}
