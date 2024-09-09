using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vinos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlImage { get; set; }
        public Tipo Tipo { get; set; }
        public Bodega Bodega { get; set; }
        public DateTime Anio { get; set; }
        public bool Activo { get; set; }
    }
}
