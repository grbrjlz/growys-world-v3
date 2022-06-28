using UnityEngine;

namespace HsRm.JuLu.Core.Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] private bool interactable = true;

        public bool IsInteractable
        {
            get => interactable;
            set => interactable = value;
        }
    }
}
