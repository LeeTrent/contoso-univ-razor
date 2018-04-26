using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        /*
        **************************************************************************
        The [Key] attribute is used to identify a property as the primary key (PK)
        when the property name is something other than classnameID or ID.

        PK is also its foreign key (FK) to the Instructor entity

        By default, EF Core treats the key as non-database-generated
        because the column is for an identifying relationship
        **************************************************************************
        */
        [Key]
        public int InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        /*
        **************************************************************************************
        The OfficeAssignment entity has a non-nullable Instructor navigation property because:
          - InstructorID is non-nullable.
          - An office assignment can't exist without an instructor.

        Required attribute is unnecessary because the InstructorID foreign key
        (which is also the PK) is non-nullable  
        **************************************************************************************
        */
        //[Required] (commented-out to get Pages.Instructor.Edit.OnPostAsync to work)
        public Instructor Instructor { get; set; }
    }
}