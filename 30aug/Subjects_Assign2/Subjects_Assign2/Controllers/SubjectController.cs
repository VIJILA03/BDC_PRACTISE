using Microsoft.AspNetCore.Mvc;

namespace Subjects_Assign2.Controllers
{
    public class SubjectController : Controller
    {
        public string books(string subject)
        {
            if (subject == "History")
            {
                return $" Kings \n Early India \n world war 1 \n World War 2";
            }
            if (subject == "Mathematics")
            {
                return $" Algebra \n Statistics \n GEOMETRY \n TRIGNOMETRY";
            }
            if (subject == "Computer")
            {
                return $" HTML \n CSS\n .NET \n JAVA";
            }
            return $"{subject}";
        }
    }
}
