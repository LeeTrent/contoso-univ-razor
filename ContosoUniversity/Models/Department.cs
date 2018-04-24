using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        /*
        ******************************************************************************
        A department may or may not have an administrator.
        
        An administrator is always an instructor. Therefore the InstructorID property
        is included as the FK to the Instructor entity.

        The navigation property is named Administrator but holds an Instructor entity

        The question mark (?) for InstructorID specifies the property is nullable.
        ******************************************************************************
        */
        public int? InstructorID { get; set; }      
        public Instructor Administrator { get; set; }

        /*
        ******************************************************************************
        A department may have many courses, so there's a Courses navigation property
        ******************************************************************************
        */
        public ICollection<Course> Courses { get; set; }
    }
}