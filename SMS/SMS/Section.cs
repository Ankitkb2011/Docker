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
    
    public partial class Section
    {
        public Section()
        {
            this.Students = new HashSet<Student>();
        }
    
        public string CourseID { get; set; }
        public string SectionID { get; set; }
        public string SectionName { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
