using HsRm.JuLu.Core.Interactables;

namespace HsRm.JuLu.Core.Commands.Interactables
{
    public class InteractableTriggerCommand : BaseInteractableCommand
    {
        private InteractableTrigger InteractableTrigger => Interactable as InteractableTrigger;
        public override bool CanUseInteractable(Interactable interactable) => interactable is InteractableTrigger;
        protected override void ExecuteCommand() => InteractableTrigger.Trigger();
    }
}
