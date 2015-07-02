using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorContatos.Models.ViewModels
{
    public class TelefoneCreate
    {
        public int CodFone { get; set; }
        public int CodContato { get; set; }
        public string Numero { get; set; }
        public int CodOperadora { get; set; }

        public string Contato { get; set; }
        public List<Operadora> Operadora { get; set; }
    }
}