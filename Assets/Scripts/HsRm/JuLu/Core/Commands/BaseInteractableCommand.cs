using HsRm.JuLu.Core.Interactables;

namespace HsRm.JuLu.Core.Commands
{
    public abstract class BaseInteractableCommand : BaseCommand
    {
        protected Interactable Interactable { get; set; }

        private bool IsInteractable => Interactable != null;
        
        protected override bool IsExecutable
        {
            get => base.IsExecutable && IsInteractable && Interactable.IsInteractable;
            set => base.IsExecutable = value;
        }
        
        public void TrySetInteractable(Interactable interactable)
        {
            if (CanUseInteractable(interactable))
            {
                Interactable = interactable;
            }
        }

        public void TryUseInteractable(Interactable interactable)
        {
            TrySetInteractable(interactable);
            Execute();
            ClearInteractable();
        }

        public void ClearInteractable()
        {
            Interactable = null;
        }
        
        public abstract bool CanUseInteractable(Interactable interactable);
    }
}
