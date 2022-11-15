using System;
using System.ComponentModel;
using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    public class DockPanelColorPalette
    {
        public DockPanelColorPalette()
        {

        }
        public DockPanelColorPalette(IPaletteFactory factory)
        {
            factory.Initialize(this);
        }

        [Description("The tab when docuemnts are 'collapsed'")]
        public AutoHideStripPalette AutoHideStripDefault { get; } = new AutoHideStripPalette();
        [Description("The tab when docuemnts are 'collapsed' and the mouse hovers over the tab")]
        public AutoHideStripPalette AutoHideStripHovered { get; } = new AutoHideStripPalette();
        [Description("The button that appears on the right if there are too many tabs\nThis is different to the tab selector which is always visible on the right\nChanges here will not reflect without restarting")]
        public ButtonPalette OverflowButtonDefault { get; } = new ButtonPalette();
        [Description("The button that appears on the right if there are too many tabs\nThis is different to the tab selector which is always visible on the right\nChanges here will not reflect without restarting")]
        public HoveredButtonPalette OverflowButtonHovered { get; } = new HoveredButtonPalette();
        [Description("The button that appears on the right if there are too many tabs\nThis is different to the tab selector which is always visible on the right\nChanges here will not reflect without restarting")]
        public HoveredButtonPalette OverflowButtonPressed { get; } = new HoveredButtonPalette();
        [Description("The selected tab if that tab has focus")]
        public TabPalette TabSelectedActive { get; } = new TabPalette();
        [Description("The selected tab if that tab does not have focus")]
        public TabPalette TabSelectedInactive { get; } = new TabPalette();
        [Description("Unselected tabs (regardless of what has focus)\nBackground only works for VS2013 themes")]
        public UnselectedTabPalette TabUnselected { get; } = new UnselectedTabPalette();
        [Description("When the mouse moves over a tab that is not selected")]
        public TabPalette TabUnselectedHovered { get; } = new TabPalette();

        [Description("Tab's exit button when the mouse moves over the selected tab's exit button, if that tab has focus")]
        public HoveredButtonPalette TabButtonSelectedActiveHovered { get; } = new HoveredButtonPalette();
        [Description("Tab's exit button while the mouse click is down anywhere on the tab row, if that tab has focus")]
        public HoveredButtonPalette TabButtonSelectedActivePressed { get; } = new HoveredButtonPalette();
        [Description("Tab's exit button when the mouse moves over the selected tab if that tab does not have focus")]
        public HoveredButtonPalette TabButtonSelectedInactiveHovered { get; } = new HoveredButtonPalette();
        [Description("Mouse down changes focus so this isn't really ever used\nA bug here this is used is if you start dragging a tab but dock it back in the same place and then select another tab")]
        public HoveredButtonPalette TabButtonSelectedInactivePressed { get; } = new HoveredButtonPalette();
        [Description("Tab's exit button when the mouse moves over a non selected tab's exit button, if that tab does not have focus")]
        public HoveredButtonPalette TabButtonUnselectedTabHoveredButtonHovered { get; } = new HoveredButtonPalette();
        [Description("Tab's exit button when the mouse click is down on the exit button of a non selected tab\nA bug here this is used is if you start dragging a tab but dock it back in the same place and then select another tab")]
        public HoveredButtonPalette TabButtonUnselectedTabHoveredButtonPressed { get; } = new HoveredButtonPalette();
        
        [Description("Back Color of the main docking window\nThis includes the space to the right of the tabs and between docked contents")]
        public MainWindowPalette MainWindowActive { get; } = new MainWindowPalette();
        public MainWindowStatusBarPalette MainWindowStatusBarDefault { get; } = new MainWindowStatusBarPalette();
        [Description("The title bar of a docked docuemnt which is not auto hidden and has focus")]
        public ToolWindowCaptionPalette ToolWindowCaptionActive { get; } = new ToolWindowCaptionPalette();
        [Description("The title bar of a docked docuemnt which is not auto hidden and does not have focus")]
        public ToolWindowCaptionPalette ToolWindowCaptionInactive { get; } = new ToolWindowCaptionPalette();
        [Description("Buttons in the title bar of a docked docuemnt which is not auto hidden and has focus, when the mouse hovers over the button\nChanges here will not reflect without restarting")]
        public HoveredButtonPalette ToolWindowCaptionButtonActiveHovered { get; } = new HoveredButtonPalette();
        [Description("Buttons in the title bar of a docked docuemnt which is not auto hidden and has focus, when the mouse click is down\nChanges here will not reflect without restarting")]
        public HoveredButtonPalette ToolWindowCaptionButtonPressed { get; } = new HoveredButtonPalette();
        [Description("Buttons in the title bar of a docked docuemnt which is not auto hidden and does not have focus, when the mouse hovers over the button\nChanges here will not reflect without restarting")]
        public HoveredButtonPalette ToolWindowCaptionButtonInactiveHovered { get; } = new HoveredButtonPalette();
        public ToolWindowTabPalette ToolWindowTabSelectedActive { get; } = new ToolWindowTabPalette();
        public ToolWindowTabPalette ToolWindowTabSelectedInactive { get; } = new ToolWindowTabPalette();
        public ToolWindowUnselectedTabPalette ToolWindowTabUnselected { get; } = new ToolWindowUnselectedTabPalette();
        [Description("Tab for un selected docked documents, when the mouse is over a document when there is more than 1 document docked to the same position (i.e., dock left)")]
        public ToolWindowTabPalette ToolWindowTabUnselectedHovered { get; } = new ToolWindowTabPalette();
        [Description("This is the 1px border around all the windows")]
        public Color ToolWindowBorder { get; set; }
        public Color ToolWindowSeparator { get; set; }
        [Description("This is that little dock image when moving windows")]
        public DockTargetPalette DockTarget { get; } = new DockTargetPalette();
        public CommandBarMenuPalette CommandBarMenuDefault { get; } = new CommandBarMenuPalette();
        public CommandBarMenuPopupPalette CommandBarMenuPopupDefault { get; } = new CommandBarMenuPopupPalette();
        public CommandBarMenuPopupDisabledPalette CommandBarMenuPopupDisabled { get; } = new CommandBarMenuPopupDisabledPalette();
        public CommandBarMenuPopupHoveredPalette CommandBarMenuPopupHovered { get; } = new CommandBarMenuPopupHoveredPalette();
        public CommandBarMenuTopLevelHeaderPalette CommandBarMenuTopLevelHeaderHovered { get; } = new CommandBarMenuTopLevelHeaderPalette();
        public CommandBarToolbarPalette CommandBarToolbarDefault { get; } = new CommandBarToolbarPalette();
        public CommandBarToolbarButtonCheckedPalette CommandBarToolbarButtonChecked { get; } = new CommandBarToolbarButtonCheckedPalette();
        public CommandBarToolbarButtonCheckedHoveredPalette CommandBarToolbarButtonCheckedHovered { get; } = new CommandBarToolbarButtonCheckedHoveredPalette();
        public CommandBarToolbarButtonPalette CommandBarToolbarButtonDefault { get; } = new CommandBarToolbarButtonPalette();
        public CommandBarToolbarButtonHoveredPalette CommandBarToolbarButtonHovered { get; } = new CommandBarToolbarButtonHoveredPalette();
        public CommandBarToolbarButtonPressedPalette CommandBarToolbarButtonPressed { get; } = new CommandBarToolbarButtonPressedPalette();
        public CommandBarToolbarOverflowButtonPalette CommandBarToolbarOverflowHovered { get; } = new CommandBarToolbarOverflowButtonPalette();
        public CommandBarToolbarOverflowButtonPalette CommandBarToolbarOverflowPressed { get; } = new CommandBarToolbarOverflowButtonPalette();
        [Browsable(false)]
        public VisualStudioColorTable ColorTable { get; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class CommandBarToolbarOverflowButtonPalette
    {
        public Color Background { get; set; }
        public Color Glyph { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class CommandBarToolbarButtonPressedPalette
    {
        public Color Arrow { get; set; }
        public Color Background { get; set; }
        public Color Text { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class CommandBarToolbarButtonHoveredPalette
    {
        public Color Arrow { get; set; }
        public Color Separator { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class CommandBarToolbarButtonPalette
    {
        public Color Arrow { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class CommandBarToolbarButtonCheckedHoveredPalette
    {
        public Color Border { get; set; }
        public Color Text { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class CommandBarToolbarButtonCheckedPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Text { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class CommandBarToolbarPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Grip { get; set; }
        public Color OverflowButtonBackground { get; set; }
        public Color OverflowButtonGlyph { get; set; }
        public Color Separator { get; set; }
        public Color SeparatorAccent { get; set; }
        public Color Tray { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class CommandBarMenuTopLevelHeaderPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Text { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class CommandBarMenuPopupHoveredPalette
    {
        public Color Arrow { get; set; }
        public Color Checkmark { get; set; }
        public Color CheckmarkBackground { get; set; }
        public Color ItemBackground { get; set; }
        public Color Text { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class CommandBarMenuPopupDisabledPalette
    {
        public Color Checkmark { get; set; }
        public Color CheckmarkBackground { get; set; }
        public Color Text { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class CommandBarMenuPopupPalette
    {
        public Color Arrow { get; set; }
        public Color BackgroundBottom { get; set; }
        public Color BackgroundTop { get; set; }
        public Color Border { get; set; }
        public Color Checkmark { get; set; }
        public Color CheckmarkBackground { get; set; }
        public Color IconBackground { get; set; }
        public Color Separator { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class CommandBarMenuPalette
    {
        public Color Background { get; set; }
        public Color Text { get; set; }
    }

    public interface IPaletteFactory
    {
        void Initialize(DockPanelColorPalette palette);
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class DockTargetPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color ButtonBackground { get; set; }
        public Color ButtonBorder { get; set; }
        public Color GlyphBackground { get; set; }
        public Color GlyphArrow { get; set; }
        public Color GlyphBorder { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class HoveredButtonPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Glyph { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class ButtonPalette
    {
        public Color Glyph { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class MainWindowPalette
    {
        public Color Background { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class MainWindowStatusBarPalette
    {
        public Color Background { get; set; }
        public Color Highlight { get; set; }
        public Color HighlightText { get; set; }
        public Color ResizeGrip { get; set; }
        public Color ResizeGripAccent { get; set; }
        public Color Text { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class ToolWindowTabPalette
    {
        public Color Background { get; set; }
        public Color Text { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class ToolWindowUnselectedTabPalette
    {
        public Color Background { get; set; } // VS2013
        public Color Text { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class ToolWindowCaptionPalette
    {
        public Color Background { get; set; }
        public Color Button { get; set; }
        public Color Grip { get; set; }
        public Color Text { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class TabPalette
    {
        public Color Background { get; set; }
        public Color Button { get; set; }
        public Color Text { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class UnselectedTabPalette
    {
        public Color Background { get; set; } // VS2013 only
        public Color Text { get; set; }
    }
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class AutoHideStripPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Text { get; set; }
    }

    public class SerializableExpandableObjectConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return false;
            }
            else
            {
                return base.CanConvertTo(context, destinationType);
            }
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return false;
            }
            else
            {
                return base.CanConvertFrom(context, sourceType);
            }
        }
    }
}
