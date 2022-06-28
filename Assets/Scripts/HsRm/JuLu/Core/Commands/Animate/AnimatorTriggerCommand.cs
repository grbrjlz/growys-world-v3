using UnityEngine.Events;

namespace HsRm.JuLu.Core.Commands.Animate
{
    public class AnimatorTriggerCommand : BaseAnimatorCommand
    {
        public UnityEvent onExecute;
        
        protected override void ExecuteCommand()
        {
            BaseAnimator.SetTrigger(ParameterName);
            onExecute?.Invoke();
        }
    }
}
