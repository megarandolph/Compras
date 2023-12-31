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
    using System.ComponentModel.DataAnnotations;

    public partial class Articulos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articulos()
        {
            this.Orden_de_compra = new HashSet<Orden_de_compra>();
        }
    
        public int ArticuloId { get; set; }
        [Required]
        public string Descripción { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public Nullable<int> UnidadMedidaId { get; set; }
        [Required]
        public Nullable<int> Existencia { get; set; }
        public Nullable<bool> Estado { get; set; }
    
        public virtual Unidades_de_medidas Unidades_de_medidas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orden_de_compra> Orden_de_compra { get; set; }
    }
}
