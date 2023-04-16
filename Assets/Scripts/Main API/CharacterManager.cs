using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [System.Serializable]
    public struct StateCharacterPair
    {
        [SerializeField] public GameObject character;
        [SerializeField] public SceneState state;
    }

    [SerializeField] private StateCharacterPair[] _stateCharacterPairs;
    [SerializeField] private Transform _spawnPoint;

    private void OnEnable()
    {
        foreach (var pair in _stateCharacterPairs)
        {
            if(pair.state == GlobalSpace.CurrentSceneState)
            {
                AttachCharacter(pair.character);

                break;
            }
        }
    }

    private void AttachCharacter(GameObject character) 
    {
        var characterInstance = Instantiate(character);
        characterInstance.transform.parent = transform;
        characterInstance.transform.localPosition = Vector3.zero;
        characterInstance.transform.localEulerAngles = Vector3.zero;
    }
}
