using Content.Scripts.HsRm.JuLu.Core.Collectables;
using Content.Scripts.HsRm.JuLu.Core.Interactables;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Scripts.HsRm.JuLu.Core.Commands.Raycaster
{
    public class UpdateRaycasterCommand : BaseRaycasterCommand
    {
        [SerializeField] private Image indicator;
        [SerializeField] private Color defaultColor = Color.white;
        [SerializeField] private Color interactColor = Color.yellow;
        [SerializeField] private Color collectColor = Color.green;
        [SerializeField] private Color lockedColor = Color.red;
        
        protected override void HandleHit(RaycastHit hit)
        {
            var transform = hit.transform;
            
            if (transform.TryGetComponent<Collectable>(out var collectable))
            {
                UpdateCursor(collectColor);
                DrawDebugRay(hit.distance, collectColor);
            }
            else if (transform.TryGetComponent<Interactable>(out var interactable))
            {
                UpdateCursor(interactColor);
                DrawDebugRay(hit.distance, interactColor);
            }
            else if (transform.TryGetComponent<InteractableSelector>(out var selector))
            {
                UpdateCursor(interactColor);
                DrawDebugRay(hit.distance, interactColor);
            }
            else
            {
                UpdateCursor(defaultColor);
                DrawDebugRay(hit.distance, defaultColor);
            }
        }

        protected override void HandleMiss()
        {
            DrawDebugRay(MaxDistance, defaultColor);
            UpdateCursor(defaultColor);
        }

        private void DrawDebugRay(float distance, Color color)
        {
            Debug.DrawRay(Ray.origin, Ray.direction * distance, color);
        }

        private void UpdateCursor(Color color)
        {
            indicator.color = color;
        }

        private void Update()
        {
            Execute();
        }
    }
}
