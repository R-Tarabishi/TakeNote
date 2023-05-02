namespace TakeNote.Components;

public partial class NoteCard : ContentView
{


    public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(NoteCard), string.Empty);
    public static readonly BindableProperty CardDescriptionProperty = BindableProperty.Create(nameof(CardDescription), typeof(string), typeof(NoteCard), string.Empty);

    public string CardTitle
    {
        get => (string)GetValue(NoteCard.CardTitleProperty);
        set => SetValue(NoteCard.CardTitleProperty, value);
    }

    public string CardDescription
    {
        get => (string)GetValue(CardDescriptionProperty);
        set => SetValue(CardDescriptionProperty, value);
    }


    public NoteCard()
	{
        InitializeComponent();
    }
}