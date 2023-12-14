using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modelos
{
    public class RelElementoReservas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idRelElementoReservas { get; set; } = 0;
        [ForeignKey("Elemento")]
        public long idElemento { get; set; } = 0;
        [ForeignKey("Reserva")]
        public long idReserva { get; set; } = 0;

        public int cantidadReservada { get; set; } = 0;


        //Otras entidades
        public Elemento Elemento { get; set; }

        public Reserva Reserva { get; set; }





        #region Constructores

        public RelElementoReservas(long idRelElementoReservas, long idElemento, long idReserva, int cantidadReservada)
        {
            this.idRelElementoReservas = idRelElementoReservas;
            this.idElemento = idElemento;
            this.idReserva = idReserva;
            this.cantidadReservada = cantidadReservada;
        }
        public RelElementoReservas(long idElemento, long idReserva, int cantidadReservada)
        {
            this.idElemento = idElemento;
            this.idReserva = idReserva;
            this.cantidadReservada = cantidadReservada;
        }
        public RelElementoReservas()
        {
            
        }
        #endregion
    }
}
