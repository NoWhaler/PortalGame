using UnityEngine;

namespace Game
{
    public class WallsCollisionDetection : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Transform _cameraOffsetTransform;

        [SerializeField] private LayerMask _layerMask;
        public float maxRaycastDistance = 0.25f;

        void Update()
        {
            Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxRaycastDistance, _layerMask))
            {
                if (hit.collider != null)
                {
                    Debug.Log("Hit");
                    
                    _cameraTransform.position = hit.point;
                    _cameraOffsetTransform.position = hit.point;
                }
            }
        }
    }
}