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
        public bool LineaEncontrada { get; set; } 

        public Reemplazo(string nombreArchivo, string original, string reemplazo)
        {
            NombreArchivo   = nombreArchivo;
            Source          = original;
            Target          = reemplazo;
            LineaEncontrada = false;
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

                new Reemplazo(@"C:\xampp\php\php.ini",                                  "post_max_size=40M", "post_max_size=80M\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "upload_max_filesize=40M", "upload_max_filesize=80M\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "date.timezone=Europe/Berlin", "date.timezone=America/Managua\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "SMTP=localhost", "SMTP=smtp.gmail.com\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "smtp_port=25", "smtp_port=465\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";sendmail_from = me@example.com", "sendmail_from=posme2022@gmail.com\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";sendmail_path =", "sendmail_path=\"\\\"C:\\xampp\\sendmail\\sendmail.exe\\\" -t\"\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "session.gc_maxlifetime=1440","session.gc_maxlifetime=86400\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "session.cache_expire=180", "session.cache_expire=1440\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "session.cookie_lifetime=0", "session.cookie_lifetime=0\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";max_input_vars = 1000", "max_input_vars = 10000\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "max_execution_time=120", "max_execution_time=0\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";extension=intl", "extension=intl\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";extension=gd", "extension=gd\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";extension=soap", "extension=soap\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";extension=imap", "extension=imap\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";extension=xsl", ";extension=xsl\r\nextension=ixed.8.0ts.win\t"),
                
                
                new Reemplazo(@"C:\xampp\sendmail\sendmail.ini",                        "smtp_server=mail.mydomain.com", "smtp_server=smtp.gmail.com"),
                new Reemplazo(@"C:\xampp\sendmail\sendmail.ini",                        "smtp_port=25", "smtp_port=465"),
                new Reemplazo(@"C:\xampp\sendmail\sendmail.ini",                        "auth_username=", "auth_username=posme2022@gmail.com"),
                new Reemplazo(@"C:\xampp\sendmail\sendmail.ini",                        "auth_password=", "auth_password=PosmeSoftware2022"),
                new Reemplazo(@"C:\xampp\sendmail\sendmail.ini",                        "force_sender=", "force_sender=posme2022@gmail.com"),
                
                new Reemplazo(@"C:\xampp\apache\conf\extra\httpd-xampp.conf",
                    "Alias /webalizer \"C:/xampp/webalizer/\"\r\n    <Directory \"C:/xampp/webalizer\">\r\n        <IfModule php_module>\r\n    \t\t<Files \"webalizer.php\">\r\n    \t\t\tphp_admin_flag safe_mode off\r\n    \t\t</Files>\r\n        </IfModule>\r\n        AllowOverride AuthConfig\r\n        Require local\r\n        ErrorDocument 403 /error/XAMPP_FORBIDDEN.html.var\r\n    </Directory>",
                    "Alias /webalizer \"C:/xampp/webalizer/\"\r\n    <Directory \"C:/xampp/webalizer\">\r\n        <IfModule php_module>\r\n    \t\t<Files \"webalizer.php\">\r\n    \t\t\tphp_admin_flag safe_mode off\r\n    \t\t</Files>\r\n        </IfModule>\r\n        AllowOverride AuthConfig\r\n        Require local\r\n        ErrorDocument 403 /error/XAMPP_FORBIDDEN.html.var\r\n    </Directory>\r\n\r\n\t#posMe v4 desarrollo\r\n\tAlias /posmev4 \"C:/xampp/teamds2/nsSystem/v4posme/public/\"\r\n\t<Directory \"C:/xampp/teamds2/nsSystem/v4posme/public\">\r\n\t\tOptions Indexes FollowSymLinks Includes ExecCGI\r\n\t\tAllowOverride All\r\n\t\tRequire all granted\r\n\t</Directory>\r\n                    "

                )


            };


            try
            {

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Menú Principal:");
                    Console.WriteLine("1. Mover archivo Source Guardian");
                    Console.WriteLine("2. Crear acceso directo de posMe");
                    Console.WriteLine("3. Ejecutar archivo .bat de limpieza de Datos");
                    Console.WriteLine("4. Realizar reemplazo en archivos de configuracion");
                    Console.WriteLine("5. Salir");
                    Console.Write("Selecciona una opción: ");

                    string opcion = Console.ReadLine();
                    Console.Clear();

                    switch (opcion)
                    {
                        case "1":
                            // Llamada a la nueva función para mover archivos DLL
                            Console.WriteLine($"\n\n");
                            Console.WriteLine($"Mover archivo DLL guardian");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            MoveFileDllGuardian(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\dll\\ixed.8.0ts.win", @"C:\\xampp\\php\\ext\\ixed.8.0ts.win");
                            break;

                        case "2":
                            // Crear un acceso directo en el escritorio
                            Console.WriteLine($"\n\n");
                            Console.WriteLine($"Crear acceso directo de posMe");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");

                            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                            string accesoDirecto = Path.Combine(escritorio, "posMe Factura.lnk");

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

                            break;

                        case "3":
                            Console.WriteLine($"\n\n");
                            Console.WriteLine($"Limpiar Datos");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            ExecuteBatchFile(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\file_job\\archivo.bat");
                            break;

                        case "4":
                            RealizarReemplazos(reemplazos);
                            break;

                        case "5":
                            Console.WriteLine("Saliendo del programa...");
                            return;

                        default:
                            Console.WriteLine("Opción no válida. Intenta nuevamente.");
                            break;
                    }

                    Console.WriteLine("\nOperación finalizada. Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Proceso terminado. Presiona cualquier tecla para salir...");
            Console.ReadKey();

        }


        static void RealizarReemplazos(List<Reemplazo> reemplazos)
        {
            Console.WriteLine($"Remplazar archivos");
            Console.WriteLine($"*******************************************");
            Console.WriteLine($"*******************************************");

            // Reemplazar líneas en cada archivo basado en los objetos en la lista
            foreach (var reemplazo in reemplazos)
            {
                if (System.IO.File.Exists(reemplazo.NombreArchivo))
                {
                    // Leer todo el contenido del archivo
                    string contenido = System.IO.File.ReadAllText(reemplazo.NombreArchivo);

                    // Realizar el reemplazo
                    if (contenido.Contains(reemplazo.Source) && !contenido.Contains(reemplazo.Target))
                    {
                        contenido = contenido.Replace(reemplazo.Source, reemplazo.Target);
                        System.IO.File.WriteAllText(reemplazo.NombreArchivo, contenido);
                        reemplazo.LineaEncontrada = true;

                    }


                }
                else
                {
                    Console.WriteLine($"Archivo no encontrado: {reemplazo.NombreArchivo}");
                }

            }

            // Mostrar resumen al final            
            foreach (var reemplazo in reemplazos)
            {
                if (!reemplazo.LineaEncontrada)
                Console.WriteLine($"No remplazado: {reemplazo.NombreArchivo} -> {reemplazo.Target} ");                
            }
        }

        static void CrearAccesoDirecto(string ruta, string url, string rutaIcono)
        {
            var shell                   = new WshShell();
            IWshShortcut accesoDirecto  = (IWshShortcut)shell.CreateShortcut(ruta);
            accesoDirecto.TargetPath    = url;
            accesoDirecto.IconLocation  = rutaIcono;  // Establecer el ícono
            accesoDirecto.Save();
        }


        static void MoveFileDllGuardian(string sourcePath, string destinationPath)
        {
            try
            {
                if (!System.IO.File.Exists(sourcePath))
                {
                    Console.WriteLine($"El archivo de origen no existe: {sourcePath}");
                    return;
                }

                if (System.IO.File.Exists(destinationPath))
                {
                    Console.WriteLine($"El archivo de destino ya existe y no será reemplazado: {destinationPath}");
                    return;
                }

                string destinationDirectory = Path.GetDirectoryName(destinationPath);

                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                System.IO.File.Move(sourcePath, destinationPath);
                Console.WriteLine($"Archivo movido exitosamente a: {destinationPath}");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mover el archivo: {ex.Message}");
            }
        }

        static void ExecuteBatchFile(string batchFilePath)
        {
            try
            {
                if (!System.IO.File.Exists(batchFilePath))
                {
                    Console.WriteLine($"El archivo .bat no existe: {batchFilePath}");
                    return;
                }

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = batchFilePath;
                process.StartInfo.UseShellExecute = true;
                process.Start();

                Console.WriteLine($"Archivo .bat ejecutado correctamente: {batchFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar el archivo .bat: {ex.Message}");
            }
        }

    }
}
