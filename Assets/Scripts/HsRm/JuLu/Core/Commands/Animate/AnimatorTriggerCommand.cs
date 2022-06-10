namespace Content.Scripts.HsRm.JuLu.Core.Commands.Animate
{
    public class AnimatorTriggerCommand : BaseAnimatorCommand
    {
        protected override void ExecuteCommand()
        {
            BaseAnimator.SetTrigger(ParameterName);
        }
    }
}
