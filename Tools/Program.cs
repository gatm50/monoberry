using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0]=="-powershell")
            {
                if(!string.IsNullOrEmpty(args[1]))
                {
                    string projectPath=  "";
                    string command=string.Format(@"-file '{0}\{1}'",projectPath, args[1]);
                    ExecuteCommand(command);
                }
            }
        }

        static void ExecuteCommand(string _Command)
        {
            //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque.             
            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).            
            //Para mas informacion consulte la ayuda de la consola con cmd.exe /?             
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + _Command);

            // Indicamos que la salida del proceso se redireccione en un Stream            
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)            
            procStartInfo.CreateNoWindow = false;
            //Inicializa el proceso           
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto            
            string result = proc.StandardOutput.ReadToEnd();
            //Muestra en pantalla la salida del Comando            
            Console.WriteLine(result);
        }
    }
}
