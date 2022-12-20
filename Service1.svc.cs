using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace MyWebService2
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IRestService
    {
        private static List<Car> Cars;
        private static int lastId = 0;

        public Service1()
        {
            MyData.info();
            Cars = new List<Car>
            {
                new Car{Id=1, Name="Corsa", Brand="Opel", Price=1000 },
                new Car{Id=2, Name="Astra", Brand="Opel", Price=3000 },
                new Car{Id=3, Name="T", Brand="Ford", Price=30000 }
            };
            lastId = 3;
        }

        public string addJson(Car item)
        {
            return addXml(item);
        }

        public string addXml(Car item)
        {
            if (item == null)
                throw new WebFaultException<string>("400: BadRequest", HttpStatusCode.BadRequest);
            int idx = Cars.FindIndex(b => b.Id == item.Id);
            if (idx == -1)
            {
                Cars.Add(item);
                return "Added item with ID=" + item.Id;
            }
            else
            {
                throw new WebFaultException<string>("409: Conflict", HttpStatusCode.Conflict);
            }
        }

        public string delteJson(string Id)
        {
            return delteXml(Id);
        }

        public string delteXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = Cars.FindIndex(b => b.Id == intId);
            if (idx == -1)
            {
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            }
            Cars.RemoveAt(idx);
            return "Remove item with ID=" + Id;
        }

        public List<Car> getAllJson()
        {
            return Cars;
        }

        public List<Car> getAllXml()
        {
            return Cars;
        }

        public Car getByIdJson(string Id)
        {
            return getByIdXml(Id);
        }

        public Car getByIdXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = Cars.FindIndex(b => b.Id == intId);
            if (idx == -1)
            {
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            }
            return Cars.ElementAt(idx);
        }

        public string updateJson(string Id, Car item)
        {
            return updateXml(Id, item);
        }

        public string updateXml(string Id, Car item)
        {
            if (item == null)
                throw new WebFaultException<string>("400: BadRequest", HttpStatusCode.BadRequest);
            int intId = int.Parse(Id);
            int idx = Cars.FindIndex(b => b.Id == intId);
            if (idx == -1)
            {
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            }
            else
            {
                Cars.RemoveAt(idx);
                Cars.Add(item);
                return "Updated item with ID=" + item.Id;
            }
        }
    }
}
