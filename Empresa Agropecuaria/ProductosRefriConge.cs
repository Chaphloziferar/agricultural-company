using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Agropecuaria
{
    public abstract class ProductosRefriConge : Producto
    {
        public ProductosRefriConge(string nombre, DateTime fechaCaducidad, int numeroLote, DateTime fechaEnvasado, 
            string paisDeOrigen, double tempMantenimiento) : base(nombre, fechaCaducidad, numeroLote, 
                fechaEnvasado, paisDeOrigen)
        {
            this.tempMantenimiento = tempMantenimiento;
        }

        public abstract double tempMantenimiento { get; set; }
    }
}
