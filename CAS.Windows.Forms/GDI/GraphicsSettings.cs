//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UAOOI.Windows.Forms.GDI
{

  /// <summary>
  /// Class that represents graphic setting
  /// </summary>
  public class GraphicsSettings
  {

    #region private
    private Color mBackgroundColor;
    private Color mForegroundColor;
    private Color mSelectionPenColor;
    private Color mTextColor;
    private HatchStyle mHatchStyle;
    private float mPenWidth;
    private FontFamily mFontFamily;
    private float mFontSize;
    private FontStyle mFontStyle;
    private Brush backgroundBrush;
    private Brush mainBrush;
    private Brush selectionBrush;
    private Pen backgroundPen;
    private Pen mainPen;
    private Pen textPen;
    private Brush textBrush;
    private Pen selectionPen;
    private float mZoom;
    private Font mainFont;
    private void RecreateBrushesAndPens()
    {
      backgroundBrush = new SolidBrush( mBackgroundColor );
      backgroundPen = new Pen( backgroundBrush, mPenWidth * mZoom );

      mainBrush = new SolidBrush( mForegroundColor );
      mainPen = new Pen( mainBrush, mPenWidth * mZoom );

      selectionBrush = new HatchBrush(mHatchStyle,mSelectionPenColor);
      selectionPen = new Pen(selectionBrush,mPenWidth * mZoom);

      float fontsize = mFontSize * mZoom;
      if (mZoom <= 0.6F) 
        fontsize = fontsize + 1;
      FontStyle fontstyle = mFontStyle;
      if (fontsize < 6) 
        fontstyle = FontStyle.Bold;
      mainFont = new Font(mFontFamily, fontsize, fontstyle, System.Drawing.GraphicsUnit.Point);
      textBrush = new SolidBrush( mTextColor );
      textPen = new Pen( textBrush, 0.25F );
    }
    #endregion private

    #region public
    /// <summary>
    /// Initializes a new instance of the <see cref="GraphicsSettings"/> class.
    /// </summary>
    /// <param name="BackgroundColor">Color of the background.</param>
    /// <param name="ForegroundColor">Color of the foreground.</param>
    /// <param name="SelectionPenColor">Color of the selection pen.</param>
    /// <param name="TextColor">Color of the text.</param>
    /// <param name="HatchStyle">The hatch style.</param>
    /// <param name="PenWidth">Width of the pen.</param>
    /// <param name="FontFamily">The font family.</param>
    /// <param name="FontSize">Size of the font.</param>
    /// <param name="FontStyle">The font style.</param>
    /// <param name="Zoom">The zoom.</param>
    public GraphicsSettings( Color BackgroundColor, Color ForegroundColor, Color SelectionPenColor, Color TextColor,
      HatchStyle HatchStyle, float PenWidth, FontFamily FontFamily, float FontSize, FontStyle FontStyle,float Zoom )
    {
      if ( Zoom <= 0 )
        throw new ArgumentOutOfRangeException( "Zoom allows only greater than 0 values" );

      mBackgroundColor = BackgroundColor;
      mForegroundColor = ForegroundColor;
      mSelectionPenColor = SelectionPenColor;
      mTextColor = TextColor;
      mHatchStyle = HatchStyle;
      mPenWidth = PenWidth;
      mFontFamily = FontFamily;
      mFontSize = FontSize;
      mFontStyle = FontStyle;
      mZoom = Zoom;
      RecreateBrushesAndPens();
    }

    /// <summary>
    /// Gets the background pen.
    /// </summary>
    /// <value>The background pen.</value>
    public Pen BackgroundPen
    {
      get
      {
        return backgroundPen;
      }
    }
    /// <summary>
    /// Gets the main pen.
    /// </summary>
    /// <value>The main pen.</value>
    public Pen MainPen
    {
      get
      {
        return mainPen;
      }
    }
    /// <summary>
    /// Gets the text pen.
    /// </summary>
    /// <value>The text pen.</value>
    public Pen TextPen
    {
      get
      {
        return textPen;
      }
    }
    /// <summary>
    /// Gets the selection pen.
    /// </summary>
    /// <value>The selection pen.</value>
    public Pen SelectionPen
    {
      get
      {
        return selectionPen;
      }
    }
    /// <summary>
    /// Gets the background brush.
    /// </summary>
    /// <value>The background brush.</value>
    public Brush BackgroundBrush
    {
      get
      {
        return backgroundBrush;
      }
    }
    /// <summary>
    /// Gets the main brush.
    /// </summary>
    /// <value>The main brush.</value>
    public Brush MainBrush
    {
      get
      {
        return mainBrush;
      }
    }
    /// <summary>
    /// Gets the text brush.
    /// </summary>
    /// <value>The text brush.</value>
    public Brush TextBrush
    {
      get
      {
        return textBrush;
      }
    }
    /// <summary>
    /// Gets the selection brush.
    /// </summary>
    /// <value>The selection brush.</value>
    public Brush SelectionBrush
    {
      get
      {
        return selectionBrush;
      }
    }
    /// <summary>
    /// Gets the main font.
    /// </summary>
    /// <value>The main font.</value>
    public Font MainFont
    {
      get
      {
        return mainFont;
      }
    }
    /// <summary>
    /// Gets or sets the zoom.
    /// </summary>
    /// <value>The zoom.</value>
    public float Zoom
    {
      get
      {
        return mZoom;
      }
      set
      {
        if ( value <= 0 )
          throw new ArgumentOutOfRangeException( "Zomm alows only greater than 0 values" );
        mZoom = value;
        RecreateBrushesAndPens();
      }
    }
    /// <summary>
    /// Gets the graphics settings with specified zoom.
    /// </summary>
    /// <param name="zoom">The zoom.</param>
    /// <returns></returns>
    public GraphicsSettings GetGraphicsSettingsWithSpecifiedZoom( float zoom )
    {
      return new GraphicsSettings( mBackgroundColor, mForegroundColor, mSelectionPenColor, mTextColor,
        mHatchStyle, mPenWidth, mFontFamily, mFontSize, mFontStyle, zoom );
    }
    /// <summary>
    /// Gets the default graphisc settings.
    /// </summary>
    /// <value>The default graphisc settings.</value>
    public static GraphicsSettings Default
    {
      get
      {
        return new GraphicsSettings( Color.White, Color.Black, Color.Red, Color.Black,
          HatchStyle.WideDownwardDiagonal, 2.5F,
          new FontFamily( "Microsoft Sans Serif" ), 8F, FontStyle.Regular, 1F );
      }
    }
    #endregion public

  }
}
