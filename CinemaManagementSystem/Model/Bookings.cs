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
    
    public partial class Bookings
    {
        public long Id { get; set; }
        public Nullable<long> SessionId { get; set; }
        public int SeatId { get; set; }
        public System.DateTime SaleDateTime { get; set; }
        public System.DateTime ExpiresDateTime { get; set; }
    
        public virtual Seats Seats { get; set; }
        public virtual Sessions Sessions { get; set; }
    }
}
