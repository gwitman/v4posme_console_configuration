using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v4posme_console_configuration
{
    public class Reemplazo
    {
        public string NombreArchivo { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public bool LineaEncontrada { get; set; }

        public Reemplazo(string nombreArchivo, string original, string reemplazo)
        {
            NombreArchivo = nombreArchivo;
            Source = original;
            Target = reemplazo;
            LineaEncontrada = false;
        }
    }

}
