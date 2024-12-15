using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace v4posme_console_configuration
{
    public class Function
    {
        public Function()
        {
            
        }

        static public List<string> ObtenerListadoArchivos(string rutaCarpeta)
        {
            List<string> archivos = new List<string>();
            try
            {
                // Validar si la carpeta existe
                if (Directory.Exists(rutaCarpeta))
                {
                    // Obtener los archivos y agregarlos al List
                    archivos.AddRange(Directory.GetFiles(rutaCarpeta));
                }
                else
                {
                    Console.WriteLine("La carpeta especificada no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al obtener el listado de archivos: {ex.Message}");
            }
            return archivos;
        }

        static  public List<Reemplazo> GetDataToRamplaze()
        {
            List<Reemplazo> reemplazos = new List<Reemplazo>
            {
                new Reemplazo(@"C:\xampp\phpMyAdmin\config.inc.php","$cfg['Servers'][$i]['password'] = '';","$cfg['Servers'][$i]['password'] = 'root1.2Blandon';"),

                new Reemplazo(@"C:\xampp\phpMyAdmin\libraries\config.default.php","$cfg['ExecTimeLimit'] = 300;","$cfg['ExecTimeLimit'] = 600;"),

                new Reemplazo(@"C:\xampp\php\php.ini",                                  "post_max_size=40M", "post_max_size=80M"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "upload_max_filesize=40M", "upload_max_filesize=80M"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "date.timezone=Europe/Berlin", "date.timezone=America/Managua"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";extension=xsl", ";extension=xsl\r\nextension=ixed.8.0ts.win"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "SMTP=localhost", "SMTP=smtp.gmail.com"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "smtp_port=25", "smtp_port=465"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";sendmail_from = me@example.com", "sendmail_from=posme2022@gmail.com"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";sendmail_path =", "sendmail_path=\"\\\"C:\\xampp\\sendmail\\sendmail.exe\\\" -t\""),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "session.gc_maxlifetime=1440","session.gc_maxlifetime=86400"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "session.cache_expire=180", "session.cache_expire=1440"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "session.cookie_lifetime=0", "session.cookie_lifetime=0"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";max_input_vars = 1000", "max_input_vars = 10000"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  "max_execution_time=120", "max_execution_time=0"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";extension=intl", "extension=intl\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";extension=gd", "extension=gd\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";extension=soap", "extension=soap\t"),
                new Reemplazo(@"C:\xampp\php\php.ini",                                  ";extension=imap", "extension=imap\t"),

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

            return reemplazos;
        }

        static public void AbrirURL(string url)
        {
            try
            {
                // Abre la URL en el navegador predeterminado
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
                Console.WriteLine("URL abierta correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al abrir la URL: {ex.Message}");
            }
        }

        static public void RealizarReemplazos(List<Reemplazo> reemplazos)
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

        static public void CrearAccesoDirecto(string ruta, string url, string rutaIcono)
        {
            var shell = new WshShell();
            IWshShortcut accesoDirecto = (IWshShortcut)shell.CreateShortcut(ruta);
            accesoDirecto.TargetPath = url;
            accesoDirecto.IconLocation = rutaIcono;  // Establecer el ícono
            accesoDirecto.Save();
        }


        static public void MoveFileDllGuardian(string sourcePath, string destinationPath)
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

        static public void ExecuteBatchFileWidthArgument(string batchFilePath,string argumento)
        {
            try
            {
                if (!System.IO.File.Exists(batchFilePath))
                {
                    Console.WriteLine($"El archivo .bat no existe: {batchFilePath}");
                    return;
                }

                System.Diagnostics.Process process  = new System.Diagnostics.Process();
                process.StartInfo.FileName          = batchFilePath;
                process.StartInfo.Arguments         = $"\"{argumento}\"";
                process.StartInfo.UseShellExecute   = true;
                process.Start();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar el archivo .bat: {ex.Message}");
            }
        }
        static public void ExecuteBatchFile(string batchFilePath)
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
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar el archivo .bat: {ex.Message}");
            }
        }


        static public void MoveFolderWithBackup(string sourceFolder, string destinationFolder)
        {
            try
            {
                if (!Directory.Exists(sourceFolder))
                {
                    Console.WriteLine($"La carpeta de origen no existe: {sourceFolder}");
                    return;
                }

                if (Directory.Exists(destinationFolder))
                {
                    string backupFolder = destinationFolder + "_backup_" + DateTime.Now.ToString("yyyy_MM_ddH_Hmmss");
                    Directory.Move(destinationFolder, backupFolder);
                    Console.WriteLine($"Carpeta de destino respaldada como: {backupFolder}");
                }

                Directory.CreateDirectory(destinationFolder);
                foreach (string file in Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories))
                {
                    string destinationFile = file.Replace(sourceFolder, destinationFolder);
                    string destinationDir = Path.GetDirectoryName(destinationFile);

                    if (!Directory.Exists(destinationDir))
                    {
                        Directory.CreateDirectory(destinationDir);
                    }

                    System.IO.File.Copy(file, destinationFile, true);
                }

                Console.WriteLine($"Carpeta movida exitosamente a: {destinationFolder}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mover la carpeta: {ex.Message}");
            }
        }

        static public void MoveFolderWithBackupToUpdate(string sourceFolder, string destinationFolder)
        {
            try
            {
                var excludedFiles = new HashSet<string>
                {
                    "direct-ticket-logo-micro-finanza.jpg", // Reemplaza con los nombres de archivo exactos
                    "direct-ticket-logo-micro-finanza.png",
                    "logo-micro-finanza.jpg",
                    "logo-micro-finanza.png"
                };


                if (!Directory.Exists(sourceFolder))
                {
                    Console.WriteLine($"La carpeta de origen no existe: {sourceFolder}");
                    return;
                }

                if (Directory.Exists(destinationFolder))
                {
                    string backupFolder = destinationFolder + "_backup_" + DateTime.Now.ToString("yyyy_MM_ddH_Hmmss");
                    Directory.Move(destinationFolder, backupFolder);
                    Console.WriteLine($"Carpeta de destino respaldada como: {backupFolder}");
                }

                Directory.CreateDirectory(destinationFolder);
                foreach (string file in Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories))
                {
                    // Obtiene el nombre del archivo
                    string fileName = Path.GetFileName(file);

                    // Si el archivo está en la lista de exclusión, lo saltamos
                    if (excludedFiles.Contains(fileName))
                    {
                        Console.WriteLine($"Archivo excluido: {fileName}");
                        continue;
                    }


                    string destinationFile = file.Replace(sourceFolder, destinationFolder);
                    string destinationDir = Path.GetDirectoryName(destinationFile);

                    if (!Directory.Exists(destinationDir))
                    {
                        Directory.CreateDirectory(destinationDir);
                    }

                    System.IO.File.Copy(file, destinationFile, true);
                }

                Console.WriteLine($"Carpeta movida exitosamente a: {destinationFolder}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mover la carpeta: {ex.Message}");
            }
        }

    }
}
