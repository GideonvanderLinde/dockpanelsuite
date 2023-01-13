using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

namespace Sandbox
{
    public partial class DummyDoc : DockContent
    {
        public DummyDoc()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            DockAreas = DockAreas.Document | DockAreas.Float | DockAreas.DockLeft;

            Random r = new Random();

            foreach (var ctr in panel1.Controls)
                ((Control)ctr).Width = r.Next(70, 100);

            foreach (var ctr in panel2.Controls)
                ((Control)ctr).Height = r.Next(30, 50);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged (e);
            //if (FileName == string.Empty)
            //    this.richTextBox1.Text = Text;
        }
    }
}