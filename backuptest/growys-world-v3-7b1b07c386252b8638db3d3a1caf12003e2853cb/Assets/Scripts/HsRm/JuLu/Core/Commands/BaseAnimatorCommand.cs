using UnityEngine;

namespace Content.Scripts.HsRm.JuLu.Core.Commands
{
    public abstract class BaseAnimatorCommand : BaseCommand
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string parameter = string.Empty;

        protected override bool IsExecutable
        {
            get => base.IsExecutable && animator != null;
            set => base.IsExecutable = value;
        }
        
        protected Animator BaseAnimator => animator;
        protected string ParameterName => parameter;
    }
}
