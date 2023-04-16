using UnityEngine;
public class GlobalSpace
{
    public static SceneState CurrentSceneState { get; private set; }

    public static void SetSceneState(SceneState sceneState)
    {
        Debug.Log($"Current scene state is {sceneState}");

        CurrentSceneState = sceneState;
    }
}
