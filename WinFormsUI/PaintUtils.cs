using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI
{
    [SecuritySafeCritical]
    public static class PaintUtils
    {

        [Flags]
        enum RedrawWindowFlags : uint
        {
            RDW_INVALIDATE = 1,
            RDW_INTERNALPAINT = 2,
            RDW_ERASE = 4,
            RDW_VALIDATE = 8,
            RDW_NOINTERNALPAINT = 0x10,
            RDW_NOERASE = 0x20,
            RDW_NOCHILDREN = 0x40,
            RDW_ALLCHILDREN = 0x80,
            RDW_UPDATENOW = 0x100,
            RDW_ERASENOW = 0x200,
            RDW_FRAME = 0x400,
            RDW_NOFRAME = 0x800
        }

        static class Win32Messages
        {

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int PostMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

            public const int EM_GETLINECOUNT = 0x00BA;
            public const int EM_AUTOURLDETECT = 0x45b;
            public const int EM_CANPASTE = 0x432;
            public const int EM_CANREDO = 0x455;
            public const int EM_CHARFROMPOS = 0x427;
            public const int EM_CONVPOSITION = 0x46c;
            public const int EM_DISPLAYBAND = 0x433;
            public const int EM_EXGETSEL = 0x434;
            public const int EM_EXLIMITTEXT = 0x435;
            public const int EM_EXLINEFROMCHAR = 0x436;
            public const int EM_EXSETSEL = 0x437;
            public const int EM_FINDTEXT = 0x438;
            public const int EM_FINDTEXTEX = 0x44f;
            public const int EM_FINDTEXTEXW = 0x47c;
            public const int EM_FINDTEXTW = 0x47b;
            public const int EM_FINDWORDBREAK = 0x44c;
            public const int EM_FORMATRANGE = 0x439;
            public const int EM_GETAUTOURLDETECT = 0x45c;
            public const int EM_GETBIDIOPTIONS = 0x4c9;
            public const int EM_GETCHARFORMAT = 0x43a;
            public const int EM_GETEDITSTYLE = 0x4cd;
            public const int EM_GETEVENTMASK = 0x43b;
            public const int EM_GETIMECOLOR = 0x469;
            public const int EM_GETIMECOMPMODE = 0x47a;
            public const int EM_GETIMEMODEBIAS = 0x47f;
            public const int EM_GETIMEOPTIONS = 0x46b;
            public const int EM_GETLANGOPTIONS = 0x479;
            public const int EM_GETLIMITTEXT = 0x425;
            public const int EM_GETOLEINTERFACE = 0x43c;
            public const int EM_GETOPTIONS = 0x44e;
            public const int EM_GETPARAFORMAT = 0x43d;
            public const int EM_GETPUNCTUATION = 0x465;
            public const int EM_GETREDONAME = 0x457;
            public const int EM_GETSELTEXT = 0x43e;
            public const int EM_GETTEXTEX = 0x45e;
            public const int EM_GETTEXTLENGTHEX = 0x45f;
            public const int EM_GETTEXTMODE = 0x45a;
            public const int EM_GETTEXTRANGE = 0x44b;
            public const int EM_GETTYPOGRAPHYOPTIONS = 0x4cb;
            public const int EM_GETUNDONAME = 0x456;
            public const int EM_GETWORDBREAKPROCEX = 0x450;
            public const int EM_GETWORDWRAPMODE = 0x467;
            public const int EM_HIDESELECTION = 0x43f;
            public const int EM_PASTESPECIAL = 0x440;
            public const int EM_POSFROMCHAR = 0x426;
            public const int EM_RECONVERSION = 0x47d;
            public const int EM_REDO = 0x454;
            public const int EM_REQUESTRESIZE = 0x441;
            public const int EM_SCROLLCARET = 0x431;
            public const int EM_SELECTIONTYPE = 0x442;
            public const int EM_SETBIDIOPTIONS = 0x4c8;
            public const int EM_SETBKGNDCOLOR = 0x443;
            public const int EM_SETCHARFORMAT = 0x444;
            public const int EM_SETEDITSTYLE = 0x4cc;
            public const int EM_SETEVENTMASK = 0x445;
            public const int EM_SETIMECOLOR = 0x468;
            public const int EM_SETIMEMODEBIAS = 0x47e;
            public const int EM_SETIMEOPTIONS = 0x46a;
            public const int EM_SETLANGOPTIONS = 0x478;
            public const int EM_SETOLECALLBACK = 0x446;
            public const int EM_SETOPTIONS = 0x44d;
            public const int EM_SETPALETTE = 0x45d;
            public const int EM_SETPARAFORMAT = 0x447;
            public const int EM_SETPUNCTUATION = 0x464;
            public const int EM_SETTARGETDEVICE = 0x448;
            public const int EM_SETTEXTMODE = 0x459;
            public const int EM_SETTYPOGRAPHYOPTIONS = 0x4ca;
            public const int EM_SETUNDOLIMIT = 0x452;
            public const int EM_SETWORDBREAKPROCEX = 0x451;
            public const int EM_SETWORDWRAPMODE = 0x466;
            public const int EM_STOPGROUPTYPING = 0x458;
            public const int EM_STREAMIN = 0x449;
            public const int EM_STREAMOUT = 0x44a;
            public const int WM_ACTIVATE = 6;
            public const int WM_ACTIVATEAPP = 0x1c;
            public const int WM_AFXFIRST = 0x360;
            public const int WM_AFXLAST = 0x37f;
            public const int WM_APP = 0x8000;
            public const int WM_ASKCBFORMATNAME = 780;
            public const int WM_CANCELJOURNAL = 0x4b;
            public const int WM_CANCELMODE = 0x1f;
            public const int WM_CAPTURECHANGED = 0x215;
            public const int WM_CHANGECBCHAIN = 0x30d;
            public const int WM_CHAR = 0x102;
            public const int WM_CHARTOITEM = 0x2f;
            public const int WM_CHILDACTIVATE = 0x22;
            public const int WM_CLEAR = 0x303;
            public const int WM_CLOSE = 0x10;
            public const int WM_COMMAND = 0x111;
            public const int WM_COMMNOTIFY = 0x44;
            public const int WM_COMPACTING = 0x41;
            public const int WM_COMPAREITEM = 0x39;
            public const int WM_CONTEXTMENU = 0x7b;
            public const int WM_COPY = 0x301;
            public const int WM_COPYDATA = 0x4a;
            public const int WM_CREATE = 1;
            public const int WM_CTLCOLOR = 0x19;
            public const int WM_CTLCOLORBTN = 0x135;
            public const int WM_CTLCOLORDLG = 310;
            public const int WM_CTLCOLOREDIT = 0x133;
            public const int WM_CTLCOLORLISTBOX = 0x134;
            public const int WM_CTLCOLORMSGBOX = 0x132;
            public const int WM_CTLCOLORSCROLLBAR = 0x137;
            public const int WM_CTLCOLORSTATIC = 0x138;
            public const int WM_CUT = 0x300;
            public const int WM_DEADCHAR = 0x103;
            public const int WM_DELETEITEM = 0x2d;
            public const int WM_DESTROY = 2;
            public const int WM_DESTROYCLIPBOARD = 0x307;
            public const int WM_DEVICECHANGE = 0x219;
            public const int WM_DEVMODECHANGE = 0x1b;
            public const int WM_DISPLAYCHANGE = 0x7e;
            public const int WM_DRAWCLIPBOARD = 0x308;
            public const int WM_DRAWITEM = 0x2b;
            public const int WM_DROPFILES = 0x233;
            public const int WM_ENABLE = 10;
            public const int WM_ENDSESSION = 0x16;
            public const int WM_ENTERIDLE = 0x121;
            public const int WM_ENTERMENULOOP = 0x211;
            public const int WM_ENTERSIZEMOVE = 0x231;
            public const int WM_ERASEBKGND = 20;
            public const int WM_EXITMENULOOP = 530;
            public const int WM_EXITSIZEMOVE = 0x232;
            public const int WM_FONTCHANGE = 0x1d;
            public const int WM_GETDLGCODE = 0x87;
            public const int WM_GETFONT = 0x31;
            public const int WM_GETHOTKEY = 0x33;
            public const int WM_GETICON = 0x7f;
            public const int WM_GETMINMAXINFO = 0x24;
            public const int WM_GETOBJECT = 0x3d;
            public const int WM_GETTEXT = 13;
            public const int WM_GETTEXTLENGTH = 14;
            public const int WM_HANDHELDFIRST = 0x358;
            public const int WM_HANDHELDLAST = 0x35f;
            public const int WM_HELP = 0x53;
            public const int WM_HOTKEY = 0x312;
            public const int WM_HSCROLL = 0x114;
            public const int WM_HSCROLLCLIPBOARD = 0x30e;
            public const int WM_ICONERASEBKGND = 0x27;
            public const int WM_IME_CHAR = 0x286;
            public const int WM_IME_COMPOSITION = 0x10f;
            public const int WM_IME_COMPOSITIONFULL = 0x284;
            public const int WM_IME_CONTROL = 0x283;
            public const int WM_IME_ENDCOMPOSITION = 270;
            public const int WM_IME_KEYDOWN = 0x290;
            public const int WM_IME_KEYUP = 0x291;
            public const int WM_IME_NOTIFY = 0x282;
            public const int WM_IME_SELECT = 0x285;
            public const int WM_IME_SETCONTEXT = 0x281;
            public const int WM_IME_STARTCOMPOSITION = 0x10d;
            public const int WM_INITDIALOG = 0x110;
            public const int WM_INITMENU = 0x116;
            public const int WM_INITMENUPOPUP = 0x117;
            public const int WM_INPUTLANGCHANGE = 0x51;
            public const int WM_INPUTLANGCHANGEREQUEST = 80;
            public const int WM_KEYDOWN = 0x100;
            public const int WM_KEYLAST = 0x108;
            public const int WM_KEYUP = 0x101;
            public const int WM_KILLFOCUS = 8;
            public const int WM_LBUTTONDBLCLK = 0x203;
            public const int WM_LBUTTONDOWN = 0x201;
            public const int WM_LBUTTONUP = 0x202;
            public const int WM_MBUTTONDBLCLK = 0x209;
            public const int WM_MBUTTONDOWN = 0x207;
            public const int WM_MBUTTONUP = 520;
            public const int WM_MDIACTIVATE = 0x222;
            public const int WM_MDICASCADE = 0x227;
            public const int WM_MDICREATE = 0x220;
            public const int WM_MDIDESTROY = 0x221;
            public const int WM_MDIGETACTIVE = 0x229;
            public const int WM_MDIICONARRANGE = 0x228;
            public const int WM_MDIMAXIMIZE = 0x225;
            public const int WM_MDINEXT = 0x224;
            public const int WM_MDIREFRESHMENU = 0x234;
            public const int WM_MDIRESTORE = 0x223;
            public const int WM_MDISETMENU = 560;
            public const int WM_MDITILE = 550;
            public const int WM_MEASUREITEM = 0x2c;
            public const int WM_MENUCHAR = 0x120;
            public const int WM_MENUSELECT = 0x11f;
            public const int WM_MOUSEACTIVATE = 0x21;
            public const int WM_MOUSEHOVER = 0x2a1;
            public const int WM_MOUSELEAVE = 0x2a3;
            public const int WM_MOUSEMOVE = 0x200;
            public const int WM_MOUSEWHEEL = 0x20a;
            public const int WM_MOVE = 3;
            public const int WM_MOVING = 0x216;
            public const int WM_NCACTIVATE = 0x86;
            public const int WM_NCCALCSIZE = 0x83;
            public const int WM_NCCREATE = 0x81;
            public const int WM_NCDESTROY = 130;
            public const int WM_NCHITTEST = 0x84;
            public const int WM_NCLBUTTONDBLCLK = 0xa3;
            public const int WM_NCLBUTTONDOWN = 0xa1;
            public const int WM_NCLBUTTONUP = 0xa2;
            public const int WM_NCMBUTTONDBLCLK = 0xa9;
            public const int WM_NCMBUTTONDOWN = 0xa7;
            public const int WM_NCMBUTTONUP = 0xa8;
            public const int WM_NCMOUSEMOVE = 160;
            public const int WM_NCPAINT = 0x85;
            public const int WM_NCRBUTTONDBLCLK = 0xa6;
            public const int WM_NCRBUTTONDOWN = 0xa4;
            public const int WM_NCRBUTTONUP = 0xa5;
            public const int WM_NEXTDLGCTL = 40;
            public const int WM_NEXTMENU = 0x213;
            public const int WM_NOTIFY = 0x4e;
            public const int WM_NOTIFYFORMAT = 0x55;
            public const int WM_NULL = 0;
            public const int WM_PAINT = 15;
            public const int WM_PAINTCLIPBOARD = 0x309;
            public const int WM_PAINTICON = 0x26;
            public const int WM_PALETTECHANGED = 0x311;
            public const int WM_PALETTEISCHANGING = 0x310;
            public const int WM_PARENTNOTIFY = 0x210;
            public const int WM_PASTE = 770;
            public const int WM_PENWINFIRST = 0x380;
            public const int WM_PENWINLAST = 0x38f;
            public const int WM_POWER = 0x48;
            public const int WM_POWERBROADCAST = 0x218;
            public const int WM_PRINT = 0x317;
            public const int WM_PRINTCLIENT = 0x318;
            public const int WM_QUERYDRAGICON = 0x37;
            public const int WM_QUERYENDSESSION = 0x11;
            public const int WM_QUERYNEWPALETTE = 0x30f;
            public const int WM_QUERYOPEN = 0x13;
            public const int WM_QUEUESYNC = 0x23;
            public const int WM_QUIT = 0x12;
            public const int WM_RBUTTONDBLCLK = 0x206;
            public const int WM_RBUTTONDOWN = 0x204;
            public const int WM_RBUTTONUP = 0x205;
            public const int WM_RENDERALLFORMATS = 0x306;
            public const int WM_RENDERFORMAT = 0x305;
            public const int WM_SETCURSOR = 0x20;
            public const int WM_SETFOCUS = 7;
            public const int WM_SETFONT = 0x30;
            public const int WM_SETHOTKEY = 50;
            public const int WM_SETICON = 0x80;
            public const int WM_SETREDRAW = 11;
            public const int WM_SETTEXT = 12;
            public const int WM_SHOWWINDOW = 0x18;
            public const int WM_SIZE = 5;
            public const int WM_SIZECLIPBOARD = 0x30b;
            public const int WM_SIZING = 0x214;
            public const int WM_SPOOLERSTATUS = 0x2a;
            public const int WM_STYLECHANGED = 0x7d;
            public const int WM_STYLECHANGING = 0x7c;
            public const int WM_SYSCHAR = 0x106;
            public const int WM_SYSCOLORCHANGE = 0x15;
            public const int WM_SYSCOMMAND = 0x112;
            public const int WM_SYSDEADCHAR = 0x107;
            public const int WM_SYSKEYDOWN = 260;
            public const int WM_SYSKEYUP = 0x105;
            public const int WM_TCARD = 0x52;
            public const int WM_TIMECHANGE = 30;
            public const int WM_TIMER = 0x113;
            public const int WM_UNDO = 0x304;
            public const int WM_USER = 0x400;
            public const int WM_USERCHANGED = 0x54;
            public const int WM_VKEYTOITEM = 0x2e;
            public const int WM_VSCROLL = 0x115;
            public const int WM_VSCROLLCLIPBOARD = 0x30a;
            public const int WM_WINDOWPOSCHANGED = 0x47;
            public const int WM_WINDOWPOSCHANGING = 70;
            public const int WM_WININICHANGE = 0x1a;
        }

        [DllImport("user32.dll")]
        static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

        public static void SetRedrawOff(Control control)
        {
            if ((control.IsHandleCreated) && (control.Visible))
                Win32Messages.SendMessage(control.Handle, Win32Messages.WM_SETREDRAW, 0, 0);
        }
        public static void SetRedrawOn(Control control)
        {
            if ((control.IsHandleCreated) && (control.Visible))
            {
                Win32Messages.SendMessage(control.Handle, Win32Messages.WM_SETREDRAW, 1, 0);
                RedrawWindow(control.Handle, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.RDW_INVALIDATE | RedrawWindowFlags.RDW_ALLCHILDREN | RedrawWindowFlags.RDW_ERASE | RedrawWindowFlags.RDW_FRAME);
            }
        }
        public static void ForceRedraw(Control control)
        {
            if ((control.IsHandleCreated) && (control.Visible))
                RedrawWindow(control.Handle, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.RDW_INVALIDATE | RedrawWindowFlags.RDW_ALLCHILDREN | RedrawWindowFlags.RDW_UPDATENOW | RedrawWindowFlags.RDW_ERASENOW | RedrawWindowFlags.RDW_FRAME | RedrawWindowFlags.RDW_ERASE);
        }

    }
}