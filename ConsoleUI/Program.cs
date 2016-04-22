using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.ServiceReference1;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var wcfSoapClient = new PersonServiceClient())
            {
                string data = wcfSoapClient.GetData("1973");
                Console.WriteLine(data);

                CompositeType composite = new CompositeType
                {
                    BoolValue = true,
                    StringValue = "Helo WCF Service"
                }; 

                composite = wcfSoapClient.GetDataUsingDataContract(composite);
                Console.WriteLine("composite: " + composite.StringValue);


                var persons = wcfSoapClient.GetAllPersons();


                foreach (var person in persons)
                {
                    Console.WriteLine(person.name);
                }
            }

            Console.ReadKey();
        }
    }
}
