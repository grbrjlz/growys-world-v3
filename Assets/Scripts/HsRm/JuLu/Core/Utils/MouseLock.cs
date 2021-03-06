using UnityEngine;

namespace HsRm.JuLu.Core.Utils
{
    public class MouseLock : MonoBehaviour
    {
        private enum MouseAxes { XY = 0, X = 1, Y = 2 };

        private enum RotationSpace { World, Local };

        [SerializeField] private MouseAxes mouseAxes = MouseAxes.XY;
        [SerializeField] private RotationSpace rotationSpace = RotationSpace.Local;

        [SerializeField] private float lerpSpeed = 20f;
        [SerializeField] private float sensitivityX = 500f;
        [SerializeField] private float sensitivityY = 500f;

        [SerializeField] private float minimumX = -360f;
        [SerializeField] private float maximumX = 360f;

        [SerializeField] private float minimumY = -80f;
        [SerializeField] private float maximumY = 80f;

        [SerializeField] private bool invertX = false;
        [SerializeField] private bool invertY = true;


        private float rotationX = 0f;
        private float rotationY = 0f;

        public float SensitivityX { get => sensitivityX; set => sensitivityX = value; }
        public float SensitivityY { get => sensitivityY; set => sensitivityY = value; }

        public bool InvertX { get => invertX; set => invertX = value; }
        public bool InvertY { get => invertY; set => invertY = value; }

        private Vector3 CurrentEulerRotation => rotationSpace == RotationSpace.World ? transform.eulerAngles : transform.localEulerAngles;
        private Quaternion CurrentRotation => rotationSpace == RotationSpace.World ? transform.rotation : transform.localRotation;

        private void Start()
        {
            Initialize(CurrentRotation);
        }

        public void Initialize(Quaternion rotation)
        {
            // set rotation to transform, needed for initialization of internal rotation values
            SetRotation(rotation);
            
            // initialize internal rotation values, takes clamping into account
            var initialRotation = InitializeRotationValues();
            
            // finally override with initialized and clamped rotation
            LerpRotation(initialRotation);
        }

        public void UpdateRotation()
        {
            switch (mouseAxes)
            {
                case MouseAxes.XY:
                    LerpRotation(UpdateRotationX() * UpdateRotationY());
                    break;
                case MouseAxes.X:
                    LerpRotation(UpdateRotationX());
                    break;
                case MouseAxes.Y:
                    LerpRotation(UpdateRotationY());
                    break;
            }
        }

        private Quaternion UpdateRotationX()
        {
            var mouseX = GetAxis("Mouse X", invertX);
            rotationX += mouseX * sensitivityX * Time.deltaTime;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            return Quaternion.AngleAxis(rotationX, Vector3.up);
        }

        private Quaternion UpdateRotationY()
        {
            var mouseY = GetAxis("Mouse Y", invertY);
            rotationY += mouseY * sensitivityY * Time.deltaTime;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            return Quaternion.AngleAxis(rotationY, Vector3.right);
        }

        private Quaternion InitializeRotationValues()
        {
            var clampedRotation = CurrentRotation;
            switch (mouseAxes)
            {
                case MouseAxes.XY:
                    clampedRotation = ClampRotationX() * ClampRotationY();
                    break;
                case MouseAxes.X:
                    clampedRotation = ClampRotationX();
                    break;
                case MouseAxes.Y:
                    clampedRotation = ClampRotationY();
                    break;
            }
            return clampedRotation;
        }

        private Quaternion ClampRotationX()
        {
            var angle = CurrentEulerRotation.y;
            rotationX = ClampAngle(angle, minimumX, maximumX);
            return Quaternion.AngleAxis(rotationX, Vector3.up);
        }

        private Quaternion ClampRotationY()
        {
            var angle = CurrentEulerRotation.x;
            var lookingUp = Vector3.Dot(transform.forward, Vector3.up) > 0;
            if (lookingUp)
            {
                angle -= 360;
            }
            rotationY = ClampAngle(angle, minimumY, maximumY);
            return Quaternion.AngleAxis(rotationY, Vector3.right);
        }

        private void SetRotation(Quaternion rotation)
        {
            if (rotationSpace == RotationSpace.World)
            {
                transform.rotation = rotation;
            }
            else
            {
                transform.localRotation = rotation;
            }
        }

        private void LerpRotation(Quaternion rotation)
        {
            if (rotationSpace == RotationSpace.World)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation ,Time.deltaTime * lerpSpeed);
            }
            else
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, Time.deltaTime * lerpSpeed);
            }
        }

        public float GetAxis(string axis, bool inverted)
        {
            var value = Mathf.Clamp(Input.GetAxis(axis), -10f, 10f);
            return inverted ? -value : value;
        }

        private float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360f)
                angle += 360f;
            if (angle > 360f)
                angle -= 360f;
            return Mathf.Clamp(angle, min, max);
        }
    }
}
