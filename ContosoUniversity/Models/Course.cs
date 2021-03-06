using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        /*
        ******************************************************************
        A course is assigned to one department, 
        so there's a DepartmentID FK and a Department navigation property.
        ******************************************************************        
        */
        public int DepartmentID { get; set; }

        public Department Department { get; set; }

        /*
        ******************************************************************
        A course can have any number of students enrolled in it,
        so the Enrollments navigation property is a collection
        ******************************************************************        
        */
        public ICollection<Enrollment> Enrollments { get; set; }

        /*
        ******************************************************************
        A course may be taught by multiple instructors,
        so the CourseAssignments navigation property is a collection
        ******************************************************************        
        */
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}