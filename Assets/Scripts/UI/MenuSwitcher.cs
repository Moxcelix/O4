using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;

    private void Start()
    {
        OpenPage(0);
    }

    public void OpenPage(int index) 
    {
        if(index < 0 || index >= pages.Length)
            throw new System.ArgumentOutOfRangeException("index");

        for (int i = 0; i < pages.Length; i++)
            pages[i].SetActive(i == index);
    }
}
