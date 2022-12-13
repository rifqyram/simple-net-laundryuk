// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SimpleLaundryuk.Application.Models.Product;
using SimpleLaundryuk.Application.Models.ProductPrice;
using SimpleLaundryuk.Entity.Entities;
using SimpleLaundryuk.Infrastructure.Repositories;

public class Program
{
    public static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder();
        var context = new AppDbContext(options
            .UseNpgsql("Host=localhost;Username=postgres;Password=password;Database=laundryuk;").Options);

        var product = context.Products.AsNoTracking().FirstOrDefault(p => p.Id == Guid.Parse("84d23035-2ad5-4429-8afb-2e20d508cc51"));

        
    }
}