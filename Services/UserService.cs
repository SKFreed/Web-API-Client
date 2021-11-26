using Microsoft.EntityFrameworkCore;
using Web_API_Client.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace Web_API_Client.Services
{
    public class UserService
    {
        public IRestResponse GetAllUsers()
        {
            RestClient client = new RestClient("https://localhost:7015/api/");
            RestRequest request = new RestRequest("users", Method.GET);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse GetUser(string email)
        {
            string path = "users/" + email;
            RestClient client = new RestClient("https://localhost:7015/api/");
            RestRequest request = new RestRequest(path, Method.GET);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse PutUser(DataResponse response)
        {
            string JsonResponse = JsonSerializer.Serialize<DataResponse>(response);
            string path = "users/" + response.email;
            RestClient client = new RestClient("https://localhost:7015/api/");
            RestRequest request = new RestRequest(path, Method.PUT);
            request.AddJsonBody(JsonResponse);
            var resp = client.Execute(request);
            return resp;
        }

        public IRestResponse DeleteUser(string email)
        {
            string path = "users/" + email;
            RestClient client = new RestClient("https://localhost:7015/api/");
            RestRequest request = new RestRequest(path, Method.DELETE);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse GetAllOrders(string email)
        {
            string path = "user/" + email + "/orders";
            RestClient client = new RestClient("https://localhost:7015/api/");
            RestRequest request = new RestRequest(path, Method.GET);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse GetOrder(string email, string idstring)
        {
            int? id = int.Parse(idstring);
            string path = "user/" + email + "/order/" + id;
            RestClient client = new RestClient("https://localhost:7015/api/");
            RestRequest request = new RestRequest(path, Method.GET);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse PutOrder(DataOrdersResponse response)
        {
            string JsonResponse = JsonSerializer.Serialize<DataOrdersResponse>(response);
            string path = "user/" + response.userEmail + "/order/" + response.id;
            RestClient client = new RestClient("https://localhost:7015/api/");
            RestRequest request = new RestRequest(path, Method.PUT);
            request.AddJsonBody(JsonResponse);
            var resp = client.Execute(request);
            return resp;
        }

        public IRestResponse PostUser(DataResponse res)
        {
            res.createdDate = "";
            res.enabled = true;
            string JsonResponse = JsonSerializer.Serialize<DataResponse>(res);

            RestClient client = new RestClient("https://localhost:7015/api/users");
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(JsonResponse);
            var response = client.Execute(request);

            /*var client = new RestClient("https://localhost:7015/api/users");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            res.name = "Анатолий";
            res.email = "qwetygfd@mail.ru";
            res.age = 21;
            string body = JsonSerializer.Serialize<DataRes>(res);
            //var body = @"{" + "\n" + @"  ""name"": ""Анатолий""," + "\n" + @"  ""age"": 21," + "\n" + @"  ""email"": ""tolyewqw@mail.ru""" + "\n" + @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);*/

            return response;
        }
    }
}

