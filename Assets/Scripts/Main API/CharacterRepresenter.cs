using UnityEngine;

public class CharacterRepresenter : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _testCube;

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
        {
            return;
        }

        if(data.character == null)
        {
            _testCube.gameObject.SetActive(true);

            return;
        }

        _testCube.gameObject.SetActive(false);
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
