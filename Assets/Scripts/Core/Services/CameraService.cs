using UnityEngine;

namespace Core.Services
{
    public class CameraService
    {
        public static Camera GetCamera()
        {
            return Camera.main;
        }
    }
}