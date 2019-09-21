using Admin.DataAccess.Sql;
using Admin.Domain;
using Admin.Domain.Email;
using Admin.Domain.Interfaces;
using Admin.Domain.Sms;
using Admin.UI.WpfApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;

namespace Admin.UI.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Composition Root
            SimpleAutoWireContainer container = new SimpleAutoWireContainer();
            container.Register(typeof(MessageTemplateContext), () => new MessageTemplateContext());
            container.Register(typeof(IMessageTemplateRepository), typeof(SqlMessageTemplateRepository));
            container.Register(typeof(IMessageTransmissionStrategy), typeof(TwilioSmsTransmissionStrategy));
            container.Register(typeof(ICreateUserService), typeof(CreateUserService));

            ICreateUserService service = container.Resolve(typeof(ICreateUserService)) as ICreateUserService;

            //ICreateUserService service = new CreateUserService(
            //    new SqlMessageTemplateRepository(
            //        new MessageTemplateContext()
            //    ),
            //    //new NullMessageTransmissionStrategy()
            //    //new SendGridEmailTransmissionStrategy()
            //    new TwilioSmsTransmissionStrategy()
            //);

            // UI Layer
            CreateUserViewModel vm = new CreateUserViewModel(service);

            this.MainWindow = new CreateUserWindow(vm);
            this.MainWindow.Show();
        }
    }
}
