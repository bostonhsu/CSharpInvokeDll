using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InvokeDLLInCSharp
{
    class CppDll
    {
        [DllImport("MyDLLFun.dll", EntryPoint = "Add", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int a, int b);
        [DllImport("MyDLLFun.dll", EntryPoint = "Pow", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Pow(ref int x, double y);
    }
}
