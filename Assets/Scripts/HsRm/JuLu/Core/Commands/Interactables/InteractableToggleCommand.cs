using HsRm.JuLu.Core.Interactables;

namespace HsRm.JuLu.Core.Commands.Interactables
{
    public class InteractableToggleCommand : BaseInteractableCommand
    {
        private InteractableToggle InteractableToggle => Interactable as InteractableToggle;
        public override bool CanUseInteractable(Interactable interactable) => interactable is InteractableToggle;
        protected override void ExecuteCommand() => InteractableToggle.ToggleValue();
    }
}
