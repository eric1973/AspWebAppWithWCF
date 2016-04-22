using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceLayer.DataContract;
using UnitOfWorkLayer;

namespace WcfServiceLayer
{
    public class PersonService : IPersonService
    {
        private static UnitOfWork unitofwork = new UnitOfWork();

        public Person AddNewPerson(Person person, string id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAPerson(string id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAllPersons()
        {
            IEnumerable<UnitOfWorkLayer.Models.Person> data = unitofwork.PersonRepository.List;

            IEnumerable<Person> wcfData = 
                data.Select(person => new Person {
                    id = person.id,
                    name = person.name,
                    address = person.address,
                });


            return wcfData.ToList();
        }

        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Person GetPersonById(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAPerson(Person person, string id)
        {
            throw new NotImplementedException();
        }
    }
}
