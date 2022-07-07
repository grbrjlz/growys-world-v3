using HsRm.JuLu.Core.Commands;
using HsRm.JuLu.Core.Interactables;
using UnityEngine;

namespace HsRm.JuLu.Core.Utils
{

    public class InteractableSelector : MonoBehaviour
    {
        [SerializeField] private BaseInteractableCommand interactable;

        public BaseInteractableCommand Interactable => interactable;

        private void Awake()
        {
            if (interactable == null) 
            { 
                interactable = transform.GetComponentInParent<BaseInteractableCommand>();
            }
        }
    }
}