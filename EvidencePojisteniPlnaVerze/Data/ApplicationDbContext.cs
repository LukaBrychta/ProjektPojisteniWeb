using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EvidencePojisteniPlnaVerze.Models;

namespace EvidencePojisteniPlnaVerze.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EvidencePojisteniPlnaVerze.Models.Insured> Insured { get; set; } = default!;
        public DbSet<EvidencePojisteniPlnaVerze.Models.Insurance> Insurance { get; set; } = default!;
    }
}