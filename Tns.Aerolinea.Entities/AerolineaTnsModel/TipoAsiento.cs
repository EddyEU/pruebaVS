
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Tns.Aerolinea.Entities.AerolineaTnsModel
{

using System;
    using System.Collections.Generic;
    
public partial class TipoAsiento
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public TipoAsiento()
    {

        this.Asiento = new HashSet<Asiento>();

        this.Tarifa = new HashSet<Tarifa>();

        this.TiquetePasajero = new HashSet<TiquetePasajero>();

    }


    public short IdTipoAsiento { get; set; }

    public string Nombre { get; set; }

    public string Observaciones { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Asiento> Asiento { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Tarifa> Tarifa { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<TiquetePasajero> TiquetePasajero { get; set; }

}

}
