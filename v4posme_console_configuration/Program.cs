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
   


    internal class Program
    {
        static void Main(string[] args)
        {
            

            Function objFunction = new Function();
            try
            {

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Menú Principal:");
                    Console.WriteLine("01. Instalar todos los programas");
                    Console.WriteLine("02. Salir");
                    Console.WriteLine("\n");
                    Console.WriteLine("03. Mover la carpeta de de posMe al directorio de Xampp para Instalar");
                    Console.WriteLine("04. Mover la carpeta de de posMe al directorio de Xampp para Actualizar");
                    Console.WriteLine("\n");
                    Console.WriteLine("05. Mover extension de Source guardian");
                    Console.WriteLine("06. Crear acceso directo del link de posMe");
                    Console.WriteLine("07. Realizar reemplazo en archivos de configuracion");
                    Console.WriteLine("\n");
                    Console.WriteLine("08. Abrir Url de Syn Structuras");
                    Console.WriteLine("09. Abrir Url de Syn Insert end Update Datos");
                    Console.WriteLine("10. Abrir Url de Syn Insert Only Datos");
                    Console.WriteLine("11. Abrir Url de Syn Delete Only Datos");
                    Console.WriteLine("12. Abrir Url de Syn Clear File");
                    Console.WriteLine("\n");
                    Console.WriteLine("13. Restore_backup_biometric.bat");
                    Console.WriteLine("14. Restore_backup_posmev4.bat");
                    Console.WriteLine("15. Restore_backup_posmev4_merge.bat");
                    Console.WriteLine("16. Restore_clear_database.bat");
                    Console.WriteLine("17. Restore_usuarios.bat");
                    Console.WriteLine("18. Ver listado de .sql y ejecutar el seleccionado");
                    Console.WriteLine("19. Realizar respaldo de posMe");
                    Console.WriteLine("20. Realizar respaldo de Biometric");
                    Console.Write("Selecciona una opción: ");

                    string opcion = Console.ReadLine();
                    Console.Clear();

                    switch (opcion)
                    {
                        case "18":

                            List<string> listaArchivos = Function.ObtenerListadoArchivos(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\file_sql");                            
                            if (listaArchivos.Count == 0)
                            {
                                Console.WriteLine("No se encontraron archivos en la carpeta especificada.");
                                break;
                            }


                            Console.WriteLine("Archivos encontrados:");
                            foreach (string archivo in listaArchivos)
                            {
                                Console.WriteLine(archivo.Replace(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\file_sql\", ""));
                            }
                            Console.WriteLine("Escriba el nombre del archivo a ejecutar:");
                            string nombreFileToExecute  = Console.ReadLine();
                            Function.ExecuteBatchFileWidthArgument(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\file_job\\restore_execute_file.bat", nombreFileToExecute);
                            
                            break;
                        case "19":
                            Console.WriteLine($"Respaldo Realizado posMe");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.ExecuteBatchFile(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\file_job\\backup_posmev4.bat");
                            break;

                        case "20":
                            Console.WriteLine($"Respaldo Realizado BioMetric");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.ExecuteBatchFile(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\file_job\\backup_biometric.bat");
                            break;

                        case "17":
                            Console.WriteLine($"Restaurar Restaurar Usuario");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.ExecuteBatchFile(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\file_job\\restore_usuarios.bat");
                            break;

                        case "16":
                            Console.WriteLine($"Restaurar Clear DataBase posMe");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.ExecuteBatchFile(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\file_job\\restore_clear_database.bat");
                            break;

                        case "15":
                            Console.WriteLine($"Restaurar Merge");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.ExecuteBatchFile(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\file_job\\restore_backup_posmev4_merge.bat");
                            break;

                        case "13":
                            Console.WriteLine($"Restaurar Biometric");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.ExecuteBatchFile(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\file_job\\restore_backup_biometric.bat");
                            break;

                        case "14":
                            Console.WriteLine($"Restaurar posMe");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.ExecuteBatchFile(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\file_job\\restore_backup_posmev4.bat");
                            break;

                        case "08":
                            Console.WriteLine($"Abrir Url de Syn Structuras");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.AbrirURL(@"http://localhost/posmev4/core_merge/merge_of_posme_merge_to_posme_structure/2");
                            break;
                        case "09":
                            Console.WriteLine($"Abrir Url de Syn Insert end Update Datos");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.AbrirURL(@"http://localhost/posmev4/core_merge/merge_of_posme_merge_to_posme_data_insert_and_update/2");
                            break;
                        case "10":
                            Console.WriteLine($"Abrir Url de Syn Insert Only Datos");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.AbrirURL(@"http://localhost/posmev4/core_merge/merge_of_posme_merge_to_poeme_data_onlyinsert/2");
                            break;
                        case "11":
                            Console.WriteLine($"Abrir Url de Syn Delete Only Datos");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.AbrirURL(@"http://localhost/posmev4/core_merge/merge_of_posme_merge_to_posme_data_delete/2");
                            break;
                        case "12":
                            Console.WriteLine($"Abrir Url de Syn Clear File");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.AbrirURL(@"http://localhost/posmev4/core_merge/merge_of_posme_merge_to_posme_initialize/2");
                            break;



                        case "03":
                            Console.WriteLine($"Mover carpeta de posMe para Instalar");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.MoveFolderWithBackup(@"C:\\TeamDS-Importacion\\v4posme", @"C:\\xampp\\teamds2\\nsSystem\\v4posme");
                            break;
                        case "04":
                            Console.WriteLine($"Mover carpeta de posMe para Actualizar");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.MoveFolderWithBackupToUpdate(@"C:\\TeamDS-Importacion\\v4posme", @"C:\\xampp\\teamds2\\nsSystem\\v4posme");
                            break;
                        case "05":
                            // Llamada a la nueva función para mover archivos DLL
                            Console.WriteLine($"Mover archivo DLL guardian");
                            Console.WriteLine($"*******************************************");
                            Console.WriteLine($"*******************************************");
                            Function.MoveFileDllGuardian(@"C:\\xampp\\teamds2\\nsSystem\\v4posme\\public\\resource\\dll\\ixed.8.0ts.win", @"C:\\xampp\\php\\ext\\ixed.8.0ts.win");
                            break;

                        case "06":
                            // Crear un acceso directo en el escritorio
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
                                Function.CrearAccesoDirecto(accesoDirecto, "http://localhost/posmev4/", @"C:\\Windows\\System32\\shell32.dll,14");
                                Console.WriteLine("Acceso directo creado correctamente en el escritorio.");
                            }

                            break;

                        case "07":
                            Function.RealizarReemplazos(Function.GetDataToRamplaze());
                            break;

                        case "02":
                            Console.WriteLine("Saliendo del programa...");
                            return;

                        default:
                            Console.WriteLine("Opción no válida. Intenta nuevamente o dicha accion se hace manual.");
                            break;
                    }

                    Console.WriteLine("Operación finalizada. Presiona cualquier tecla para continuar...");
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

        

    }
}
