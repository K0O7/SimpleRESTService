using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace MyWebService2
{
    [ServiceContract]
    public interface IRestService
    {

        [OperationContract]
        [WebGet(UriTemplate = "/cars")]
        List<Car> getAllXml();

        [OperationContract]
        [WebGet(UriTemplate = "/cars/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Car getByIdXml(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/cars", Method = "POST", ResponseFormat = WebMessageFormat.Xml)]
        string addXml(Car item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/cars/{id}", Method = "PUT", ResponseFormat = WebMessageFormat.Xml)]
        string updateXml(string Id, Car item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/cars/{id}", Method = "DELETE")]
        string delteXml(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/cars", ResponseFormat = WebMessageFormat.Json)]
        List<Car> getAllJson();

        [OperationContract]
        [WebGet(UriTemplate = "/json/cars/{id}", ResponseFormat = WebMessageFormat.Json)]
        Car getByIdJson(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/cars", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string addJson(Car item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/cars/{id}", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
        string updateJson(string Id, Car item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/cars/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        string delteJson(string Id);
    }


    [DataContract]
    public class Car
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public string Brand { get; set; }

        [DataMember(Order = 3)]
        public double Price { get; set; }

        /*public Car(int id, string name, string brand, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
        }*/
    }
}
