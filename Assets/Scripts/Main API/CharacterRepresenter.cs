using UnityEngine;

public class CharacterRepresenter : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private GameObject _characterInstance = null;

    private void OnEnable()
    {
        Level.Instance.OnStartTracking();

        AttachCharacter();
    }

    private void OnDisable()
    {
        DetachCharacter();
    }

    private void AttachCharacter()
    {
        var data = Level.Instance.GetCurrentCharacter();

        if (data == null)
            return;

        InstantiateCharacter(data.character);
    }

    private void DetachCharacter()
    {
        Destroy(_characterInstance);
        _characterInstance = null;
    }

    private void InstantiateCharacter(GameObject character)
    {
        _characterInstance = Instantiate(character);
        _characterInstance.transform.parent = transform;
        _characterInstance.transform.localPosition = Vector3.zero;
        _characterInstance.transform.localEulerAngles = Vector3.zero;
    }
}
