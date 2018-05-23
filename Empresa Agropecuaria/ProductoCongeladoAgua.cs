using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Agropecuaria
{
    public class ProductoCongeladoAgua : ProductoCongelado
    {
        public ProductoCongeladoAgua(string nombre, DateTime fechaCaducidad, int numeroLote, DateTime fechaEnvasado, 
            string paisDeOrigen, double tempMantenimiento, double salinidadAgua) : base(nombre, fechaCaducidad, 
                numeroLote, fechaEnvasado, paisDeOrigen, tempMantenimiento)
        {
            this.salinidadAgua = salinidadAgua;
        }

        public double salinidadAgua { get; set; }

        public override string nombre { get; set; }

        public override DateTime fechaCaducidad { get; set; }

        public override int numeroLote { get; set; }

        public override DateTime fechaEnvasado { get; set; }

        public override string paisDeOrigen { get; set; }

        public override double tempMantenimiento { get; set; }
    }
}
