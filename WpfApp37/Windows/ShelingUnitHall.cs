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
    
    public partial class ShelingUnitHall
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShelingUnitHall()
        {
            this.shulf = new HashSet<shulf>();
        }
    
        public int IdSelvingHall { get; set; }
        public string Thema { get; set; }
        public int IdConsultant { get; set; }
    
        public virtual Staff Staff { get; set; }
        public virtual ThemeName ThemeName { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<shulf> shulf { get; set; }
    }
}
