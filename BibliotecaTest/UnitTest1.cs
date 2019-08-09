using BibliotecaDairy.Models;
using BibliotecaDairy.Persistance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using BibliotecaDairy.Services;
using BibliotecaDairy.Controllers;


namespace BibliotecaTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Autor Autor;
        private readonly Genero Genero;
        private readonly Editoria Editoria;
        private readonly Libro Libro;

        BibliotecaDbContext context = new BibliotecaDbContext(new DbContextOptions<BibliotecaDbContext>());

        [TestMethod]
        public void TestMethod1()
        {
            var Autor = new Autor();
            var servicio = new AutorService(context);
            var controller = new AutorController(servicio);
            
        }

        [TestMethod]
        public void notemptyautor()
        {
            var Autor = new Autor();
            var result = Autor.ToString();
            Assert.IsNotNull(result);

        }
    }
}
