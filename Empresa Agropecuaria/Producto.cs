using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Agropecuaria
{
    public abstract class Producto
    {
        public Producto(string nombre, DateTime fechaCaducidad, int numeroLote, DateTime fechaEnvasado, string paisDeOrigen)
        {
            this.nombre = nombre;
            this.fechaCaducidad = fechaCaducidad;
            this.numeroLote = numeroLote;
            this.fechaEnvasado = fechaEnvasado;
            this.paisDeOrigen = paisDeOrigen;
        }

        public abstract string nombre { get; set; }

        public abstract DateTime fechaCaducidad { get; set; }

        public abstract int numeroLote { get; set; }

        public abstract DateTime fechaEnvasado { get; set; }

        public abstract string paisDeOrigen { get; set; }
    }
}
