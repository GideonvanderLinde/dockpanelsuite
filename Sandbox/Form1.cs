using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using WeifenLuo.WinFormsUI.Docking;

namespace Sandbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dockPanel.Theme = new VS2015SandwichLightGreenTheme();
            try
            {
                string filePath = "C:\\Users\\dagin\\source\\repos\\Sandwich\\Sandwich\\bin\\Debug\\ThemePink.json";
                //string filePath = "ThemeVS2015\\Resources\\vs2015sandwichlightgreen.json"
                if (File.Exists(filePath))
                {

                    DockPanelColorPalette palette = JsonConvert.DeserializeObject<DockPanelColorPalette>(File.ReadAllText(filePath));
                    if (palette != null)
                        (dockPanel.Theme as VS2015SandwichLightGreenTheme).SetPalette(palette);

                    dockPanel.Theme.ApplyTo(dockPanel);
                }
            }
            catch
            {

            }
            dockPanel.SuspendLayout(true);

            DummyDoc doc1 = CreateNewDocument("Document1");
            DummyDoc doc2 = CreateNewDocument("Document2");
            DummyDoc doc3 = CreateNewDocument("Document3");
            DummyDoc doc4 = CreateNewDocument("Document4");
            doc1.Show(dockPanel, DockState.Document);
            doc2.Show(dockPanel, DockState.DockLeft);
            //doc2.Show(doc1.Pane, null);
            doc3.Show(doc1.Pane, DockAlignment.Bottom, 0.5);
            doc4.Show(doc3.Pane, DockAlignment.Right, 0.5);

            propertyGrid1.SelectedObject = dockPanel.Theme.ColorPalette;
            //dockPanel.DockBackColor
            dockPanel.ResumeLayout(true, true);
        }

        private DummyDoc CreateNewDocument(string text)
        {
            DummyDoc dummyDoc = new DummyDoc();
            dummyDoc.Text = text;
            return dummyDoc;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var theme = new VS2015SandwichLightGreenTheme();
            (dockPanel.Theme as VS2015SandwichLightGreenTheme).SetPalette(theme.ColorPalette);
            propertyGrid1.SelectedObject = dockPanel.Theme.ColorPalette;
            RefreshControls();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            string theme = JsonConvert.SerializeObject(dockPanel.Theme.ColorPalette);
            File.WriteAllText("ThemeVS2015\\Resources\\vs2015sandwichlightgreen.json", theme);
            (dockPanel.Theme as VS2015SandwichLightGreenTheme).SetPalette(dockPanel.Theme.ColorPalette);
            RefreshControls();
        }

        private void RefreshControls()
        {
            dockPanel.Refresh();
        }
    }
}