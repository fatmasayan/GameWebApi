using ClosedXML.Excel;
using GameWebApiTest.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
namespace GameWebApiTest.Sevices;

public class ClientService
{
    const string BaseUrl = "http://localhost:5099/api/";
    const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6InVzZXI1IiwibmJmIjoxNzExMTAxNTcyLCJleHAiOjE3MTExMTM1NzIsImlzcyI6Iklzc3VlckluZm9ybWF0aW9uIiwiYXVkIjoiQXVkaWVuY2VJbmZvcm1hdGlvbiJ9.PQI9Pey_j1Rl8oZoZH1optduhhoSvk8iYFzZTRPgejU";

    

    public async Task WriteResponseTimesToExcel(List<ResponseModel> responseList)
    {
        string folderPath = @"C:\Users\fatma sayan\Desktop\EXCEL";
        string excelFileName = Path.Combine(folderPath, "ResponseTimes.xlsx");

        // Excel dosyasını oluştur
        using (var workbook = new XLWorkbook())
        {
            // Yeni bir çalışma sayfası oluşturulur
            var worksheet = workbook.Worksheets.Add("Response Times");

            // Başlık satırını eklenir
            worksheet.Cell(1, 1).Value = "Endpoint";
            worksheet.Cell(1, 2).Value = "Response Time (ms)";
            worksheet.Cell(1, 3).Value = "Response Time ";
            worksheet.Cell(1, 4).Value = "Status ";
            worksheet.Cell(1, 5).Value = "Content ";

            int row = 2;

            // ResponseList içindeki her bir ResponseModel için Excele satır ekleme işlemi
            foreach (var response in responseList)
            {
                worksheet.Cell(row, 1).Value = response.RequestModel.Url;
                worksheet.Cell(row, 2).Value = response.Time.TotalSeconds; //
                worksheet.Cell(row, 3).Value = response.ResTime;
                worksheet.Cell(row, 4).Value = response.Status.ToString();
                worksheet.Cell(row, 5).Value = response.Content.ToString();

                row++;
            }

            // Excel dosyasını kaydetmek
            workbook.SaveAs(excelFileName);
        }
    }

    public async Task<List<ResponseModel>> SendClientAPI()
    {
        var responseList = new List<ResponseModel>();
        using HttpClient client = new HttpClient();
        Stopwatch stopwatch = new Stopwatch();
        foreach (var endpoint in endpoints)
        {
            try
            {
                var reqMessage = new HttpRequestMessage
                {
                    Method = endpoint.Method,
                    Content = string.IsNullOrEmpty(endpoint.Body) ? null : new StringContent(endpoint.Body, System.Text.Encoding.UTF8, "application/json"), //ekleme yapıldı  System.Text.Encoding.UTF8, "application/json"
                    RequestUri = new Uri(endpoint.Url)
                };
                if (endpoint.Headers != null)
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    foreach (var item in endpoint.Headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }//

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                endpoint.ReqTime = DateTime.Now;
                stopwatch.Start();
                HttpResponseMessage response = await client.SendAsync(reqMessage);
                stopwatch.Stop();

                var result = new ResponseModel();
                result.ResTime = DateTime.Now;
                // Başarılı bir cevap alındıysa

                if (response.IsSuccessStatusCode)
                {
                    result.Content = response.IsSuccessStatusCode ? (await response.Content.ReadAsStringAsync()) : null;
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API'den gelen cevap ({endpoint.Url}):");
                    Console.WriteLine(responseBody);
                }///yesgitmekapatma
                else
                {
                    result.Content = null;
                    // Başarısız bir cevap alındıysa hata mesajını yazdır
                    Console.WriteLine($"API isteği başarısız ({endpoint.Url}): " + response.StatusCode);
                }
                result.Status = response.StatusCode;
                result.RequestModel = endpoint;
                result.Time = stopwatch.Elapsed; 

                responseList.Add(result);

            }
            catch (HttpRequestException e)
            {
                // İstek yaparken hata olursa
                Console.WriteLine($"Hata oluştu ({endpoint.Url}): " + e.Message);
            }
            //WriteResponseTimesToExcel();

            Console.WriteLine("ZAMAAN :  " + stopwatch.Elapsed);
            stopwatch.Reset();
            
        }
        return responseList;
    }
    //



