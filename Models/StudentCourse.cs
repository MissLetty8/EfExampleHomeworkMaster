//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EfExample2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Course Course1 { get; set; }
        public virtual Student Student { get; set; }
        public virtual Student Student1 { get; set; }
    }
}
