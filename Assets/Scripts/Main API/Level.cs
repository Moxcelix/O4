using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private CharacterManager _characterManager;
    public static Level Instance { get; private set; }

    public delegate void OnStartTrackingDelegate();
    public event OnStartTrackingDelegate OnStartTrackingEvent;

    private void Awake()
    {
        Instance = this;
    }

    public void OnStartTracking()
    {
        OnStartTrackingEvent?.Invoke();
    }

    public CharacterManager.CharacteData GetCurrentCharacter()
    {
        return _characterManager.GetCharacterData(GlobalSpace.CurrentSceneState);
    }
}
