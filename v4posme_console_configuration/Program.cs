using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IWshRuntimeLibrary; // Necesario para crear accesos directos

namespace v4posme_console_configuration
{

    // Definimos una clase para representar los objetos con los tres campos
    public class Reemplazo
    {
        public string NombreArchivo { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }

        public Reemplazo(string nombreArchivo, string original, string reemplazo)
        {
            NombreArchivo   = nombreArchivo;
            Source          = original;
            Target          = reemplazo;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Reemplazo> reemplazos = new List<Reemplazo>
            {
                new Reemplazo(@"C:\xampp\phpMyAdmin\config.inc.php","$cfg['Servers'][$i]['password'] = '';","$cfg['Servers'][$i]['password'] = 'root1.2Blandon';"),

                new Reemplazo(@"C:\xampp\phpMyAdmin\libraries\config.default.php","$cfg['ExecTimeLimit'] = 300;","$cfg['ExecTimeLimit'] = 600;"),

                new Reemplazo(@"C:\xampp\php\php.ini",                                  "post_max_size=40M", "post_max_size=80M"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "upload_max_filesize=40M", "upload_max_filesize=80M"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "", "date.timezone=America/Managua"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "", "SMTP = smtp.gmail.com"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "", "smtp_port = 465"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "", "sendmail_from = posme2022@gmail.com"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "", "sendmail_path = \"\\\"C:\\xampp\\sendmail\\sendmail.exe\\\" -t\""),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "session.gc_maxlifetime \t\t= 86400", ""),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "session.cache_expire \t\t= 1440", ""),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "session.cookie_lifetime \t= 0", ""),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "max_input_vars \t\t\t\t= 10000", ""),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "max_execution_time\t\t\t= 0", ""),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "extension=intl", ""),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "extension=gd", ""),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "extension=soap", ""),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "extension=imap", ""),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "extension=ixed.8.0ts.win", ""),


                new Reemplazo(@"C:\xampp\sendmail\sendmail.ini",                        ";smtp_server=mail.mydomain.com", "smtp_server=smtp.gmail.com"),
                new Reemplazo(@"C:\xampp\sendmail\sendmail.ini",                        ";smtp_port=25", "smtp_port=465"),
                new Reemplazo(@"C:\xampp\sendmail\sendmail.ini",                        ";auth_username=", "auth_username=posme2022@gmail.com"),
                new Reemplazo(@"C:\xampp\sendmail\sendmail.ini",                        ";auth_password=", "auth_password=PosmeSoftware2022"),
                new Reemplazo(@"C:\xampp\sendmail\sendmail.ini",                        ";force_sender=", "force_sender=posme2022@gmail.com"),

                new Reemplazo(@"C:\xampp\apache\conf\extra\httpd-xampp.conf","Alias /webalizer \"C:/xampp/webalizer/\"\r\n    <Directory \"C:/xampp/webalizer\">\r\n        <IfModule php_module>\r\n    \t\t<Files \"webalizer.php\">\r\n    \t\t\tphp_admin_flag safe_mode off\r\n    \t\t</Files>\r\n        </IfModule>\r\n        AllowOverride AuthConfig\r\n        Require local\r\n        ErrorDocument 403 /error/XAMPP_FORBIDDEN.html.var\r\n    </Directory>","Alias /webalizer \"C:/xampp/webalizer/\"\r\n    <Directory \"C:/xampp/webalizer\">\r\n        <IfModule php_module>\r\n    \t\t<Files \"webalizer.php\">\r\n    \t\t\tphp_admin_flag safe_mode off\r\n    \t\t</Files>\r\n        </IfModule>\r\n        AllowOverride AuthConfig\r\n        Require local\r\n        ErrorDocument 403 /error/XAMPP_FORBIDDEN.html.var\r\n    </Directory>\r\n\t\r\n\t\r\n\t#posMe v4 desarrollo\r\n\tAlias /posmev4 \"C:/xampp/teamds2/nsSystem/v4posme/public/\"\r\n\t<Directory \"C:/xampp/teamds2/nsSystem/v4posme/public\">\r\n\t\tOptions Indexes FollowSymLinks Includes ExecCGI\r\n\t\tAllowOverride All\r\n\t\tRequire all granted\r\n\t</Directory>")


            };


            try
            {

                Console.WriteLine($"Remplazar archivos PASO 1/2");
                Console.WriteLine($"*******************************************");
                Console.WriteLine($"*******************************************");

                // Reemplazar líneas en cada archivo basado en los objetos en la lista
                foreach (var reemplazo in reemplazos)
                {
                    if (System.IO.File.Exists(reemplazo.NombreArchivo))
                    {
                        
                        Console.WriteLine($"Procesando archivo: {reemplazo.NombreArchivo}");                                         
                        string[] lineas = System.IO.File.ReadAllLines(reemplazo.NombreArchivo);

                        for (int i = 0; i < lineas.Length; i++)
                        {
                            // Realiza el reemplazo si encuentra el string original
                            if (lineas[i].Contains(reemplazo.Source))
                            {
                                lineas[i] = lineas[i].Replace(reemplazo.Source, reemplazo.Target);
                                Console.WriteLine($"Reemplazada línea: {reemplazo.Source} -> {reemplazo.Target}");
                            }
                        }

                        // Guarda los cambios en el archivo
                        System.IO.File.WriteAllLines(reemplazo.NombreArchivo, lineas);
                        Console.WriteLine($"Archivo procesado correctamente: {reemplazo.NombreArchivo}");                        
                    }
                    else
                    {
                        Console.WriteLine($"Archivo no encontrado: {reemplazo.NombreArchivo}");                        
                    }
                    
                }

                // Crear un acceso directo en el escritorio
                Console.WriteLine($"\n\n");
                Console.WriteLine($"Crear acceso directo PASO 2/2");
                Console.WriteLine($"*******************************************");
                Console.WriteLine($"*******************************************");

                string escritorio       = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string accesoDirecto    = Path.Combine(escritorio, "posMe Factura.lnk");

                // Validar si el acceso directo ya existe
                if (System.IO.File.Exists(accesoDirecto))
                {
                    Console.WriteLine("El acceso directo ya existe en el escritorio.");
                }
                else
                {
                    CrearAccesoDirecto(accesoDirecto, "http://localhost/posmev4/", @"C:\\Windows\\System32\\shell32.dll,14");
                    Console.WriteLine("Acceso directo creado correctamente en el escritorio.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Proceso terminado. Presiona cualquier tecla para salir...");
            Console.ReadKey();

        }


        static void CrearAccesoDirecto(string ruta, string url, string rutaIcono)
        {
            var shell                   = new WshShell();
            IWshShortcut accesoDirecto  = (IWshShortcut)shell.CreateShortcut(ruta);
            accesoDirecto.TargetPath    = url;
            accesoDirecto.IconLocation  = rutaIcono;  // Establecer el ícono
            accesoDirecto.Save();
        }

    }
}
