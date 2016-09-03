using EntityFrameworkCore1.Models;

namespace EntityFrameworkCore1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new RiceContext())
            {
            }
        }
    }
}