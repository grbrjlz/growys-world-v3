using UnityEngine;

namespace HsRm.JuLu.Core.Interactables
{
    public class InteractableToggle : Interactable
    {
        [SerializeField] private bool state; 
        
        public BoolEvent onValueChange;

        private bool State
        {
            get => state;
            set
            {
                if (IsInteractable)
                {
                    state = value;
                    TriggerChangeState();
                }
            }
        }

        public void ToggleValue() => State = !state;
        private void TriggerChangeState() => onValueChange?.Invoke(state);
    }
}
