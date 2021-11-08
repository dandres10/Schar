namespace WebApiModulo7.Contexts
{
    
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WebApiModulo7.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicacionUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

       
    }
}