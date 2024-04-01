using System.Net;

namespace GameWebApiTest.Models;

public class ResponseModel
{
    public RequestModel RequestModel { get; set; }//
    public HttpStatusCode Status {  get; set; }
    public string Content {  get; set; }
    public DateTime ResTime { get; set; } //dönüş saat.
    public TimeSpan Time { get; set; }//istek süresi
}
