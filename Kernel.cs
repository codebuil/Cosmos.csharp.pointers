using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;
using IL2CPU.API.Attribs;
using System.Security.Cryptography;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {


        static int locss = 0xb8000;
        Sys.FileSystem.CosmosVFS fs;

        unsafe static void printc(byte b, int loc, byte colors)
        {
            int i = loc;
            byte* fbp = (byte*)i;
            *((byte*)(fbp)) = (byte)b;
            *((byte*)(fbp + 1)) = (byte)colors;
            locss++;
            locss++;
        }
        protected override void BeforeRun()
        {
            fs = new Cosmos.System.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
        }


        [ManifestResourceStream(ResourceName = "CosmosKernel1.MY.TXT")]
        public static byte[] ffile;

        protected override void Run()
        {
            Console.Clear();
            Console.WriteLine("");

            try
            {
                foreach (byte byt in ffile)
                {
                    printc(byt, locss, 0x60);

                }

               
                

            }
            catch (Exception e) 
            {
                Console.WriteLine(e.ToString());
            }
                
            // Aguarde a entrada do usuário para encerrar
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            var input = Console.ReadLine();
            
        }
    }
}
