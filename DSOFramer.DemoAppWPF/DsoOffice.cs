﻿// DsoOffice.cs

namespace DSOFramer.DemoAppWPF
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    // Version 2.2
    public partial class DsoOffice : UserControl
    {
        private readonly AxDSOFramer.AxFramerControl dso =
            new AxDSOFramer.AxFramerControl();

        public DsoOffice()
        {
            InitializeComponent();

            ((System.ComponentModel.ISupportInitialize)(this.dso)).BeginInit();

            this.Controls.Add(this.dso);

            ((System.ComponentModel.ISupportInitialize)(this.dso)).EndInit();

            dso.Dock = DockStyle.Fill;
            dso.Titlebar = false;
            dso.Menubar = false;
            dso.Toolbars = true;
            dso.BackColor = Color.Black;

            dso.set_EnableFileCommand(DSOFramer.dsoFileCommandType.dsoFileSave, false);
            dso.set_EnableFileCommand(DSOFramer.dsoFileCommandType.dsoFileSaveAs, false);
        }

        private string GetFileType(string fileExtension)
        {
            try
            {
                string sOpenType = "";

                switch (fileExtension.ToLower())
                {
                    case "xls":
                    case "xlsx":
                    case "xlsm":
                    case "xlsb":
                    case "csv":
                        sOpenType = "Excel.Sheet";
                        break;
                    case "doc":
                    case "docx":
                    case "docm":
                    case "rtf":
                        sOpenType = "Word.Document";
                        break;
                    case "ppt":
                    case "pptx":
                    case "pptm":
                        sOpenType = "PowerPoint.Show";
                        break;
                    case "vsd":
                    case "vdx":
                        sOpenType = "Visio.Drawing";
                        break;
                    default:
                        sOpenType = "Word.Document";
                        break;
                }

                return sOpenType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OpenDocument(string filepath)
        {
            string sExt = System.IO.Path.GetExtension(filepath).Replace(".", "");

            dso.Open(filepath, false, GetFileType(sExt), "", "");
        }

        public void SaveDocument()
        {
            try
            {
                this.dso.Save(true, true, null, null);
            }
            catch (Exception)
            {
            }
        }
    }
}
