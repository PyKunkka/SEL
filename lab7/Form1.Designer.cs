using System;
using System.IO;
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
using System.Diagnostics;

namespace lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (helpF.check(ref i, args))
                    usage();
                if (contr)
                {
                    try
                    {
                        MyControls controlType = (MyControls)Enum.Parse(typeof(MyControls), controlF);
                        if (controlType == MyControls.button || controlType == MyControls.label ||
                            controlType == MyControls.textBox)
                        {
                            if (controlType == MyControls.button)
                            {
                                var currcont = new Button();
                                newControl = currcont;
                            }
                            else
                                if (controlType == MyControls.label)
                            {
                                var currcont = new Label();
                                newControl = currcont;
                            }
                            else
                                if (controlType == MyControls.textBox)
                            {
                                var currcont = new TextBox();
                                newControl = currcont;
                            }

                            for (int j = 0; j < args.Length; j++)
                            {
                                if (textF.check(ref j, args))
                                {
                                    newControl.Text = textF;
                                }
                                if (xF.check(ref j, args))
                                    ;
                                if (yF.check(ref j, args))
                                    ;
                                newControl.Location = new Point(xF, yF);

                            }
                            if (info && firstlog)
                            {
                                log.Info("Current controller type: {0}", newControl.GetType().Name);
                                log.Info("Text of your {0} is {1}", newControl.GetType().Name, textF.val());
                                log.Info("Location of your {0} is ({1};{2})", newControl.GetType().Name, xF.val(), yF.val());
                                firstlog = false;
                            }
                        }
                        else
                        {
                            var currcont = new PictureBox();
                            for (int j = 0; j < args.Length; j++)
                            {
                                if (textF.check(ref j, args) && event3)
                                {

                                    currcont.Paint += PictureBox_String_Paint;
                                    event3 = false;
                                    if (debug && first2log)
                                        log.Debug("Paint event hendler event for {0} to draw string\"{1}\" on it was adeed", currcont.GetType().Name, textF.val());
                                }

                                if (ellipse.check(ref j, args)&& event4)
                                {
                                    currcont.Paint += PictureBox_Ellipse_Paint;
                                    if (debug && first2log)
                                        log.Debug("Paint event hendler event for {0} to draw ellipse on it was adeed", currcont.GetType().Name);
                                    event4 = false;
                                }

                                if (xF.check(ref j, args))
                                    ;
                                if (yF.check(ref j, args))
                                    ;
                                if (angleF.check(ref j, args))
                                    ;
                                if (fileF.check(ref j, args))
                                {
                                    try
                                    {
                                        Bitmap btmp = new Bitmap(Path.Combine(Application.StartupPath, fileF));
                                        currcont.Width = btmp.Width;
                                        currcont.Height = btmp.Height;
                                        currcont.Image = btmp;
                                    }
                                    catch (FileNotFoundException ex)
                                    {
                                        if (error && first2log)
                                            log.Error("File at directory {0} wasn't found", Path.Combine(Application.StartupPath, fileF.val()));

                                    }
                                }
                                first2log = false;
                            }
                            
                            newControl = currcont;
                            if (info && firstlog)
                                log.Info("Current controller type: {0}", controlType.ToString());
                            newControl.Location = new Point(xF, yF);
                            if (info && firstlog)
                            {
                                log.Info("Location of your {0} is ({1};{2})", newControl.GetType().Name, xF.val(), yF.val());
                                firstlog = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Fatal(ex.Message);
                        Environment.Exit(0);
                    }

                }
                else
                {
                    if (xF.check(ref i, args))
                        ;
                    if (yF.check(ref i, args))
                        ;
                    if (angleF.check(ref i, args))
                        ;
                    if (textF.check(ref i, args) && event1)
                    {
                        this.Paint += Form_String_Paint;
                        event1 = false;
                    }
                    if (ellipse.check(ref i, args) && event2)
                    {
                        this.Paint += Form_Elipse_Paint;
                        event2 = false;
                    }
                }
            }
            this.Text = "lab1";
            if (newControl != null)
            {
                this.Controls.Add(newControl);
                if (debug)
                    log.Debug("Controller {0} was added to form", newControl.GetType().Name);
            }
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            if (debug)
                log.Debug("Client size set to {0} x {1}", ClientSize.Width, ClientSize.Height);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.FormClosed += Form1_FormClosed; ;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(info)
            {
                log.Info("The application has exited with code {0}", Environment.ExitCode);
                log.Info("Logger finished");
            }
        }

        private void Form_String_Paint(object sender, PaintEventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            Font myFont = new Font("Tahoma", 16);
            SizeF size = e.Graphics.MeasureString(textF, myFont);
            if (info)
                log.Info("Size of string \"{0}\" on from is {1} x {2}", textF.val(), size.Width, size.Height);
            PointF drawPoint = new PointF(-size.Width/2, -size.Height/2);
            e.Graphics.TranslateTransform(size.Width / 2 + xF, size.Height / 2 + yF);
            if (debug)
                log.Debug("Translate transformation has been made at {0}, {1}", size.Width / 2, size.Height / 2);
            e.Graphics.RotateTransform(angleF);
            if (debug)
                log.Debug("Rotation has been made at an angle of {0} degrees", angleF.val());
            if (info)
                log.Info("Angle of string \"{0}\" on form is {1}", textF.val(), angleF.val());
            e.Graphics.DrawString(textF, myFont, Brushes.Black, drawPoint);
            if (info)
                log.Info("String has been drawn at ({0};{1})", xF.val(), yF.val());
            e.Graphics.ResetTransform();
            watch.Stop();
            if (debug)
            {
                log.Debug("Transformation was reseted");
                log.Debug("The string {0} was drawn in {1} ms", textF.val(), watch.ElapsedMilliseconds);
            }
        }

        private void Form_Elipse_Paint(object sender, PaintEventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string[] strs = ellipse.val().Split(' ');
            if (debug)
                log.Debug("String with parameters user entered: {0}", ellipse.val());
            int[] elparams = new int[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                try
                {
                    elparams[i] = int.Parse(strs[i]);
                }
                catch (Exception ex)
                {
                    if (error)
                        log.Fatal("Wrong format of ellipse parameters");
                    if (info)
                    {
                        log.Info("The application has exited");
                        log.Info("Logger finished its work");
                    }
                    Environment.Exit(0);
                }
            }

            try
            {

                e.Graphics.DrawEllipse(Pens.DarkCyan, elparams[0], elparams[1], elparams[2], elparams[3]);
                if (info)
                    log.Info("Ellipse was built");
            }
            catch (Exception ex)
            {
                if (debug)
                    log.Debug(ex.ToString());
                if (fatal)
                    log.Fatal("Not enough parameters of the ellipse");
                if (info)
                {
                    log.Info("The application has exited");
                    log.Info("Logger finished its work");
                }
                Environment.Exit(0);
            }
            watch.Stop();
            if (debug)
                log.Debug("The ellipse was drawn in {0} ms", watch.ElapsedMilliseconds);

        }

        private void PictureBox_Ellipse_Paint(object sender, PaintEventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string[] strs = ellipse.val().Split(' ');
            if (debug)
                log.Debug("String with parameters user entered: {0}", ellipse.val());
            int[] elparams = new int[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                try
                {
                    elparams[i] = int.Parse(strs[i]);
                }
                catch (Exception ex)
                {
                    if (error)
                        log.Fatal("Wrong format of ellipse parameters");
                    if (info)
                    {
                        log.Info("The application has exited");
                        log.Info("Logger finished its work");
                    }
                    Environment.Exit(0);
                }
            }

            try
            {
                newControl.Width = elparams[0] + elparams[2] + 1;
                newControl.Height = elparams[1] + elparams[3] + 1;

                e.Graphics.DrawEllipse(Pens.DarkCyan, elparams[0], elparams[1], elparams[2], elparams[3]);
                if (info)
                    log.Info("Ellipse was built");
            }
            catch (Exception ex)
            {
                if (debug)
                    log.Debug(ex.ToString());
                if (fatal)
                    log.Fatal("Not enough parameters of the ellipse");
                if (info)
                {
                    log.Info("The application has exited");
                    log.Info("Logger finished its work");
                }
                Environment.Exit(0);
            }
            watch.Stop();
            if (debug)
                log.Debug("The ellipse was drawn in {0} ms", watch.ElapsedMilliseconds);
        }

        private void PictureBox_String_Paint(object sender, PaintEventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            Font myFont = new Font("Tahoma", 16);
            SizeF size = e.Graphics.MeasureString(textF, myFont);
            if (info)
                log.Info("Size of string \"{0}\" on from is {1} x {2}", textF.val(), size.Width, size.Height);
            PointF drawPoint = new PointF(-size.Width / 2, -size.Height / 2);
            newControl.Width = (int)Math.Max(size.Width, size.Height) + 2;
            newControl.Height = (int)Math.Max(size.Width, size.Height) + 2;
            e.Graphics.TranslateTransform(size.Width / 2, size.Height / 2);
            if (debug)
                log.Debug("Translate transformation has been made at {0}, {1}", size.Width / 2, size.Height / 2);
            e.Graphics.RotateTransform(angleF);
            if (debug)
                log.Debug("Rotation has been made at an angle of {0} degrees", angleF.val());
            if (info)
                log.Info("Angle of string \"{0}\" on {1} is {2}", textF.val(), newControl.GetType().Name, angleF.val());
            e.Graphics.DrawString(textF, myFont, Brushes.Black, drawPoint);
            if (info)
                log.Info("String has been drawn at {0}", newControl.GetType().Name);
            e.Graphics.ResetTransform();
            watch.Stop();
            if (debug)
            {
                log.Debug("Transformation was reseted");
                log.Debug("The string {0} was drawn in {1} ms", textF.val(), watch.ElapsedMilliseconds);
            }
        }
    }

    #endregion

}


