using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TD_SPA_Project.Entity
{
    [Table("customer")]
	public class Customer
	{
		public Customer()
		{
		}
        [Key]
        public int iduser { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string member { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string last_name { get; set; }
    }
}

