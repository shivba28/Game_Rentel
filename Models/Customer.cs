//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string admin { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}
