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
    
    public partial class Course
    {
        public Course()
        {
            this.Sections = new HashSet<Section>();
            this.Students = new HashSet<Student>();
            this.Subjects = new HashSet<Subject>();
        }
    
        public string SchoolID { get; set; }
        public string CourseID { get; set; }
        public string CourseName { get; set; }
    
        public virtual ICollection<Section> Sections { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}