//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Requried")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Requried")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Requried")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Requried")]
        [MinLength(11,ErrorMessage ="Mobile No should be 11 diget")]
        public string Mobile { get; set; }
        public string Description { get; set; }
    }
}
