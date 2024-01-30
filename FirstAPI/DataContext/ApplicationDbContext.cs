using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    
    public DbSet<FuncionarioModel> Funcionarios { set; get; }
    
}
    