using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class CourseAssignment
    {
        /*
        ************************************************************************
        FKs are not nullable.
        The two FKs in CourseAssignment (InstructorID and CourseID)
        together uniquely identify each row of the CourseAssignment table.
        
        CourseAssignment doesn't require a dedicated PK.
        The InstructorID and CourseID properties function as a composite PK.
        The only way to specify composite PKs to EF Core is with the fluent API.

        The composite key ensures:
          - Multiple rows are allowed for one course.
          - Multiple rows are allowed for one instructor.
          - Multiple rows for the same instructor and course isn't allowed.
        ************************************************************************
        */

        public int InstructorID { get; set; }
        public int CourseID { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}