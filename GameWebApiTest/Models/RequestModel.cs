namespace GameWebApiTest.Models;

public class RequestModel
{
    public string Url {  get; set; } // istek atılacak endpoint url'i
    public HttpMethod Method {  get; set; } // POST, GET, DELETE, PUT vs vs 
    public string Body { get; set; } // json gönderilen kısım
    public Dictionary<string,string> Params { get; set; } // path üzeirnden yani query üzerinden parameter alınabilir. Yani localhost:5000/api/userbikes?id=10 
    public Dictionary<string,string> Headers { get; set; } // header kısmındır.
    //public string Auth { get; set; } // Authorization yani token vs vs alınabilir.
    public DateTime ReqTime { get; set; } //istak saati 
}
//