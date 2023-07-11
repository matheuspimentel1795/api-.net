using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.DTOs.Mappings;
using VShop.ProductApi.Repositories;
using VShop.ProductApi.Services;

namespace TestXUnit
{
    public class UnitTest1
    {
        private IMapper mapper;
        private ProductsApiRepository repository;

        public static DbContextOptions<AppDbContext> dbContextOptions { get; }
        public static string connectionString =
            "Server=containers-us-west-52.railway.app;DataBase=railway;uid=root;Pwd=et9nXKDRMYvBHm7YBE6r;Port=7756";
        static UnitTest1()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;
        }
        public UnitTest1()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }
            );
            mapper = config.CreateMapper();
            var context = new AppDbContext(dbContextOptions);

            //UnitTestMockInicializer db = new DbUnitTestMockInicializer();
            //.Seed(context);

            repository = new ProductsApiRepository(context);
        }
        [Fact]
        public void Test1()
        {
            //Arrange
            var service = new ProductsApiService(repository, mapper);
            //Act
            var data = service.GetAll();
            //assert
            Assert.IsType<List<ProductsDTO>>(data);
        }
    }
}