//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class AttendanceRegister
    {
        public string EnrollmentID { get; set; }
        public System.DateTime SchoolDate { get; set; }
        public string Status { get; set; }
    
        public virtual Student Student { get; set; }
    }
}