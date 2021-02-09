using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.Model
{
    public class outlet
    {
        [Key]
        public int OutletId { get; set; }

        [Required]
        [MaxLength(100)]
        public string OutletName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Landmark { get; set; }
        [Required]
        public int AvailableFoodPackets { get; set; }
        [Required]
        public string FoodType { get; set; }
        [Required]
        public int RequiredVolunteers { get; set; }
        [Required]
        public string Date { get; set; }
    }
}
