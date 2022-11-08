using Microsoft.EntityFrameworkCore;

namespace LightVerifyAPI.Models
{
    public class LightVerifyAPIContext : DbContext
    {
        public LightVerifyAPIContext(DbContextOptions<LightVerifyAPIContext> options) : base(options)
        {

        }

        public DbSet<ArduinoResponse> ArduinoResponses { get; set; }
    }
}
