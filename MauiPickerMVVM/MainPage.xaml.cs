using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
namespace MauiPickerMVVM;
public partial class Person : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DisplayName))]
    string firstName = "FirstName";
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DisplayName))]
    string lastName = "LastName";
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DisplayName))]
    string timeStamp = "HH:mm:ss";
    public string DisplayName => $"[{TimeStamp}] {FirstName} {LastName}";
}
public partial class MainPage : ContentPage
{
    public ObservableCollection<Person> People { get; } = new()
    {
        new Person { FirstName = "John", LastName = "Doe" },
        new Person { FirstName = "Jane", LastName = "Smith" },
        new Person { FirstName = "Sam", LastName = "Johnson" }
    };
    IDispatcherTimer timer;
    public MainPage()
    {
        InitializeComponent();
        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) =>
        {
            foreach (var person in People)
            {
                person.TimeStamp = DateTime.Now.ToString("HH:mm:ss");
                // picker.ItemDisplayBinding = new Binding("DisplayName"); // Uncomment: Workaround
            }
        };
        timer.Start();
    }
}
