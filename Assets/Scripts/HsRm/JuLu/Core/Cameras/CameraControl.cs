using UnityEngine;

namespace Content.Scripts.HsRm.JuLu.Core.Cameras
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private bool lockCursor;

        private bool _currentCameraControl = false;
        public virtual Vector3 LookPosition => camera.transform.position;
        public virtual Quaternion LookRotation => camera.transform.rotation;

        private void Update()
        {
            if (!_currentCameraControl) return;
            HandleUpdate();
            UpdateCursor();
        }
        
        public void Activate()
        {
            _currentCameraControl = true;
            HandleActivated();
        }

        public void Deactivate()
        {
            _currentCameraControl = false;
            HandleDeactivated();
        }

        public void ToggleCursor()
        {
            lockCursor = !lockCursor;
            UpdateCursor();
        }

        public bool LockCursor
        {
            get => lockCursor;
            set { lockCursor = value; UpdateCursor(); }
        }

        protected virtual void UpdateCursor()
        {
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                if (Application.isEditor || Screen.fullScreen)
                {
                    Cursor.visible = false;
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        
        public virtual void AlignTransform(Vector3 position, Quaternion lookRotation) 
        {
            transform.position = position;
            transform.rotation = lookRotation;
        }
        
        protected virtual void HandleActivated() { }
        protected virtual void HandleDeactivated() { }
        protected virtual void HandleUpdate() { }

        public Camera Camera => camera;
        public bool CurrentCameraControl => _currentCameraControl;
    }
}