using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoForDI31.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace demoForDI31
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region ע�����ͬ�������ڵķ���

            services.AddSingleton<IMySingletonService, MySingletonService>();
            services.AddScoped<IMyScopedService, MyScopedService>();
            services.AddTransient<IMyTransientService, MyTransientService>();

            #endregion

            #region ��ʽע��

            services.AddSingleton<IOrderService>(new OrderService());
            //services.AddSingleton<IOrderService, OrderServiceEx>();
            //services.AddSingleton<IOrderService>(serviceProvider =>
            //{
            //    return new OrderService();
            //});

            #endregion

            #region ����ע��

            //services.TryAddSingleton<IOrderService, OrderServiceEx>();
            //services.TryAddEnumerable(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());

            #endregion

            #region �Ƴ�ע��

            //services.RemoveAll<IOrderService>();

            #endregion

            #region �滻ע��

            //services.Replace(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());

            #endregion

            #region ע�᷺��ģ��

            services.AddSingleton(typeof(IGenericService<>), typeof(GenericService<>));

            #endregion


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
