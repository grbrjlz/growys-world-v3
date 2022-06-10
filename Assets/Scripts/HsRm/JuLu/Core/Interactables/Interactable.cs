using UnityEngine;

namespace Content.Scripts.HsRm.JuLu.Core.Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] private bool interactable = true;

        protected bool IsInteractable
        {
            get => interactable;
            set => interactable = value;
        }
    }
}
