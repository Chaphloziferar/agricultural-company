using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Agropecuaria
{
    public class ProductoCongeladoAire : ProductoCongelado
    {
        public ProductoCongeladoAire(string nombre, DateTime fechaCaducidad, int numeroLote, DateTime fechaEnvasado, 
            string paisDeOrigen, double tempMantenimiento, double porcentajeNitrogeno, double porcentajeOxigeno, 
            double porcentajeDioxidoCarbono, double porcentajeVaporAgua) : base(nombre, fechaCaducidad, numeroLote, 
                fechaEnvasado, paisDeOrigen, tempMantenimiento)
        {
            this.porcentajeNitrogeno = porcentajeNitrogeno;
            this.porcentajeOxigeno = porcentajeOxigeno;
            this.porcentajeDioxidoCarbono = porcentajeDioxidoCarbono;
            this.porcentajeVaporAgua = porcentajeVaporAgua;
        }

        public double porcentajeNitrogeno { get; set; }

        public double porcentajeOxigeno { get; set; }

        public double porcentajeDioxidoCarbono { get; set; }

        public double porcentajeVaporAgua { get; set; }

        public override string nombre { get; set; }

        public override DateTime fechaCaducidad { get; set; }

        public override int numeroLote { get; set; }

        public override DateTime fechaEnvasado { get; set; }

        public override string paisDeOrigen { get; set; }

        public override double tempMantenimiento { get; set; }
    }
}
