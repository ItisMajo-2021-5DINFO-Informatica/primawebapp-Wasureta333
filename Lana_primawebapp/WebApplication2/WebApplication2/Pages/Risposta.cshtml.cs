using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class RispostaModel : PageModel
    {
        public string Nome { get; set; }

        public string Cognome { get; set;  }
        public void OnGet(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }
    }
}
