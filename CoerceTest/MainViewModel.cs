using System.Diagnostics;

namespace CoerceTest;

public class MainViewModel
{
    private string _strValue;

    public string StrValue
    {
        get => _strValue;
        set
        {
            Debug.WriteLine($"ViewModel.StrValue_set: {value}");
            _strValue = value;
        }
    }
}