using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InvokeDLLInCSharp
{
    class PoscardReader
    {
        // 库函数使用规则
        // 1. 程序开始，调用rf_init()函数初始化串口。
        // 2. 寻卡，调用rf_card()；
        // 3. 中止操作，调用rf_halt()。
        // 4. 关闭串口，调用rf_exit()。程序退出之前，要使用此函数；否则再次执行初始化串口时将出错。
        [DllImport("mwrf32.dll", EntryPoint = "rf_init", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int rf_init(int port, Int32 baud);

        //取得读写器硬件版本号
        //[DllImport("mwrf32.dll", EntryPoint = "rf_get_status", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        //public static extern Int16 rf_get_status(Int16 icdev, byte* banben);

        [DllImport("mwrf32.dll", EntryPoint = "rf_beep")]
        public static extern int rf_beep(int icdev, uint msec);

        [DllImport("mwrf32.dll", EntryPoint = "rf_reset", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_reset(Int16 icdev, int m);

        //寻卡
        [DllImport("mwrf32.dll", EntryPoint = "rf_request")]
        //__int16 __stdcall rf_request(HANDLE icdev,unsigned char _Mode,unsigned __int16 *TagType);
        public static extern byte rf_request(int icdev, Byte _Mode, ref UInt16 TagType);

        [DllImport("mwrf32.dll", EntryPoint = "rf_load_key", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_load_key(Int16 icdev, byte passordmode, byte sector, byte[] passord);

        [DllImport("mwrf32.dll", EntryPoint = "rf_load_key_hex", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_load_key_hex(int icdev, byte passordmode, byte sector, string w_passord);

        [DllImport("mwrf32.dll", EntryPoint = "rf_exit", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void rf_exit(int icdev);

        //返回卡的序列号---- 防冲突
        //[DllImport("mwrf32.dll", EntryPoint = "rf_anticoll", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        //public static extern Int16 rf_anticoll(Int16 icdev, byte m, ulong* kahao);

        //返回卡的序列号---- 寻卡
        [DllImport("mwrf32.dll", EntryPoint = "rf_card", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        //public static extern int rf_card(int icdev, byte m, out int kahao);
        public static extern Int16 rf_card(int icdev, int mode, out UInt32 tagtype);

        //[DllImport("mwrf32.dll", EntryPoint = "rf_request", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        //public static extern Int16 rf_request(Int16 icdev, Int16 m, uint* kahao);

        //初始化块值---在进行值操作时，必须先执行初始化值函数，然后才可以读、减、加的操作
        [DllImport("mwrf32.dll", EntryPoint = "rf_initval", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_initval(int icdev, int mode, byte date);

        //读块值
        [DllImport("mwrf32.dll", EntryPoint = "rf_initval", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_initval(Int16 icdev, Int16 adr, ulong date);

        //读取卡中数据
        [DllImport("mwrf32.dll", EntryPoint = "rf_read", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_read(Int16 icdev, byte mode, byte[] date);

        //向卡中写数据
        [DllImport("mwrf32.dll", EntryPoint = "rf_write", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_write(Int16 icdev, byte mode, byte[] date);

        //验证卡某一扇区密码
        [DllImport("mwrf32.dll", EntryPoint = "rf_authentication", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]

        public static extern Int16 rf_authentication(Int16 icdev, byte mode, byte SecNr);

        //检测指定数据是否与卡中数据一致
        [DllImport("mwrf32.dll", EntryPoint = "rf_check_write", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_check_write(Int16 icdev, int snr, int authmode, int adr, byte date);

        //终止该卡操作
        [DllImport("mwrf32.dll", EntryPoint = "rf_halt", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_halt(int icdev);



        /*
        [DllImport("mwrf32.dll", EntryPoint = "rf_init", CallingConvention = CallingConvention.ThisCall)]
        public static extern int rf_init(int port, long baud);
        [DllImport("mwrf32.dll", EntryPoint = "rf_exit", CallingConvention = CallingConvention.StdCall)]
        public static extern void rf_exit(int icdev);
        [DllImport("mwrf32.dll", EntryPoint = "rf_beep", CallingConvention = CallingConvention.ThisCall)]
        public static extern int rf_beep(int icdev, uint msec);
        [DllImport("mwrf32.dll", EntryPoint = "rf_reset", CallingConvention = CallingConvention.ThisCall)]
        public static extern int rf_reset(int icdev, uint msec);
        [DllImport("mwrf32.dll", EntryPoint = "rf_card", CallingConvention = CallingConvention.StdCall)]
        public static extern int rf_card(int icdev, byte mode, ref ulong snr);
        [DllImport("mwrf32.dll", EntryPoint = "rf_halt", CallingConvention = CallingConvention.StdCall)]
        public static extern int rf_halt(int icdev);
        [DllImport("mwrf32.dll", EntryPoint = "rf_id", CallingConvention = CallingConvention.ThisCall)]
        public static extern int rf_id(int icdev, byte bcnt, ref ulong snr);
        */
    }
}
