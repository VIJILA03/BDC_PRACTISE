using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Microsoft.AspNetCore.Mvc.Controller
    {
        public string showid(int id)
        {
            return $"The id is ={id}";
        }
        public int increment(int id)
        {
            int c=2;
            int a = c + id;
            return a;
        }
        public string display()
        {
           // int a=increment();
           DateTime dateTime = DateTime.Now;
            if (dateTime.Hour > 12 && dateTime.Hour < 17)
                return $"good afternoon the time is {dateTime}";
            if(dateTime.Hour<12)
                return $"good morning the time is {dateTime}";
            if (dateTime.Hour >17)
                return $"good evening the time is {dateTime}";
            return $"message  {dateTime}";
        }
    }
}
