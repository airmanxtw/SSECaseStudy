using System.Runtime.InteropServices.Marshalling;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SSECASESTUDY.Controllers;

[Route("api/[controller]")]

[ApiController]
public class SSE : ControllerBase
{
    [HttpGet]
    [EnableCors("PublicPolicy")]
    public void Get()
    {
        Response.Headers.Append("Content-Type", "text/event-stream;");
        Response.Headers.Append("Cache-Control", "no-cache");
        Response.Headers.Append("Connection", "keep-alive");
        Request.Headers.TryGetValue("Last-Event-ID", out var lastEventId);
        var id = lastEventId.ToString() == "" ? 0 : int.Parse(lastEventId.ToString());

        //Response.WriteAsync($"id:{id + 1}\nretry:5000\ndata: {{\"message\": \"Hello SSE:{id} \"}}\n\n").Wait();
        Response.WriteAsync($"id:{id + 1}\nretry:5000\ndata: {id}\n\n").Wait();
        //Response.WriteAsync("event: end\ndata: {}\n\n").Wait();

        // append retry time:
        //  var c=1;
        //  while(c++<10)
        //  {            
        //     Response.WriteAsync($"data: {{\"message\": \"Hello SSE\"}}\n\n").Wait();                      
        //     Thread.Sleep(1000);
        //  }                 
        // Response.WriteAsync("event: end\ndata: {}\n\n").Wait();




    }





}