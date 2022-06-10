using UnityEngine.Events;

namespace Content.Scripts.HsRm.JuLu.Core.Interactables
{
    public class InteractableTrigger : Interactable
    {
        public UnityEvent onTrigger;

        public void Trigger()
        {
            if (IsInteractable)
            {
                onTrigger?.Invoke();
            }
        }
    }
}
