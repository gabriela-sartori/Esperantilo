using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // ... { GLOBAL HOOK }
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        const int WH_KEYBOARD_LL = 13; // Keyboard hook id

        // Some key ids
        const int WM_ACTIVATE    = 0x006;
        const int WM_SETFOCUS    = 0x007;
        const int WM_KILLFOCUS   = 0x008;
        const int WM_KEYUP       = 0x101;
        const int WM_KEYDOWN     = 0x100;
        const int WM_CHAR        = 0x102;
        const int WM_DEADCHAR    = 0x103;
        const int WM_SYSKEYDOWN  = 0x104;
        const int WM_SYSKEYUP    = 0x105;
        const int WM_SYSDEADCHAR = 0x107;
        const int WM_UNICHAR     = 0x109;
        const int WM_HOTKEY      = 0x312;
        const int WM_APPCOMMAND  = 0x319;

        const int VK_SHIFT     = 0x10;
        const int VK_CONTROL   = 0x11;
        const int VK_BACKSPACE = 0x08;

        private LowLevelKeyboardProc _proc = hookProc;

        private static IntPtr hhook = IntPtr.Zero;

        static Dictionary<char, char> special_keys = new Dictionary<char, char> { { 'c', 'ĉ' }, { 'C', 'Ĉ' }, { 'g', 'ĝ' }, { 'G', 'Ĝ' }, { 'h', 'ĥ' }, { 'H', 'Ĥ' }, { 'j', 'ĵ' }, { 'J', 'Ĵ' }, { 's', 'ŝ' }, { 'S', 'Ŝ' }, { 'u', 'ŭ' }, { 'U', 'Ŭ' } };
        static char lastChar = 'a';
        static bool insertBefore  = true;

        public NotifyIcon  trayIcon;
        public ContextMenu trayMenu;

        public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (wParam != (IntPtr) WM_KEYDOWN)
                return CallNextHookEx(hhook, code, (int) wParam, lParam);

            char vkCode = (char) Marshal.ReadInt32(lParam);            
            
            // if not on [a-z,A-Z] char range then return
            if ((vkCode < 65 || vkCode > 90) && (vkCode < 97 || vkCode > 122)) {
                if (vkCode == VK_BACKSPACE) {
                    lastChar = '_';
                }
                return (IntPtr) 0;
            }

            // Upper case if caps xor shift is pressed (if both are pressed, then it is not upper case, right?)
            if (Control.IsKeyLocked(Keys.CapsLock) ^ ((ModifierKeys & Keys.Shift) == Keys.Shift))
                vkCode = Char.ToUpper(vkCode);
            else
                vkCode = Char.ToLower(vkCode);

            if (insertBefore) {
                if (char.ToLower(lastChar) == 'x') {
                    if (special_keys.ContainsKey(vkCode)) {
                        SendKeys.Send(special_keys[vkCode].ToString());
                        lastChar = '_';
                        return (IntPtr) 1;
                    }
                } else if (char.ToLower(vkCode) == 'x') {
                    lastChar = vkCode;
                    return (IntPtr) 1;
                }
            } else {
                if (char.ToLower(vkCode) == 'x') {
                    char value;
                    if (special_keys.TryGetValue(lastChar, out value)) {
                        SendKeys.Send("{backspace}" + value.ToString());
                        return (IntPtr) 1;
                    }
                }
            }
            lastChar = vkCode;
            return (IntPtr) 0;
        }

        public void SetHook(Boolean enable)
        {
            if (enable) {
                IntPtr hInstance = LoadLibrary("User32");
                hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
            } else {
                UnhookWindowsHookEx(hhook);
            }
        }        

        private void cbtAtivar_CheckedChanged(object sender, EventArgs e)
        {
            SetHook(cbtAtivar.Checked);
        }

        private void rbBefore_CheckedChanged(object sender, EventArgs e)
        {
            insertBefore = true;
        }

        private void rbAfter_CheckedChanged(object sender, EventArgs e)
        {
            insertBefore = false;
        }       
    }
}
