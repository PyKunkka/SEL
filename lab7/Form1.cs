using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Args;
using NLog;


namespace lab1
{
    public partial class Form1 : Form
    {
        Control newControl;
        protected static NLog.Logger log { get; private set; }
        enum MyControls { label, textBox, pictureBox, button };
        static ArgFlg helpF = new ArgFlg(false, "?", "help", "to see this help", "to see this help");
        static ArgStr controlF = new ArgStr(null, "c", "control",
            "Type of control which you want to see.", "ControlType");
        static ArgStr logF = new ArgStr(null, "l", "log", @"to see log information; Log levels:
                                                                                                    Debug
                                                                                                    Info
                                                                                                    Warn
                                                                                                    Error
                                                                                                    Fatal", "LogLevel");
        static ArgStr fileF = new ArgStr(null, "f", "file", "path to the file which you want to show in PictureBox", "path");
        static ArgStr textF = new ArgStr(null, "t", "text", "string which you want to see on controller", "string");
        static ArgInt angleF = new ArgInt(0, "a", "angle", "angle(deg) of text in PictureBox", "angle");
        static ArgIntMM xF = new ArgIntMM(0, "x", "x", "x coordinate of controller", "xx");
        static ArgIntMM yF = new ArgIntMM(0, "y", "y", "y coordinate of controller", "yy");
        static ArgStr ellipse = new ArgStr(null, "e", "ellipse", "coordinates of ellipse on picturebox and it's width and height", "\"xx yy ww hh\"");
        bool debug = false;
        bool info = false;
        bool warn = false;
        bool error = false;
        bool fatal = false;
        bool contr = false;
        bool firstlog = true;
        bool first2log = true;
        bool event1 = true;
        bool event2 = true;
        bool event3 = true;
        bool event4 = true;

        public Form1(string[] args)
        {
            


            try
            {
                log = LogManager.GetLogger(GetType().FullName);
                for (int i = 0; i < args.Length; i++)
                    if (logF.check(ref i, args))
                    {
                        switch (logF.val().ToLower())
                        {
                            case "debug":
                                {
                                    log.Info("Logger has started with Debug log level");
                                    debug = true;
                                    info = true;
                                    warn = true;
                                    error = true;
                                    fatal = true;
                                }
                                break;
                            case "info":
                                {
                                    log.Info("Logger has started with Info log level");
                                    info = true;
                                    warn = true;
                                    error = true;
                                    fatal = true;
                                }
                                break;
                            case "warn":
                                {
                                    warn = true;
                                    error = true;
                                    fatal = true;
                                }
                                break;
                            case "error":
                                {
                                    error = true;
                                    fatal = true;
                                }
                                break;
                            case "fatal":
                                {
                                    fatal = true;
                                }
                                break;
                            default:
                                break;

                        }

                    }

                if (debug)
                {
                    log.Debug("Version: {0}", Environment.Version.ToString());
                    log.Debug("OS: {0}", Environment.OSVersion.ToString());
                    log.Debug("Comand Line: {0}", Environment.CommandLine.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            xF.setMin(0); xF.setMax(1000);
            yF.setMin(0); yF.setMax(1000);

            for (int i = 0; i < args.Length; i++)
                if (controlF.check(ref i, args))
                    contr = true;

            InitializeComponent(args);
        }


        private static void usage()
        {
            Args.Arg.mkVHelp("lab1 - create controls on form.", "0.1",false,
                helpF,
                controlF,
                logF,
                fileF,
                textF,
                angleF,
                xF,
                yF,
                ellipse
                );
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