    public static List<RequestModel> endpoints = new List<RequestModel>
    {
        ///**************************************************************/
        new RequestModel
        {
            Url = BaseUrl + "Achievement/getList",
            Method = HttpMethod.Get
        },
        new RequestModel
        {
            Url = BaseUrl + "Achievement/getSingle/1",
            Method = HttpMethod.Get
        },
        //new RequestModel
        //{
        //    Url = BaseUrl + "Achievement/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""achievementName"": ""added"",
        //              ""goalName"": ""added"",
        //              ""changeDate"": ""2024-03-11T10:31:56.771Z""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Achievement/update", 
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 1,
        //              ""achievementName"": ""guncel"",
        //              ""goalName"": ""gunn"",
        //              ""changeDate"": ""2024-03-11T10:32:13.316Z""
        //            }"
        //},



        //new RequestModel
        //{
        //    Url = BaseUrl + "Achievement/delete/9",
        //    Method = HttpMethod.Delete
        //},
        /**************************************************************/

        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthGroup/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthGroup/getSingle/2",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthGroup/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""name"": ""added"" //başarılı
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthGroup/update", //başarılı
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //            ""id"": 2,
        //            ""name"": ""Guncelleme"" 
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthGroup/delete/13", //başarılı
        //    Method = HttpMethod.Delete
        //},

        ///**************************************************************/
        ///başarılı


        // new RequestModel
        //{
        //    Url = BaseUrl + "AuthGroupPermissions/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthGroupPermissions/getSingle/4",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthGroupPermissions/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""group_id"": 6,
        //              ""permission_id"": 5
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthGroupPermissions/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 2,
        //              ""group_id"": 5,
        //              ""permission_id"": 6
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthGroupPermissions/delete/12",
        //    Method = HttpMethod.Delete
        //},

        /**************************************************************/


        // /// başarılı deleteye göz at 
        // new RequestModel
        //{
        //    Url = BaseUrl + "AuthPermission/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthPermission/getSingle/2",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthPermission/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""content_type_id"": 18,
        //              ""codename"": ""eklenen"",
        //              ""name"": ""eklenen""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthPermission/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 85,
        //              ""content_type_id"": 22,
        //              ""codename"": ""guncelleme"",
        //              ""name"": ""guncelleme""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthPermission/delete/100",
        //    Method = HttpMethod.Delete
        //},



        ///**************************************************************/
        ////// başarılı 
        // new RequestModel
        //{
        //    Url = BaseUrl + "AuthUser/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthUser/getSingle/1",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthUser/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""password"": ""10"",
        //              ""last_login"": ""2024-03-11T10:41:34.895Z"",
        //              ""is_superuser"": false,
        //              ""username"": ""eklendi"",
        //              ""last_name"": ""lnuser10"",
        //              ""email"": ""muser10"",
        //              ""is_staff"": false,
        //              ""is_active"": true,
        //              ""date_joined"": ""2024-03-11T10:41:34.895Z"",
        //              ""first_name"": ""fnuser10""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthUser/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 9,
        //              ""password"": ""111111111"",
        //              ""last_login"": ""2024-03-11T10:41:34.895Z"",
        //              ""is_superuser"": false,
        //              ""username"": ""updateuser10"",
        //              ""last_name"": ""updatelnuser10"",
        //              ""email"": ""updatemuser10"",
        //              ""is_staff"": false,
        //              ""is_active"": true,
        //              ""date_joined"": ""2024-03-11T10:41:34.895Z"",
        //              ""first_name"": ""updatefnuser10""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthUser/delete/18",
        //    Method = HttpMethod.Delete
        //},

        /////**************************************************************/
        ///
        //başarılı 
        // new RequestModel
        //{
        //    Url = BaseUrl + "AuthUserAndUserPermissions/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthUserAndUserPermissions/getSingle/4",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthUserAndUserPermissions/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""user_id"": 1,
        //              ""permission_id"": 10 //tablodakidenfarkklıolmalı 
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthUserAndUserPermissions/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 4,
        //              ""user_id"": 1,
        //              ""permission_id"": 7
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthUserAndUserPermissions/11",
        //    Method = HttpMethod.Delete
        //},
        /////**************************************************************/

        //// başarılı
        // new RequestModel
        //{
        //    Url = BaseUrl + "AuthUserGroups/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthUserGroups/getSingle/2",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthUserGroups/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""user_id"": 1,
        //              ""group_id"": 8
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthUserGroups/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 10,
        //              ""user_id"":7,
        //              ""group_id"": 9
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "AuthUserGroups/delete/12",
        //    Method = HttpMethod.Delete
        //},

        ///**************************************************************/
        /////başarılı
        // new RequestModel
        //{
        //    Url = BaseUrl + "BikeParts/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "BikeParts/getSingle/5",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "BikeParts/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""partType"": ""13"",
        //              ""partName"": ""added""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "BikeParts/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 5,
        //              ""partType"": ""5"",
        //              ""partName"": ""guncelleme""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "BikeParts/delete/12",
        //    Method = HttpMethod.Delete
        //},

        ///**************************************************************/
        /////başarılı
        // new RequestModel
        //{
        //    Url = BaseUrl + "CharItems/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "CharItems/getSingle/1",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "CharItems/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""category"": 2,
        //              ""item"": ""ekendi"",
        //              ""bodyGroup"": 1,
        //              ""isStarterContent"": true,
        //              ""sex"": 1,
        //              ""isSet"": true,
        //              ""groupId"": 1
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "CharItems/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 12,
        //              ""category"": 2,
        //              ""item"": ""guncelleme"",
        //              ""bodyGroup"": 1,
        //              ""isStarterContent"": true,
        //              ""sex"": 1,
        //              ""isSet"": true,
        //              ""groupId"": 1
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "CharItems/delete/15",
        //    Method = HttpMethod.Delete
        //},
        ///**************************************************************/
        /////

        // new RequestModel
        //{
        //    Url = BaseUrl + "DjangoAdminLog/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoAdminLog/getSingle/1",
        //    Method = HttpMethod.Get
        //},
        //HATALI
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoAdminLog/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""object_id"": ""added"",
        //              ""object_repr"": ""added"",
        //              ""action_flag"": 1,
        //              ""change_message"": ""added"",
        //              ""content_type_id"": 11,
        //              ""user_id"": 1,
        //              ""action_time"": ""2024-03-11T10:45:56.273Z""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoAdminLog/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 3,
        //              ""object_id"": ""guncelleme"",
        //              ""object_repr"": ""gunceleme"",
        //              ""action_flag"": 0,
        //              ""change_message"": ""gunceleme"",
        //              ""content_type_id"": 10,
        //              ""user"": 1,
        //              ""action_time"": ""2024-03-11T10:48:12.131Z""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoAdminLog/delete/41",
        //    Method = HttpMethod.Delete
        //},
        //HATALI
        ///**************************************************************/
        //
        //başarılı
        // new RequestModel
        //{
        //    Url = BaseUrl + "DjangoContentType/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoContentType/getSingle/1",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoContentType/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""app_label"": ""added"",
        //              ""model"": ""added""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoContentType/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 25,
        //              ""app_label"": ""updatee"",
        //              ""model"": ""update""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoContentType/delete/29",
        //    Method = HttpMethod.Delete
        //},

        ///**************************************************************/
        ///
        //Başarılı

        // new RequestModel
        //{
        //    Url = BaseUrl + "DjangoMigrations/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoMigrations/getSingle/2",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoMigrations/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""app"": ""add"",
        //              ""name"": ""add"",
        //              ""applied"": ""2024-03-11T10:50:27.320Z""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoMigrations/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 27,
        //              ""app"": ""update"",
        //              ""name"": ""update"",
        //              ""applied"": ""2024-03-11T10:50:49.891Z""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoMigrations/delete/29",
        //    Method = HttpMethod.Delete
        //},
        ///**************************************************************/
        ///

        //Başarılı

        //    new RequestModel
        //{
        //    Url = BaseUrl + "DjangoSession/getList",
        //    Method = HttpMethod.Get
        //},
        
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoSession/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""session_key"": ""add"",
        //              ""session_data"": ""add"",
        //              ""expire_date"": ""2024-03-11T10:51:11.519Z""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoSession/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""session_key"": ""ygwxxe9g2vth23hfcqxf8tti75wd0lbw"",
        //              ""session_data"": ""update"",
        //              ""expire_date"": ""2024-03-11T10:51:40.188Z""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "DjangoSession/delete/silincek",
        //    Method = HttpMethod.Delete
        //},

        ///**************************************************************/

        ////başarılı
        //    new RequestModel
        //{
        //    Url = BaseUrl + "Garage/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Garage/getSingle/1",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Garage/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""garageName"": ""add""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Garage/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 6,
        //              ""garageName"": ""update""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Garage/delete/17",
        //    Method = HttpMethod.Delete
        //},
        ///**************************************************************/
        ///başarılı
        //new RequestModel
        //{
        //    Url = BaseUrl + "Map/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Map/getSingle/1",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Map/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""mapName"": ""add"",
        //              ""totalKM"": 0,
        //              ""difficulty"": 0,
        //              ""maxSlope"": 0,
        //              ""slopeLength"": 0,
        //              ""averageTime"": 0,
        //              ""alternateRoute"": 0,
        //              ""viewPoint"": 0,
        //              ""casual"": true,
        //              ""competetive"": true
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Map/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 3,
        //              ""mapName"": ""update"",
        //              ""totalKM"": 0,
        //              ""difficulty"": 0,
        //              ""maxSlope"": 0,
        //              ""slopeLength"": 0,
        //              ""averageTime"": 0,
        //              ""alternateRoute"": 0,
        //              ""viewPoint"": 0,
        //              ""casual"": true,
        //              ""competetive"": true
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Map/delete/17",
        //    Method = HttpMethod.Delete
        //},


        ///**************************************************************/
        ///
        //başarılı
        //new RequestModel
        //{
        //    Url = BaseUrl + "Prices/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Prices/getSingle/2",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Prices/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""category"": ""add"",
        //              ""item"": ""add"",
        //              ""condition"": 0,
        //              ""price1"": 0,
        //              ""price2"": 0,
        //              ""achievementCondition"": ""add""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Prices/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 4,
        //              ""category"": ""update"",
        //              ""item"": ""update"",
        //              ""condition"": 0,
        //              ""price1"": 0,
        //              ""price2"": 0,
        //              ""achievementCondition"": ""update""
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Prices/delete/17",
        //    Method = HttpMethod.Delete
        //},



        ///**************************************************************/
        //başarlı
        //new RequestModel
        //{
        //    Url = BaseUrl + "Purchase/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Purchase/getSingle/2",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Purchase/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""puchasedItem"": ""add"",
        //              ""date"": ""2024-03-14T11:07:57.716Z"",
        //              ""loginUser_id"": 2
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Purchase/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 2,
        //              ""puchasedItem"": ""update"",
        //              ""date"": ""2024-03-14T11:08:25.044Z"",
        //              ""loginUser_id"": 3
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "Purchase/delete/11",
        //    Method = HttpMethod.Delete
        //},
        ///**************************************************************/
        ///

        //new RequestModel
        //{
        //    Url = BaseUrl + "UserBikes/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserBikes/getSingle/2",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserBikes/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""isActive"": true,
        //              ""body_id"": 1,
        //              ""handlebar_id"": 2,
        //              ""indicator_id"": 5,
        //              ""loginUser_id"": 2,
        //              ""saddle_id"": 3,
        //              ""wheel_id"": 4
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserBikes/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 4,
        //              ""isActive"": true,
        //              ""body_id"": 1,
        //              ""handlebar_id"": 2,
        //              ""indicator_id"": 5,
        //              ""loginUser_id"": 2,
        //              ""saddle_id"": 3,
        //              ""wheel_id"": 4
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserBikes/delete/17",
        //    Method = HttpMethod.Delete
        //},
        ///**************************************************************/



        //başarılı

        //new RequestModel
        //{
        //    Url = BaseUrl + "UserBodyType/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserBodyType/getSingle/2",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserBodyType/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""bodyType"": 1,
        //              ""isActive"": true,
        //              ""date"": ""2024-03-11T10:58:43.806Z"",
        //              ""loginUser_id"": 1
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserBodyType/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 2 ,
        //              ""bodyType"": 2,
        //              ""isActive"": true,
        //              ""date"": ""2024-03-11T10:58:56.408Z"",
        //              ""loginUser_id"": 3
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserBodyType/delete/13",
        //    Method = HttpMethod.Delete
        //},

        ///**************************************************************/
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserChar/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserChar/getSingle/2",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserChar/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""isSet"": true,
        //              ""isActive"": true,
        //              ""body_id"": 2,
        //              ""foot_id"": 5,
        //              ""glove_id"": 3,
        //              ""head_id"": 1,
        //              ""leg_id"": 4,
        //              ""loginUser_id"": 1
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserChar/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 2,
        //              ""isSet"": true,
        //              ""isActive"": true,
        //              ""body_id"": 2,
        //              ""foot_id"": 5,
        //              ""glove_id"": 3,
        //              ""head_id"": 1,
        //              ""leg_id"": 4,
        //              ""loginUser_id"": 2
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserChar/delete/18",
        //    Method = HttpMethod.Delete
        //},
        /////**************************************************************/
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserInventory/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserInventory/getSingle/2",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserInventory/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""tokenPremium"": 0,
        //              ""tokenInGame"": 0,
        //              ""tokenOfAvatar"": 0,
        //              ""totalKM"": 0,
        //              ""date"": ""2024-03-11T11:02:27.206Z"",
        //              ""loginUser_id"": 13
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserInventory/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 3,
        //              ""tokenPremium"": 0,
        //              ""tokenInGame"": 0,
        //              ""tokenOfAvatar"": 0,
        //              ""totalKM"": 0,
        //              ""date"": ""2024-03-11T11:02:49.476Z"",
        //              ""loginUser_id"": 13
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserInventory/delete/13",
        //    Method = HttpMethod.Delete
        //},
        /////**************************************************************/ 


        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendGarage/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendGarage/getSingle/2",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendGarage/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""isActive"": true,
        //              ""createDate"": ""2024-03-11T11:03:39.798Z"",
        //              ""garage_id"": 12,
        //              ""loginUser_id"": 13
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendGarage/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 0,
        //              ""isActive"": true,
        //              ""createDate"": ""2024-03-11T11:03:50.754Z"",
        //              ""garage_id"": 3,
        //              ""loginUser_id"": 1
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendGarage/delete/21",
        //    Method = HttpMethod.Delete
        //},
        /////**************************************************************/
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendMap/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendMap/getSingle/2",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendMap/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""totalPlayed"": 0,
        //              ""createDate"": ""2024-03-11T11:04:29.206Z"",
        //              ""changeDate"": ""2024-03-11T11:04:29.206Z"",
        //              ""loginUser_id"": 3,
        //              ""map_id"": 3,
        //              ""totalKM"": 987654
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendMap/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 5,
        //              ""totalPlayed"": 0,
        //              ""createDate"": ""2024-03-11T11:04:56.793Z"",
        //              ""changeDate"": ""2024-03-11T11:04:56.793Z"",
        //              ""loginUser_id"": 8,
        //              ""map_id"": 12,
        //              ""totalKM"": 987654
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendMap/delete/10",
        //    Method = HttpMethod.Delete
        //},
        /////**************************************************************/
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendAchievement/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendAchievement/getSingle/1",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendAchievement/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""changeDate"": ""2024-03-11T11:06:35.163Z"",
        //              ""achievement_id"": 10,
        //              ""loginUser_id"": 10
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendAchievement/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 10,
        //              ""changeDate"": ""2024-03-11T11:06:49.933Z"",
        //              ""achievement_id"": 7,
        //              ""loginUser_id"": 10
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserOwendAchievement/delete/11",
        //    Method = HttpMethod.Delete
        //},
        /////**************************************************************/
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserProfile/getList",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserProfile/getSingle/4",
        //    Method = HttpMethod.Get
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserProfile/add",
        //    Method = HttpMethod.Post,
        //    Body = @"
        //            {
        //              ""nickName"": ""add"",
        //              ""sex"": 0,
        //              ""birthDate"": ""2024-03-11T11:07:28.467Z"",
        //              ""weight"": 0,
        //              ""height"": 0, 
        //              ""bodyType"": 0,
        //              ""country"": ""add"",
        //              ""city"": ""add"",
        //              ""address"": ""add"",
        //              ""changeDate"": ""2024-03-11T11:07:28.467Z"",
        //              ""user_id"": 7
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserProfile/update",
        //    Method = HttpMethod.Put,
        //    Body = @"
        //            {
        //              ""id"": 5,
        //              ""nickName"": ""update"",
        //              ""sex"": 0,
        //              ""birthDate"": ""2024-03-11T11:07:44.439Z"",
        //              ""weight"": 0,
        //              ""height"": 0,
        //              ""bodyType"": 0,
        //              ""country"": ""update"",
        //              ""city"": ""update"",
        //              ""address"": ""update"",
        //              ""changeDate"": ""2024-03-11T11:07:44.439Z"",
        //              ""user_id"": 8
        //            }"
        //},
        //new RequestModel
        //{
        //    Url = BaseUrl + "UserProfile/delete/11",
        //    Method = HttpMethod.Delete
        //}

       // END
        };



}

