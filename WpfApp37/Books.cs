//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp37
{
    using System;
    using System.Collections.Generic;
    
    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            this.Magazine = new HashSet<Magazine>();
        }
    
        public int IdBook { get; set; }
        public string NameBook { get; set; }
        public int NameAuth { get; set; }
        public int NumberShelf { get; set; }
        public System.DateTime YearBook { get; set; }
        public string Status { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public int QuantityWH { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Gener Gener { get; set; }
        public virtual shulf shulf { get; set; }
        public virtual Status Status1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Magazine> Magazine { get; set; }
    }
}
