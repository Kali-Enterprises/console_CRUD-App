using System;
using System.Runtime.InteropServices;

namespace ConsoleCRUDapp.Utilities
{
    public class ConsoleUtility
    {
        #region Global Scope
        /// <summary>
        /// Structure for Font Info
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct CONSOLE_FONT_INFO_EX
        {
            public int cbSize;
            public int nFont;
            public Coord dwFontSize;
            public int FontFamily;
            public int FontWeight;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string FaceName;
        }

        /// <summary>
        /// Co-ordinates of Console point
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct Coord
        {
            public short X;
            public short Y;

            public Coord(short x, short y)
            {
                X = x;
                Y = y;
            }
        }

        /// <summary>
        /// Standard Output Handle
        /// </summary>
        private const int STD_OUTPUT_HANDLE = -11;

        /// <summary>
        /// Font type
        /// </summary>
        private const int TMPF_TRUETYPE = 0x04;
        #endregion

        #region Methods
        /// <summary>
        /// Setting up the current console font
        /// </summary>
        /// <param name="consoleOutput"></param>
        /// <param name="maximumWindow"></param>
        /// <param name="consoleCurrentFontEx"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool SetCurrentConsoleFontEx(IntPtr consoleOutput, bool maximumWindow, ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        /// <summary>
        /// Getting standard output handle
        /// </summary>
        /// <param name="nStdHandle"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        /// <summary>
        /// Setting the custom font as console font
        /// </summary>
        /// <see cref="ConsoleUtility"/>>
        public static void SetConsoleFont()
        {
            try
            {
                string fontName = "JetBrains Mono Medium";
                IntPtr hnd = GetStdHandle(STD_OUTPUT_HANDLE);
                CONSOLE_FONT_INFO_EX cfi = new CONSOLE_FONT_INFO_EX();
                cfi.cbSize = Marshal.SizeOf(cfi);
                cfi.FontFamily = TMPF_TRUETYPE;
                cfi.FaceName = fontName;
                cfi.dwFontSize = new Coord(9, 18); // Adjust the font size if needed
                cfi.FontWeight = 400;

                SetCurrentConsoleFontEx(hnd, false, ref cfi);
            }
            catch (Exception ex)
            {
                throw new Exception($"\nDeveloperConsole.ConsoleUtility.SetConsoleFont()::{ex.Message}");
            }
        }

        /// <summary>
        /// To create Text banner with ASCII Code without foreground color
        /// </summary>
        /// <param name="bannerText"></param>
        /// <returns><![CDATA[Banner in string]]></returns>
        public static void ShowBanner(string bannerText)
        {
            try
            {
                string banner = String.Empty;
                int totalLength = 0;
                int padding = 4;
                int margin = 4;

                if (!String.IsNullOrEmpty(bannerText))
                {
                    // Get Total Length to create banner's upper strip
                    totalLength = bannerText.Length + 2 * padding;

                    string upperPart = $"{new string(' ', margin)}╔{new string('═', totalLength)}╗"; //     ╔═══════════════════╗

                    string middlePart = $"{new string(' ', margin)}║{new string(' ', padding)}{bannerText}{new string(' ', padding)}║{new string(' ', margin)}";    //    ║   {Text}   ║

                    string bottomPart = $"{new string(' ', margin)}╚{new string('═', totalLength)}╝"; //    ╚═══════════════════╝

                    // Final Banner String
                    banner = $"{upperPart}\n{middlePart}\n{bottomPart}\n";
                }
                else
                {
                    throw new Exception($"\nDeveloperConsole.ConsoleUtility.ShowBanner()::[ Banner Text should not be blank or null !!! ]");
                }
                Console.WriteLine(banner);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// To create Text banner with ASCII Code with color
        /// </summary>
        /// <param name="bannerText"></param>
        /// <param name="isApplyColor"></param>
        /// <param name="consoleColor"></param>
        /// <returns><![CDATA[Banner in string]]></returns>
        public static void ShowBanner(string bannerText, bool isApplyColor, ConsoleColor consoleColor)
        {
            try
            {
                string banner = String.Empty;
                int totalLength = 0;
                int padding = 4;
                int margin = 4;

                if (!String.IsNullOrEmpty(bannerText))
                {
                    // Get Total Length to create banner's upper strip
                    totalLength = bannerText.Length + 2 * padding;

                    string upperPart = $"{new string(' ', margin)}╔{new string('═', totalLength)}╗"; //     ╔═══════════════════╗

                    string middlePart = $"{new string(' ', margin)}║{new string(' ', padding)}{bannerText}{new string(' ', padding)}║{new string(' ', margin)}";    //    ║   {Text}   ║

                    string bottomPart = $"{new string(' ', margin)}╚{new string('═', totalLength)}╝"; //    ╚═══════════════════╝

                    // Final Banner String
                    banner = $"{upperPart}\n{middlePart}\n{bottomPart}\n\n";
                }
                else
                {
                    throw new Exception("Banner Text should not be blank or null !!!");
                }
                if (isApplyColor)
                {
                    // If ConsoleColor defined as Optional/Nullable parameter we need to define or convert them into [ConsoleColor] DataType
                    // ex.
                    // (ConsoleColor? clsColor = ConsoleColor.Red)
                    // Console.ForegroundColor = (ConsoleColor)clsColor;
                    Console.ForegroundColor = consoleColor;
                    Console.WriteLine(banner);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(banner);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}