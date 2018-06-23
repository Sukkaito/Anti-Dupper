using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        #region Var
        private NotifyIcon ntficon = new NotifyIcon();
        private bool on = false;
        #endregion
        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
            ntficon.Icon = this.Icon;
            ntficon.Visible = true;
            ntficon.MouseDoubleClick += new MouseEventHandler(ntficon_MouseDoubleClick);
            ntficon.BalloonTipClicked += new EventHandler(ntficon_BalloonTipClicked);
            ntficon.MouseClick += new MouseEventHandler(ntficon_MouseClick);
        }

        private void CheckProgramState()
        {
            if (on == true)
            {
                MouseHook.Start();
                panel1.Visible = true;
            }
            else if (on == false)
            {
                MouseHook.Stop();
                panel1.Visible = false;
            }
        }

        #region Other_Event
        void ntficon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                MenuItem exit = new MenuItem();
                MenuItem show = new MenuItem();
                MenuItem turnon = new MenuItem();
                MenuItem turnoff = new MenuItem();
                MenuItem hide = new MenuItem();
                hide.Text = "Hide";
                exit.Text = "Exit";
                show.Text = "Show";
                turnon.Text = "Turn On";
                turnoff.Text = "Turn Off";
                cm.MenuItems.Add(exit);
                cm.MenuItems.Add(show);
                if (on == false)
                {
                    cm.MenuItems.Add(turnon);
                    cm.MenuItems.Remove(turnoff);
                }
                else if (on == true)
                {
                    cm.MenuItems.Add(turnoff);
                    cm.MenuItems.Remove(turnon);
                }
                if (this.WindowState == FormWindowState.Minimized)
                {
                    cm.MenuItems.Add(show);
                    cm.MenuItems.Remove(hide);
                }
                else if (this.WindowState == FormWindowState.Normal)
                {
                    cm.MenuItems.Add(hide);
                    cm.MenuItems.Remove(show);
                }
                ntficon.ContextMenu = cm;
                exit.Click += new EventHandler(exit_Click);
                show.Click += new EventHandler(show_Click);
                hide.Click += new EventHandler(hide_Click);
                turnon.Click += new EventHandler(turnon_Click);
                turnoff.Click +=new EventHandler(turnoff_Click);
            }
        }


        void show_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            ntficon_MouseClick(null, new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0));
        }

        void hide_Click(object sener, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            ntficon_MouseClick(null, new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0));
        }

        void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        void turnon_Click(object sender, EventArgs e)
        {
            on = true;
            CheckProgramState();
            ntficon_MouseClick(null, new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0));
        }

        void turnoff_Click(object sender, EventArgs e)
        {
            on = false;
            CheckProgramState();
            ntficon_MouseClick(null, new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0));
        }
        void ntficon_BalloonTipClicked(object sender, EventArgs e)
        {
            ntficon.Visible = true;
        }

        private void ntficon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            if (on == false) { panel1.Visible = false; } else if (on == true) { panel1.Visible = true; }
            this.ShowInTaskbar = true;
            ntficon_MouseClick(null, new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0));
        }

        private void flatMaterialButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            on = true;
            CheckProgramState();
        }

        private void flatMaterialButton2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            on = false;
            CheckProgramState();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) //Avoid infinite loop
            {
                ntficon.Visible = true;
                this.ShowInTaskbar = false;
                ntficon.ShowBalloonTip(5000, "Anti-Dupper", "Double-Click on the Icon to show", ToolTipIcon.Info);
                ntficon_MouseClick(null, new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0));
            }
        }

        private void Form1_FormClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            ntficon.Visible = true;
            this.ShowInTaskbar = false;
            ntficon.ShowBalloonTip(5000, "Anti-Dupper", "Double-Click on the Icon to show", ToolTipIcon.Info);
            ntficon_MouseClick(null, new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0));
        }
        #endregion

        //BlockInput
        [DllImport("user32.dll", EntryPoint = "BlockInput", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool BlockInput([MarshalAsAttribute(UnmanagedType.Bool)] bool fBlockIt);
    }

    //Global Mouse Click Event
    public static class MouseHook
    {
        public static event EventHandler MouseAction = delegate { };

        public static void Start()
        {
            _hookID = SetHook(_proc);
        }
        public static void Stop()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static bool FirstClick = true;
        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                IntPtr hook = SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle("user32"), 0);
                if (hook == IntPtr.Zero) throw new Win32Exception();
                return hook;
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam && (FirstClick == true))
            {
                Form1.BlockInput(true);
                System.Threading.Thread.Sleep(50);
                Form1.BlockInput(false);
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private const int WH_MOUSE_LL = 14;
        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
          LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
          IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
