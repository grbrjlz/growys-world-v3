using UnityEngine;

namespace Content.Scripts.HsRm.JuLu.Core.Commands
{
    public abstract class BaseRaycasterCommand : BaseCommand
    {
        [SerializeField] private Core.Raycaster raycaster;
        [SerializeField] private LayerMask layers;
        [SerializeField] private float maxDistance;
        
        protected Ray Ray { get; set; }

        protected override void ExecuteCommand()
        {
            if (HasHit(out var hit))
            {
                HandleHit(hit);
            }
            else
            {
                HandleMiss();
            }
        }

        protected bool HasHit(out RaycastHit hit)
        {
            Ray = raycaster.Camera.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            return Physics.Raycast(Ray, out hit, maxDistance, layers);
        }

        protected abstract void HandleHit(RaycastHit hit);
        protected abstract void HandleMiss();

        protected Core.Raycaster Raycaster => raycaster;
        protected float MaxDistance => maxDistance;
    }
}
