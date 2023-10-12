using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        unsafe static void printc(byte b, int loc, byte colors)
        {
            int i = loc;
            byte* fbp = (byte*)i;
            *((byte*)(fbp)) = (byte)b;
            *((byte*)(fbp + 1)) = (byte)colors;
        }
        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
        }
        
        protected override void Run()
        {
            int n = 0;
            int i = 0xb8000;
            byte b = 65;
            for (n=0;n<4000;n=n+2)
            printc(b, i+n,0xe);
            var input = Console.ReadLine();
            
        }
    }
}
