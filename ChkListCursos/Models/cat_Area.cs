//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChkListCursos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cat_Area
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cat_Area()
        {
            this.Administrador = new HashSet<Administrador>();
            this.Certificado = new HashSet<Certificado>();
            this.Empleado = new HashSet<Empleado>();
            this.Verificador = new HashSet<Verificador>();
        }
    
        public int idArea { get; set; }
        public System.Guid UuidArea { get; set; }
        public string NombreArea { get; set; }
        public System.DateTime FG { get; set; }
        public string UG { get; set; }
        public Nullable<System.DateTime> FM { get; set; }
        public string UM { get; set; }
        public Nullable<System.DateTime> FB { get; set; }
        public string UB { get; set; }
        public bool ST { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Administrador> Administrador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Certificado> Certificado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleado> Empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verificador> Verificador { get; set; }
    }
}
