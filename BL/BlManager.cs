using BL.Api;
using BL.Services;
using DAL;
using DAL.Appi;
using DAL.Models;
using DAL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BlManager : IBl
    {
        public IblClient Client { get; }

        public IblCustomerType CustomerType { get; }

        public Ibldeal Deal { get; }

        public IblIllustrationViewPoint IblIllustrationViewPoint { get; }

        //public IblOrder Order { get; }
        public IblOrder IblOrder { get; }

        public IblOrderDetails IblOrderDetails { get; }

        public IblRecommend IblRecommend { get; }
        public IblProject IblProject { get; }

        public BlManager()
        {
            ServiceCollection services = new ServiceCollection();
            //ניהול הרשאות להזרקות בתוך שכבת ה BL
            services.AddSingleton<Idal,DalManager>();
            services.AddSingleton<IblClient, BLclientService>();
            services.AddSingleton<IblCustomerType, BLcustemerTypeService>();
            //services.AddSingleton<IblOrderDetails,BLorderDetailsService>();
            services.AddSingleton<IblOrder,BLorderService>();
            services.AddSingleton<Ibldeal,BLdealService>();
            services.AddSingleton<IblIllustrationViewPoint,BLillustrationViewPointService>();
            services.AddSingleton<IblRecommend,BLrecommendsService>();
            services.AddSingleton<IblProject, BLprojectService>();
            ServiceProvider servicesProvider = services.BuildServiceProvider();
           //הצבה משתנים את המחלקות בשביל ה API
            Client = servicesProvider.GetRequiredService<IblClient>();
            CustomerType = servicesProvider.GetRequiredService<IblCustomerType>();
            Deal = servicesProvider.GetRequiredService<Ibldeal>();
            IblIllustrationViewPoint = servicesProvider.GetRequiredService<IblIllustrationViewPoint>();
            IblOrder = servicesProvider.GetRequiredService<IblOrder>();
            //IblOrderDetails= servicesProvider.GetRequiredService<IblOrderDetails>();
            IblRecommend = servicesProvider.GetRequiredService<IblRecommend>();
            IblProject= servicesProvider.GetRequiredService<IblProject>();
        }
    }
}
