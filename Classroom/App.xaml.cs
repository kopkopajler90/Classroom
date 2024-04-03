using Classroom.Models;
using Classroom.ModelViews;
using Classroom.Services.Implementations;
using Classroom.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Classroom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ///<summary>
            ///A PLUSZ SZOLGÁLTATÁSOK HOZZÁADÁS
            ///</summary>A
            Services = ConfigureServices();

            this.InitializeComponent();
        }


        //EZEN A METÓDUSON KERESZTÜL LEHET ELKÉRNI A VIEWMODEL-leket
        public new static App Current => (App)Application.Current;


        public IServiceProvider Services { get; }



        private static IServiceProvider ConfigureServices()
        {
            ///<summary>
            ///A SZOLGÁLTATÁSOK-KÉSZLET PÉLDÁNYOSÍTÁSA
            ///SAJÁT SZOLGÁTATÁS HOZZÁADÁSA
            ///A BŐVÍTETT KÉSZLET VISSZAADÁSA
            /// </summary>

            var services = new ServiceCollection();

            //HA VALAMELYIK KONSTRUKTOR IDataService PÉLDÁNYT KÉR, AKKOR EGY DataService PÉLDÁNYT AD AZ "APP"
            services.AddDbContext<ClassroomContext>();

            services.AddSingleton<IOktatoDataService, OktatoDataService>();
            services.AddSingleton<ITanuloDataService, TanuloDataService>();
            services.AddSingleton<IKurzusDataService, KurzusDataService>();

            //HA VALAKI AZ APP-tól KÉR EGY UserViewModel PÉLDÁNYT AKKOR INNÉT AD EGYET!
            services.AddTransient<OktatoViewModel>();
            services.AddTransient<TanuloViewModel>();



            return services.BuildServiceProvider();
        }
    }

}
