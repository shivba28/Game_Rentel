//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            this.Rentals = new HashSet<Rental>();
        }
    
        public int game_id { get; set; }
        public string game_name { get; set; }
        public Nullable<int> genre_id { get; set; }
        public Nullable<System.DateTime> release_date { get; set; }
        public Nullable<int> availability { get; set; }
        public Nullable<int> game_price { get; set; }
    
        public virtual Genre Genre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
