using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class TextReader : MonoBehaviour
{
    private enum State
    {
        SCANNING,
        READING,
        WAITING
    }

    private readonly float _charPause = 0.0625f;

    [SerializeField] private Text _textField;
    [SerializeField] private GameObject _repeatButton;
    [SerializeField] private GameObject _dialogField;

    private State _state = State.SCANNING;

    private void Start()
    {
        SwitchState(State.SCANNING);
    }
    private void OnEnable()
    {
        Level.Instance.OnStartTrackingEvent += SwitchToReadingState;
    }
    private void OnDisable()
    {
        Level.Instance.OnStartTrackingEvent -= SwitchToReadingState;
    }
    public void ReadText()
    {
        SwitchState(State.READING);

        StartCoroutine(ShowTextCoroutine(
            Level.Instance.GetCurrentCharacter().text));
    }

    private void SwitchToReadingState()
    {
        if (State.READING == _state)
            return;

        ReadText();
    }

    private void SwitchState(State state)
    {
        _state = state;

        _dialogField.SetActive(_state == State.READING);
        _repeatButton.SetActive(_state == State.WAITING);
    }

    private IEnumerator ShowTextCoroutine(TextAsset asset)
    {
        var textLines = asset.text.Split('\n');

        for (int i = 0; i < textLines.Length; i++)
        {
            _textField.text = textLines[i];
            yield return new WaitForSeconds(textLines[i].Length * _charPause);
        }

        SwitchState(State.WAITING);
    }
}
