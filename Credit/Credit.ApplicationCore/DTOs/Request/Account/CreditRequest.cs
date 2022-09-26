using System.ComponentModel.DataAnnotations;

namespace Credit.ApplicationCore.DTOs.Request.Account
{
    public class CreditRequest
    {
        [Required]
        public int Agency { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public int CurrentAccountDigit { get; set; }
        [Required]
        public decimal Value { get; set; }
    }
}