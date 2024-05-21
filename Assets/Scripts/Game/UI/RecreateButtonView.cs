using Core.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class RecreateButtonView : MonoBehaviour
    {
        [SerializeField] private GameObject _portal;
        
        [SerializeField] private float _distanceFromCamera; 
        
        private Camera _mainCamera; 
        private Button _recenterButton;
        private GameObject _referencePoint;

        private void Start()
        {
            _recenterButton = GetComponent<Button>();

            _mainCamera = CameraService.GetCamera();
            
            _recenterButton.onClick.AddListener(RecenterPortal);

            _referencePoint = new GameObject("ReferencePoint");
        }

        private void RecenterPortal()
        {
            Vector3 newPosition = _mainCamera.transform.position + _mainCamera.transform.forward * _distanceFromCamera;

            _referencePoint.transform.position = newPosition;

            _portal.transform.SetParent(_referencePoint.transform, false);
            _portal.transform.localPosition = Vector3.zero;
            _portal.transform.localRotation = Quaternion.identity;
            
            _portal.transform.LookAt(_mainCamera.transform);
            _portal.transform.Rotate(0, 180, 0);
            _portal.transform.SetParent(null, true);
        }
    }
}
