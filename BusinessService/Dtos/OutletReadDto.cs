using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessService.Dtos
{
    public class OutletReadDto
    {
        public int OutletId { get; set; }
        public string OutletName { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public int AvailableFoodPackets { get; set; }
        public string FoodType { get; set; }
        public int RequiredVolunteers { get; set; }
        public string Date { get; set; }
    }
}
