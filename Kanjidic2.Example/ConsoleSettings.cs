using System.Runtime.InteropServices;

namespace Kanjidic2.Example;

public class ConsoleSettings
{
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool SetCurrentConsoleFontEx(IntPtr hConsoleOutput, bool bMaximumWindow, ref ConsoleFontInfoEx lpConsoleCurrentFontEx);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ConsoleFontInfoEx
    {
        public int cbSize;
        public int nFont;
        public Coord dwFontSize;
        public int FontFamily;
        public int FontWeight;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string FaceName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Coord
    {
        public short X;
        public short Y;
    }

    public static void SetConsoleFont(string fontName, short fontSize = 16)
    {
        IntPtr hConsoleOutput = GetStdHandle(-11);

        ConsoleFontInfoEx fontInfo = new ConsoleFontInfoEx();
        fontInfo.cbSize = Marshal.SizeOf(fontInfo);
        fontInfo.FaceName = fontName;
        fontInfo.dwFontSize = new Coord { X = 0, Y = fontSize };

        SetCurrentConsoleFontEx(hConsoleOutput, false, ref fontInfo);
    }
}