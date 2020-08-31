using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAtividadeEntrevista.Models
{
    public class BeneficiarioModel
    {
        public long Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        //[Remote("ValidaCPF", "Validacao",  ErrorMessage = "CPF inválido")]
        [RegularExpression(@"^(\d{3}\.\d{3}\.\d{3}\-\d{2})$|^(\d{11})", ErrorMessage = "CPF incorreto")]
        public string CPF { get; set; }

        public long IdCliente { get; set; }
    }
}