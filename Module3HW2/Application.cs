using System;
using Module3HW2.Models;
using Module3HW2.Collection;
using Module3HW2.Services.Abstractions;

namespace Module3HW2
{
    public class Application
    {
        private IConfigService _configProvider;
        public Application(IConfigService configService)
        {
            _configProvider = configService;
        }

        public void Run()
        {
            var list = new ContactList();
            list.SetCulture(_configProvider.GetConfig().CultureConfig.Culture);
            list.Add(new Contact { FirstName = "1Dima", SecondName = "1Yampolskyi", PhoneNumber = "+1668142950" });
            list.Add(new Contact { FirstName = "Dima", SecondName = "Yampolskyi", PhoneNumber = "+1668142950" });
            list.Add(new Contact { FirstName = "Дима", SecondName = "Ямпольский", PhoneNumber = "+1668142950" });
            list.Add(new Contact { FirstName = "1Дима", SecondName = "1Ямпольский", PhoneNumber = "+1668142950" });
            list.Add(new Contact { FirstName = "ÄÄÄÄÄÄ", SecondName = "ÄÄÄÄÄÄ", PhoneNumber = "+1668142950" });
            foreach (var item in list.GetSection("#"))
            {
                Console.WriteLine($"Name: {item.FullName} Phone number: {item.PhoneNumber}");
            }
        }
    }
}
