using UnityEngine;

namespace Content.Scripts.HsRm.JuLu.Core
{
    public class Raycaster : MonoBehaviour
    {
        [SerializeField] private Camera currentCamera;

        public Camera Camera => currentCamera;
    }
}
