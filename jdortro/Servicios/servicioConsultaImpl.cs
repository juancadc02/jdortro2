using DAL;
using DAL.Modelos;

namespace jdortro.Servicios
{
    /// <summary>
    /// Servicio donde se encuentra toda la logica de los metodos que actuan sobre la base de datos.
    /// </summary>
    public class servicioConsultaImpl : servicioConsulta
    {


        public int Menu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\n\n\t1)Añadir elementos.");
                Console.WriteLine("\n\n\t2)Mostrar Stock");
                Console.WriteLine("\n\n\t3)Crear reserva");
                Console.WriteLine("\n\n\t0)Salir del menu.");
                Console.WriteLine("\n\n\t");
                Console.Write("\n\n\tIntroduce una opcion:  ");
                opcion = Console.ReadKey().KeyChar - '0';

                while (opcion < 0 || opcion > 3)
                {
                    Console.WriteLine("\n\n\tError: Introduce una opcion correcta");
                    Console.WriteLine("\n\n\tIntroduce una opcion");
                    opcion = Console.ReadKey().KeyChar - '0';
                }
                Console.Clear();

                return opcion;
            } while (opcion != 0);
        }


        public void añadirElemento(Elemento nuevoElemento)
        {
            using (var contexto = new gestorDbContext())
            {
                nuevoElemento = new Elemento
                {
                    nombreElemento = nuevoElemento.nombreElemento,
                    descripcionElemento = nuevoElemento.descripcionElemento,
                    cantidadElemento = nuevoElemento.cantidadElemento
                };

                nuevoElemento.codigoElemento = cargarCodigoElemento("Elem", nuevoElemento.nombreElemento);
                contexto.Elementos.Add(nuevoElemento);
                contexto.SaveChanges();
                Console.WriteLine("\n\n\tNuevo elemento añadido.");
            }
        }

        public string cargarCodigoElemento(string elen, string nombre)
        {
            return $"{elen}-{nombre}";
        }

        public List<Elemento> listarElementos()
        {
            using (var contexto = new gestorDbContext())
            {
                var listaElemento = contexto.Elementos.ToList();

                if (listaElemento.Count == 0)
                {
                    Console.WriteLine("\n\n\tNo existe ningun elemento.");
                }
                else
                {
                    foreach (var elem in listaElemento)
                    {
                        Console.WriteLine("\n\n\t     {0}           {1}          {2}",elem.codigoElemento, elem.nombreElemento, elem.cantidadElemento);
                    }
                }
                return listaElemento;
            }
        }

        /*public void añadirReserva(Reserva nuevaReserva,int idElemento)
        {
            using (var contexto = new gestorDbContext())
            {
                Elemento elemento = contexto.Elementos.Find(Convert.ToInt64(idElemento));
                
                if(elemento != null)
                {
                    nuevaReserva.Elemento.Add(elemento);
                    contexto.Reservas.Add(nuevaReserva);
                    contexto.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\n\n\tSe ha producido un error.");
                }
            }
        }*/


        public void insertarReserva(Reserva nuevaReserva)
        {
            using(var contexto = new gestorDbContext())
            {
                nuevaReserva = new Reserva
                {
                    fchReserva=nuevaReserva.fchReserva
                };
                contexto.Reservas.Add(nuevaReserva);
                contexto.SaveChanges();
                Console.WriteLine("\n\n\tReserva añadida con exito.");
            }
        }
        public void insertarRelElementoReservas(RelElementoReservas nuevaReserva)
        {
            using (var contexto = new gestorDbContext())
            {
                nuevaReserva = new RelElementoReservas
                {
                    idElemento = nuevaReserva.idElemento,
                    idReserva = nuevaReserva.idReserva,
                    cantidadReservada = nuevaReserva.cantidadReservada
                };
                contexto.RelElementosReservas.Add(nuevaReserva);
                contexto.SaveChanges();
                Console.WriteLine("\n\n\tAñadido correctamente");

            }
        }
    }
}
