using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Agropecuaria
{
    public abstract class ProductoCongelado : ProductosRefriConge
    {
        public ProductoCongelado(string nombre, DateTime fechaCaducidad, int numeroLote, DateTime fechaEnvasado, 
            string paisDeOrigen, double tempMantenimiento) : base(nombre, fechaCaducidad, numeroLote, fechaEnvasado, 
                paisDeOrigen, tempMantenimiento)
        {
        }
    }
}
