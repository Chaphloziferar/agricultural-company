using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Agropecuaria
{
    public class ProductoRefrigerado : ProductosRefriConge
    {
        public ProductoRefrigerado(string nombre, DateTime fechaCaducidad, int numeroLote, DateTime fechaEnvasado, 
            string paisDeOrigen, double tempMantenimiento, string codigoSupAlimentaria) : base(nombre, 
                fechaCaducidad, numeroLote, fechaEnvasado, paisDeOrigen, tempMantenimiento)
        {
            this.codigoSupAlimentaria = codigoSupAlimentaria;
        }


        public string codigoSupAlimentaria { get; set; }

        public override string nombre { get; set; }

        public override DateTime fechaCaducidad { get; set; }

        public override int numeroLote { get; set; }

        public override DateTime fechaEnvasado { get; set; }

        public override string paisDeOrigen { get; set; }

        public override double tempMantenimiento { get; set; }
    }
}
