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
    
    public partial class FilmActor
    {
        public int FilmId { get; set; }
        public long ActorId { get; set; }
        public string Role { get; set; }
    
        public virtual Actor Actor { get; set; }
        public virtual Film Film { get; set; }
    }
}
