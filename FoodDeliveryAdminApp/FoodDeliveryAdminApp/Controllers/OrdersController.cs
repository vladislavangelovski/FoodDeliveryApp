﻿using ClosedXML.Excel;
using FoodDeliveryAdminApp.Models;
using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FoodDeliveryAdminApp.Controllers
{
    public class OrdersController : Controller
    {
        public OrdersController()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5070/api/Admin/GetAllOrders";

            HttpResponseMessage response = client.GetAsync(URL).Result;
            var data = response.Content.ReadAsAsync<List<Order>>().Result;
            return View(data);
        }

        public IActionResult Details(Guid id)
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5070/api/Admin/GetOrderDetails";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var data = response.Content.ReadAsAsync<Order>().Result;


            return View(data);

        }


        public FileContentResult CreateInvoice(string id)
        {
            HttpClient client = new HttpClient();

            string URL = "http://localhost:5070/api/Admin/GetOrderDetails";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<Order>().Result;

            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Invoice.docx");
            var document = DocumentModel.Load(templatePath);

            document.Content.Replace("{{OrderNumber}}", result.Id.ToString());
            document.Content.Replace("{{FirstName}}", result.Owner.FirstName);
            document.Content.Replace("{{LastName}}", result.Owner.LastName);

            StringBuilder sb = new StringBuilder();
            var total = 0;
            var maxtime = 0;
            foreach (var item in result.FoodItemInOrders)
            {
                sb.AppendLine(item.Quantity+" " + item.OrderedFoodItem.Name + " with price " + item.OrderedFoodItem.Price + "$");
                total += (int)(item.Quantity * item.OrderedFoodItem.Price);
                if(item.OrderedFoodItem.TimeToPrepareMinutes > maxtime)
                    maxtime = item.OrderedFoodItem.TimeToPrepareMinutes;
            }
            maxtime += 15;
            document.Content.Replace("{{FoodItemsList}}", sb.ToString());
            document.Content.Replace("{{TotalPrice}}", total.ToString() + "$");
            document.Content.Replace("{{DeliveryTime}}", maxtime.ToString() + " min.");

            var stream = new MemoryStream();
            document.Save(stream, new PdfSaveOptions());
            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportInvoice.pdf");
        }

        [HttpGet]
        public FileContentResult ExportAllOrders()
        {
            string fileName = "Orders.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Orders");
                worksheet.Cell(1, 1).Value = "OrderID";
                worksheet.Cell(1, 2).Value = "Customer Name";
                worksheet.Cell(1, 3).Value = "Total Price";
                worksheet.Cell(1, 4).Value = "Delivery Time";

                HttpClient client = new HttpClient();
                string URL = "http://localhost:5070/api/Admin/GetAllOrders";

                HttpResponseMessage response = client.GetAsync(URL).Result;
                var data = response.Content.ReadAsAsync<List<Order>>().Result;

                for (int i = 0; i < data.Count(); i++)
                {
                    var item = data[i];
                    worksheet.Cell(i + 2, 1).Value = item.Id.ToString();
                    worksheet.Cell(i + 2, 2).Value = item.Owner.FirstName+item.Owner.LastName;
                    var total = 0;
                    var maxtime = 0;
                    for (int j = 0; j < item.FoodItemInOrders?.Count(); j++)
                    {
                        worksheet.Cell(1, 5 + j).Value = "Fooditem - " + (j + 1);
                        worksheet.Cell(i + 2, 5 + j).Value = item.FoodItemInOrders.ElementAt(j).OrderedFoodItem.Name;
                        total += (int)(item.FoodItemInOrders.ElementAt(j).Quantity * item.FoodItemInOrders.ElementAt(j).OrderedFoodItem.Price);
                        if (item.FoodItemInOrders.ElementAt(j).OrderedFoodItem.TimeToPrepareMinutes > maxtime)
                            maxtime = item.FoodItemInOrders.ElementAt(j).OrderedFoodItem.TimeToPrepareMinutes;
                    }
                    worksheet.Cell(i + 2, 3).Value = total;
                    worksheet.Cell(i + 2, 4).Value = maxtime+15;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }
            }

        }
    }
}
