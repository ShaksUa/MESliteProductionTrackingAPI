using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Application.DTO
{
    public class CreateOrderRequest
    {
        [Required, MinLength(1)]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public int StationId { get; set; }
        [Required]
        public int OperatorId { get; set; }
    }
}
