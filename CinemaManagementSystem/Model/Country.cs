//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaManagementSystem.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Country
    {
        public Country()
        {
            this.ProducingCompanies = new HashSet<ProducingCompany>();
        }
    
        public short Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<ProducingCompany> ProducingCompanies { get; set; }
    }
}
