using Core.Services;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace Game
{
    public class PortalHandler : MonoBehaviour
    {
        private Camera _mainCamera;

        [SerializeField] private GameObject _portal;

        [SerializeField] private Collider[] _wallColliders;

        private Material[] _portalMaterials;

        private const string STENCIL = "_StencilComp";
        
        private void Start()
        {
            _portalMaterials = _portal.GetComponent<Renderer>().sharedMaterials;

            _mainCamera = CameraService.GetCamera();
        }
        
        private void SetPortalMaterialsStencil(CompareFunction compareFunction)
        {
            foreach (var material in _portalMaterials)
            {
                material.SetInt(STENCIL, (int)compareFunction);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            SetPortalMaterialsStencil(CompareFunction.Always);
            foreach (var collider in _wallColliders)
            {
                collider.enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Vector3 cameraPositionInPortal = transform.InverseTransformPoint(_mainCamera.transform.position);
            
            if (cameraPositionInPortal.y > 3.0f)
            {
                SetPortalMaterialsStencil(CompareFunction.Equal);
                
                foreach (var collider in _wallColliders)
                {
                    collider.enabled = false;
                }
            }
        }
    }
}