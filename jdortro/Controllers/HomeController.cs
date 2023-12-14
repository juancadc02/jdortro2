using DAL.Modelos;
using jdortro.Models;
using jdortro.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace jdortro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            servicioConsulta servicio = new servicioConsultaImpl();
            int opcion;
            do
            {
                opcion = servicio.Menu();

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n\n\tAñadir elemento.");
                        Console.Write("\n\n\tIntroduce el nombre del elemento:  ");
                        string nombreElemento = Console.ReadLine();
                        Console.Write("\n\n\tIntroduce la descripcion del elemento:  ");
                        string descripcionElemento = Console.ReadLine();

                        Console.Write("\n\n\tIntroduce la cantidad del elementos:  ");
                        int cantidad = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            Elemento nuevoElemento = new Elemento(nombreElemento, descripcionElemento, cantidad);
                            servicio.añadirElemento(nuevoElemento);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\n\n\tSe ha producido un error: {0}", ex);
                        }
                        Console.WriteLine("\n\n\tPulsa una tecla para volver al menu.");
                        Console.ReadLine();
                        break;
                    case 2:

                        Console.WriteLine("\n\n\tMostrar stock");
                        Console.WriteLine("\n\tCodigo Elemento  Nombre Elemento   Cantidad Elemento");

                        try
                        {
                            servicio.listarElementos();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\n\n\tSe ha producido un error: {0}", ex);
                        }
                        Console.WriteLine("\n\n\tPulsa una tecla para volver al menu.");
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("\n\n\tAñadir Reserva");
                        DateTime fchReserva = DateTime.Now.ToUniversalTime();
                        Reserva nuevaReserva = new Reserva(fchReserva);
                        servicio.insertarReserva(nuevaReserva);


                        servicio.listarElementos();
                        Console.Write("\n\n\tIntroduce el elemento que quieres reservar: ");
                        int idElemento= Convert.ToInt32(Console.ReadLine());

                        Console.Write("\n\n\tIntroduce la cantidad de elemento que quieres reservar: ");
                        int cantidadElemento = Convert.ToInt32(Console.ReadLine());

                        int idReserva = 1; //Tienes que introducirlo manuealmente
                        RelElementoReservas nuevoRelReserca = new RelElementoReservas(idElemento, idReserva, cantidadElemento);


                        try
                        {
                            servicio.insertarRelElementoReservas(nuevoRelReserca);
                        }catch(Exception e)
                        {
                            Console.WriteLine("\n\n\tSe ha prodico un error: "+ e);
                        }
                        
                        Console.WriteLine("\n\n\tPulsa una tecla para volver al menu.");
                        Console.ReadLine();
                        break;


                    case 0:
                        Console.WriteLine("\n\n\tHas salido del menu");

                        break;
                }
            } while (opcion != 0);
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}