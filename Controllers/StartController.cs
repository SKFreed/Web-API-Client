using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using Web_API_Client.Models;
using Web_API_Client.Services;

namespace Web_API_Client.Controllers
{
    public class StartController : Controller
    {
        private readonly UserService _userService; // так создаются зависимости, в которых используются интерфейсы с соблюдением SOLID
        public StartController(UserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            var response = _userService.GetAllUsers();
            List<DataResponse>? dataResponse = new();            
            try // Здесь пишется функция ,которая может вызвать ошибку
            {
                dataResponse = JsonSerializer.Deserialize<List<DataResponse>>(response.Content);
            }
            catch (Exception ex)
            {
                // Здесь происходит обработка ошибки
            };
           
            return View(dataResponse);
        }
        public IActionResult EditUser(string email)
        {           
            var response = _userService.GetUser(email);
            DataResponse? dataResponse = JsonSerializer.Deserialize<DataResponse>(response.Content);
            return View(dataResponse);
        }
        
        [HttpPost]
        public IActionResult EditUser(DataResponse response)
        {            
            var resp = _userService.PutUser(response);            
            return RedirectToAction(nameof(Index));
        }

       // [Route("/start/deleteuser/{email}")]
            public IActionResult DeleteUser(string email)
            {
               
                var response = _userService.DeleteUser(email);
                return RedirectToAction(nameof(Index));
            }

       // [Route("/start/vieworders/{email}")]
        public IActionResult ViewOrders (string email)// Сделать свою модель (готово)
        {
            var response = _userService.GetAllOrders(email);
            List<DataOrdersResponse>? dataOrdersResponse = new();
            try // Здесь пишется функция ,которая может вызвать ошибку
            {
                dataOrdersResponse = JsonSerializer.Deserialize<List<DataOrdersResponse>>(response.Content);
            }
            catch (Exception ex)
            {
                // Здесь происходит обработка ошибки
            };
            return View(dataOrdersResponse);
        }

        /*[Route("/start/editorder/{email}/{id}")]*/
        public IActionResult EditOrder(string email, string idstring)
        {
            var response = _userService.GetOrder(email, idstring);
            DataOrdersResponse? dataOrdersResponse = JsonSerializer.Deserialize<DataOrdersResponse>(response.Content);
            return View(dataOrdersResponse);
        }

        //[Route("/start/editorder/{email},{id}")]
        [HttpPost]
        public IActionResult EditOrder(DataOrdersResponse response)
        {
            var resp = _userService.PutOrder(response);
            return RedirectToAction(nameof(ViewOrders), new { email = response.userEmail });
        }

        public IActionResult PostUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostUser(DataResponse res)
        {
            //res.createdDate = DateTime.Now.ToString();
            var resp = _userService.PostUser(res);
            
            return RedirectToAction(nameof(Index));
        }
    }
}

