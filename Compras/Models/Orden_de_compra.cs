//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Compras.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orden_de_compra
    {
        public int Numero_de_orden { get; set; }
        public Nullable<System.DateTime> Fecha_orden { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<int> Articulo { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<int> Unidad_de_medida { get; set; }
        public Nullable<decimal> Costo { get; set; }
        public Nullable<int> UsuarioId { get; set; }
        public Nullable<bool> Enviado { get; set; }
    
        public virtual Articulos Articulos { get; set; }
        public virtual Unidades_de_medidas Unidades_de_medidas { get; set; }
        public virtual usuarios usuarios { get; set; }
    }
}
