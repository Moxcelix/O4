using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [System.Serializable]
    public class CharacteData
    {
        [SerializeField] public GameObject character;
        [SerializeField] public TextAsset text;
        [SerializeField] public SceneState state;
    }

    [SerializeField] private CharacteData[] _characterDatas;
    public CharacteData GetCharacterData(SceneState sceneState)
    {
        foreach (var data in _characterDatas)
        {
            if (data.state == sceneState)
            {
                return data;
            }
        }

        return null;
    }
}
