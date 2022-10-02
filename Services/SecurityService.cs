using Batch_Advisory.Models;
using Batch_Advisory.Data;

namespace Batch_Advisory.Services
{
    public class SecurityService
    {
        private readonly Batch_AdvisoryContext _context= new Batch_AdvisoryContext();
        
        public bool IsValid(string Src, string Password)
        {
            Student found = _context.Students.Find(Src);
            if(found!=null && found.Password==Password)
                return true;
            else 
                return false;
        }
        
        public bool IsValidAdvisor(int Id, string Password)
        {
            Advisor found = _context.Advisors.Find(Id);

            if (found != null && found.Password == Password)
                return true;
            else
                return false;
        }
    }
}
