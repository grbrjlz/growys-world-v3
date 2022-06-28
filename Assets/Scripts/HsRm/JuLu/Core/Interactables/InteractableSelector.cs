using UnityEngine;

namespace HsRm.JuLu.Core.Interactables
{
    public class InteractableSelector : MonoBehaviour
    {
        [SerializeField] private Interactable interactable;

        public Interactable SelectedInteractable => interactable;
        
        private void Awake()
        {
            if (interactable == null) 
            { 
                interactable = transform.GetComponentInParent<Interactable>();
            }
        }
    }
}
