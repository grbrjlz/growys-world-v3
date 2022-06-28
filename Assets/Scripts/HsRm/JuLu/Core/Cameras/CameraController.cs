using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace HsRm.JuLu.Core.Cameras
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraControl currentCameraControl;
        [SerializeField] private bool initializeOnStart = true;
        
        public UnityEvent onCameraControlActivated;

        public CameraControl CurrentCameraControl 
        { 
            get => currentCameraControl; 
            private set { currentCameraControl = value; } 
        }

        private void Start()
        {
            if (initializeOnStart)
            { 
                DeactivateSceneCameraControls();
                if (HasCurrentCameraControl)
                {
                    CurrentCameraControl.gameObject.SetActive(true);
                    CurrentCameraControl.Activate();
                    onCameraControlActivated?.Invoke();
                }
            }
        }

        public bool HasCurrentCameraControl => CurrentCameraControl != null;

        public void DeactivateSceneCameraControls()
        {
            var cameraControls = FindObjectsOfType<CameraControl>();
            foreach (var cameraControl in cameraControls)
            {
                if (cameraControl.CurrentCameraControl)
                { 
                    cameraControl.Deactivate();
                }
                cameraControl.gameObject.SetActive(false);
            }
        }

        public void ActivateCameraControl(CameraControl cameraControl)
        {
            DeactivateCurrentCameraControl();
            
            cameraControl.gameObject.SetActive(true);
            cameraControl.Activate();
            if (HasCurrentCameraControl)
            {
                cameraControl.AlignTransform(CurrentCameraControl.LookPosition, CurrentCameraControl.LookRotation);
            }

            CurrentCameraControl = cameraControl;

            onCameraControlActivated?.Invoke();
        }

        private void DeactivateCurrentCameraControl()
        {
            if (HasCurrentCameraControl)
            {
                CurrentCameraControl.Deactivate();
                CurrentCameraControl.gameObject.SetActive(false);
            }
        }
    }
}
