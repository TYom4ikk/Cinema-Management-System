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
    
    public partial class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportData { get; set; }
        public int PostId { get; set; }
        public long Salary { get; set; }
        public string Responsibilities { get; set; }
        public string Requirements { get; set; }
    
        public virtual Post Post { get; set; }
    }
}
