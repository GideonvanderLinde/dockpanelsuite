namespace WeifenLuo.WinFormsUI.Docking
{
    using System.Windows.Forms;
    using ThemeVS2015;

    public class VS2015SandwichLightGreenTheme : VS2015ThemeBase
    {
        public VS2015SandwichLightGreenTheme() : base(Decompress(Resources.vs2015sandwichlightgreen_vstheme))
        {
            Measures.SplitterSize = 12;
            Measures.DockPadding = 12;
        }

        public new ToolStripRenderer ToolStripRenderer 
        { 
            get
            {
                return base.ToolStripRenderer;
            }
            set
            {
                base.ToolStripRenderer = value;
            }
        }
    }
}
