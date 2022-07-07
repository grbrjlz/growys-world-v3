using HsRm.JuLu.Core.Collectables;

namespace HsRm.JuLu.Core.Commands.Collectables
{
    public class GetCollectableCommand : BaseCommand
    {
        public Collectable Collectable { get; protected set; }

        public bool IsCollectable => Collectable != null;

        public override bool IsExecutable
        {
            get => base.IsExecutable && IsCollectable;
            set => base.IsExecutable = value;
        }

        protected override void ExecuteCommand()
        {
            Collectable.Collect();
            ClearCollectable();
        }
        
        public void GetCollectable(Collectable collectable)
        {
            SetCollectable(collectable);
            Execute();
        }
        
        public void SetCollectable(Collectable collectable)
        {
            Collectable = collectable;
        }

        public void ClearCollectable()
        {
            Collectable = null;
        }
    }
}
