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
    
    public partial class Posts
    {
        public Posts()
        {
            this.Workers = new HashSet<Workers>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Workers> Workers { get; set; }
    }
}
