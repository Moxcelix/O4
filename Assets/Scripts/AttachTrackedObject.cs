using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class AttachTrackedObject : MonoBehaviour
{
    private ARTrackedImageManager _trackedImagesManager;
    private GameObject _trackedObject;
    private Transform _trackedImageTransform;

    [SerializeField] private GameObject _prefab;

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

    private void Update()
    {
        MoveTrackedObjectIfItExists();
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        if (eventArgs.added.Count == 0) return;

        var trackedImage = eventArgs.added[^1];
        var imageName = trackedImage.referenceImage.name;

        _trackedImageTransform = trackedImage.transform;

        ScreenLogger.Instance.Trace($"Tracker \"{imageName}\"!");

        if (_trackedObject == null)
        {
            _trackedObject = Instantiate(_prefab,
                _trackedImageTransform.position, Quaternion.identity);
        }

    }

    private void MoveTrackedObjectIfItExists()
    {
        if (_trackedObject == null) return;

        _trackedObject.transform.SetPositionAndRotation(
                    _trackedImageTransform.position,
                    _trackedImageTransform.rotation);
    }
}
