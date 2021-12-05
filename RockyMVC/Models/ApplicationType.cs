using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RockyMVC.Models
{
	public class ApplicationType
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[DisplayName("Full Name")]
		public string Name { get; set; }
	}
}
