using System.Collections.Generic;

namespace OLProject.Models
{
    public class CustomerList : List<Customer>
    {
        public string ImageUrl { get; set; }
    }
}