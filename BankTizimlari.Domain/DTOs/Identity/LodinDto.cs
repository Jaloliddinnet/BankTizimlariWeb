using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTizimlari.Domain.DTOs.AuthDTOs
{
    public class LodinDto
    {
        public string Username { get; set; }

        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1}", MinimumLength = 3)]
        public string Password { get; set; }
    }
}
