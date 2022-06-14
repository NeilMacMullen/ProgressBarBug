using Microsoft.Maui.Dispatching;

namespace ProgressBar;

public partial class MainPage : ContentPage
{
    private double _currentValue = 1.0;

    private int _direction = -1;

    private readonly IDispatcherTimer
        _timer = Microsoft.Maui.Dispatching.Dispatcher.GetForCurrentThread().CreateTimer();

    public MainPage()
    {
        InitializeComponent();
        _timer.Interval = TimeSpan.FromSeconds(0.5);
        _timer.Tick += _timer_Tick;
        _timer.Start();
    }

    private void _timer_Tick(object sender, EventArgs e)
    {
        _currentValue += 0.05 * _direction;
        if (_currentValue < 0) _currentValue = 1.0;
        if (_currentValue > 1.0) _currentValue = 0;

        TheProgresBar.Progress = _currentValue;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        _direction *= -1;
    }
}