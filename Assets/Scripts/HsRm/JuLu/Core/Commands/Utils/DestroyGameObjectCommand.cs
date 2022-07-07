using UnityEngine;

namespace HsRm.JuLu.Core.Commands.Utils
{
    public class DestroyGameObjectCommand : BaseCommand
    {
        [SerializeField] private GameObject target;

        public override bool IsExecutable 
        { 
            get => base.IsExecutable && target != null;
            set => base.IsExecutable = value; 
        }

        protected override void ExecuteCommand()
        {
            Destroy(target);
        }
    }
}
