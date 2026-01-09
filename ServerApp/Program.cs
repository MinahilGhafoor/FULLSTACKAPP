namespace ServerApp
{
    public class Program
    {
        public record Category(int Id, string Name);                                             // Define Category class
        public record Product(int Id, string Name, double Price, int Stock, Category Category);  // Define Product class with nested Category
        
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorClient", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:5136")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // ❌ DO NOT use HTTPS redirection for now
            // app.UseHttpsRedirection();

            // ✅ USE CORS BEFORE ENDPOINTS
            app.UseCors("AllowBlazorClient");

            app.MapGet("/api/products", () =>
            {
                var products = new Product[]
                {
                    new Product(1, "Refrigerator", 12.5, 100,new Category(1, "electronics"))
                };
                return products;
            });


            // ✅ RUN THE APPs
            app.Run();


        }

    }
}
