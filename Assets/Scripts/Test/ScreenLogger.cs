using UnityEngine;
using UnityEngine.UI;

public class ScreenLogger : MonoBehaviour
{
    [SerializeField] private Text _text;

    public static ScreenLogger Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void Trace(string text) 
    {
        if (text == null) return;

        _text.text += $"{text} \n";
    }
}
