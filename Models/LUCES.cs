//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC2._0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LUCES
    {
        public int PRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public string SKU { get; set; }
        public Nullable<decimal> PRECIO { get; set; }
        public int MARCA { get; set; }
        public int MODELO { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<int> EXISTENCIA { get; set; }
        public int PROVEEDOR { get; set; }
        public string CODIGO { get; set; }
    
        public virtual Marca Marca1 { get; set; }
        public virtual Modelo Modelo1 { get; set; }
        public virtual Proveedor Proveedor1 { get; set; }
    }
}
