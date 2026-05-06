using DAL.Appi;
using DAL.Models;
using DAL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;



using DAL.Appi;

public class DalManager : Idal
{
    public Iclient client { get; }
    public IcustomerType customerType { get; }
    public Iorder order { get; }
    public Irecommends Recommend { get; }
    //public IorderDetails orderDetails { get; }
    public Ideal deal { get; }
    public IillustrationViewPoint illustrationViewPoint { get; }
   public Iproject project { get; }
    public DalManager()
    {
        ServiceCollection services = new ServiceCollection();

        services.AddSingleton<DbManager>();
        services.AddSingleton<Iclient, ClientService>();
        services.AddSingleton<Iproject, ProjectService>();
        services.AddSingleton<Iorder, OrderService>();
        services.AddSingleton<Ideal, DealService>();
        //services.AddSingleton<IorderDetails, OrderDetailsService>();
        services.AddSingleton<Irecommends, RecommendsService>();
        services.AddSingleton<IcustomerType, CustemerTypeService>();
        services.AddSingleton<IillustrationViewPoint, IllustrationViewPointService>();
        ServiceProvider servicesProvider = services.BuildServiceProvider();
        client = servicesProvider.GetRequiredService<Iclient>();
        order = servicesProvider.GetRequiredService<Iorder>();
        //orderDetails = servicesProvider.GetRequiredService<IorderDetails>();
        Recommend = servicesProvider.GetRequiredService<Irecommends>();
        deal = servicesProvider.GetRequiredService<Ideal>();
        illustrationViewPoint = servicesProvider.GetRequiredService<IillustrationViewPoint>();
        customerType = servicesProvider.GetRequiredService<IcustomerType>();
        project= servicesProvider.GetRequiredService<Iproject>();
    }

}
