namespace QuickGraph.Graphviz.Dot
{
    using System;
    using System.ComponentModel;

    public enum GraphvizImageType
    {
        /// <summary>
        /// Client-side imagemaps
        /// </summary>
        [Description("Client-side imagemaps")]
        Cmap = 6,
        [Description("Figure format")]
        Fig = 0,
        [Description("Gd format")]
        Gd = 1,
        [Description("Gd2 format")]
        Gd2 = 2,
        [Description("GIF format")]
        Gif = 3,
        /// <summary>
        /// HP-GL/2 format
        /// </summary>
        [Description("HP-GL/2 format")]
        Hpgl = 4,
        /// <summary>
        /// Server-side imagemaps
        /// </summary>
        [Description("Server-side imagemaps")]
        Imap = 5,
        [Description("JPEG format")]
        Jpeg = 7,
        /// <summary>
        /// FrameMaker MIF format
        /// </summary>
        [Description("FrameMaker MIF format")]
        Mif = 8,
        /// <summary>
        /// MetaPost
        /// </summary>
        [Description("MetaPost")]
        Mp = 9,
        /// <summary>
        /// PCL format
        /// </summary>
        [Description("PCL format")]
        Pcl = 10,
        /// <summary>
        /// PIC format
        /// </summary>
        [Description("PIC format")]
        Pic = 11,
        /// <summary>
        /// plain text format
        /// </summary>
        [Description("plain text format")]
        PlainText = 12,
        /// <summary>
        /// Portable Network Graphics format
        /// </summary>
        [Description("Portable Network Graphics format")]
        Png = 13,
        /// <summary>
        /// Postscript
        /// </summary>
        [Description("Postscript")]
        Ps = 14,
        /// <summary>
        /// PostScript for PDF
        /// </summary>
        [Description("PostScript for PDF")]
        Ps2 = 15,
        /// <summary>
        /// Scalable Vector Graphics
        /// </summary>
        [Description("Scalable Vector Graphics")]
        Svg = 0x10,
        /// <summary>
        /// Scalable Vector Graphics, gzipped
        /// </summary>
        [Description("Scalable Vector Graphics, gzipped")]
        Svgz = 0x11,
        /// <summary>
        /// VRML
        /// </summary>
        [Description("VRML")]
        Vrml = 0x12,
        /// <summary>
        /// Visual Thought format
        /// </summary>
        [Description("Visual Thought format")]
        Vtx = 0x13,
        /// <summary>
        /// Wireless BitMap format
        /// </summary>
        [Description("Wireless BitMap format")]
        Wbmp = 20,
    }
}

