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
    
    public partial class shulf
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public shulf()
        {
            this.Books = new HashSet<Books>();
        }
    
        public int IdShelf { get; set; }
        public Nullable<int> IdShelvingUH { get; set; }
        public Nullable<int> IdShelvingWH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Books> Books { get; set; }
        public virtual ShelingUnitHall ShelingUnitHall { get; set; }
        public virtual ShelingWarehouse ShelingWarehouse { get; set; }
    }
}
