namespace WeifenLuo.WinFormsUI.Docking
{
    using ThemeVS2015;

    public class VS2015SandwichLightGreenTheme : VS2015ThemeBase
    {
        public VS2015SandwichLightGreenTheme() : base(Decompress(Resources.vs2015sandwichlightgreen_vstheme))
        {
            Measures.SplitterSize = 12;
            Measures.DockPadding = 12;
        }
    }
}
