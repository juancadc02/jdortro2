using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modelos
{
    /// <summary>
    /// Entidad de la tabla reservas.
    /// </summary>
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idReserva { get; set; } = 0;
        public DateTime fchReserva { get; set; } = new DateTime(9999, 12, 31, 0, 0, 0);

        #region Constructores
        public Reserva()
        {
        }
        public Reserva(long idReserva, DateTime fchReserva)
        {
            this.idReserva = idReserva;
            this.fchReserva = fchReserva;
        }
        public Reserva( DateTime fchReserva)
        {
            this.fchReserva = fchReserva;
        }


        #endregion
    }
}
