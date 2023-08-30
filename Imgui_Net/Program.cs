using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using static System.Net.WebRequestMethods;
using System.ComponentModel;
using System.Reflection;
using Veldrid;

namespace Imgui_Net
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdWindow);
       const int hide = 0;
        const int show = 1;
        public static void Main(string[] args)
        {
            RenderClass.KeyAuthApp.init();
            IntPtr handle = GetConsoleWindow();

            ShowWindow(handle,hide);
            
            RenderClass ove = new RenderClass();
                ove.Start().Wait();
            
           



        }
        public static void ProgressBarCiz(int sol, int ust, int deger, int isaret, ConsoleColor color)
        {
            char[] symbol = new char[5] { '\u25A0', '\u2592', '\u2588', '\u2551', '\u2502' };
            int maxBarSize = Console.BufferWidth - 1;
            int barSize = deger;
            decimal f = 1;
            if (barSize + sol > maxBarSize)
            {
                barSize = maxBarSize - (sol + 5); // first 5 character "%100 "
                f = (decimal)deger / (decimal)barSize;
            }
            Console.CursorVisible = false;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(sol + 5, ust);
            for (int i = 0; i < barSize + 1; i++)
            {
                System.Threading.Thread.Sleep(10);
                Console.Write(symbol[isaret]);
                Console.SetCursorPosition(sol, ust);
                Console.Write((i * f).ToString("0,0")+ "%");
                Console.SetCursorPosition(sol + 5 + i, ust);
                
            }
            Console.ResetColor();
        }





    }
}
