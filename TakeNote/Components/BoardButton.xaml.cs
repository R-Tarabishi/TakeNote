namespace TakeNote.Components;

public partial class BoardButton : ContentView
{


    public static readonly BindableProperty BoardTitleProperty = BindableProperty.Create(nameof(BoardTitle), typeof(string), typeof(BoardButton));
    public static readonly BindableProperty BoardIdProperty = BindableProperty.Create(nameof(BoardID), typeof(int), typeof(BoardButton), 0);
    public static readonly BindableProperty BgColorProperty = BindableProperty.Create(nameof(BgColor), typeof(Color), typeof(BoardButton), Color.FromRgb(255, 255, 255));
    public static readonly BindableProperty FgColorProperty = BindableProperty.Create(nameof(FgColor), typeof(Color), typeof(BoardButton), Color.FromRgb(0, 0, 0));



    public string BoardTitle
    {
        get => (string)GetValue(BoardTitleProperty);
        set => SetValue(BoardTitleProperty, value);
    }

    public int BoardID
    {
        get => (int)GetValue(BoardIdProperty);
        set => SetValue(BoardIdProperty, value);
    }

    public Color BgColor
    {
        get => (Color)GetValue(BgColorProperty);
        set => SetValue(BgColorProperty, value);
    }
    public Color FgColor
    {
        get => (Color)GetValue(FgColorProperty);
        set => SetValue(FgColorProperty, value);
    }

    public BoardButton()
    {
        InitializeComponent();
    }

}