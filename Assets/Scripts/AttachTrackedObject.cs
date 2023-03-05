using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class AttachTrackedObject : MonoBehaviour
{
    private ARTrackedImageManager _trackedImagesManager;
    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new();

    [SerializeField] private GameObject[] ARPrefabs;

    private void Awake()
    {
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    { 
        foreach(var trackedImage in eventArgs.added)
        {
            var imageName = trackedImage.referenceImage.name;

            foreach(var prefab in ARPrefabs)
            {
                if(string.Compare(prefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0
                    && !_instantiatedPrefabs.ContainsKey(imageName))
                {
                    var newPrefab = Instantiate(prefab, trackedImage.transform);

                    _instantiatedPrefabs.Add(imageName, newPrefab);
                }
            }
        }

        foreach (var trackedImage in eventArgs.removed) 
        {
            var imageName = trackedImage.referenceImage.name;

            Destroy(_instantiatedPrefabs[imageName]);

            _instantiatedPrefabs.Remove(imageName);
        }
    }
}
