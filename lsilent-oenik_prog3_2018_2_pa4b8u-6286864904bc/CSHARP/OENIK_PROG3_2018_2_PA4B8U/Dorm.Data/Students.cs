//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dorm.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Students
    {
        public string neptuncode { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> bdate { get; set; }
        public string phone_num { get; set; }
        public string room_id { get; set; }
    
        public virtual Rooms Rooms { get; set; }
    }
}
