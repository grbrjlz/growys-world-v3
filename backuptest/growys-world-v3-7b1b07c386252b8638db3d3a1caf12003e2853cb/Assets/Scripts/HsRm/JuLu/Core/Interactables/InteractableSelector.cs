using UnityEngine;

namespace Content.Scripts.HsRm.JuLu.Core.Interactables
{
    public class InteractableSelector : MonoBehaviour
    {
        [SerializeField] private Interactable interactable;

        public Interactable SelectedInteractable => interactable;
    }
}