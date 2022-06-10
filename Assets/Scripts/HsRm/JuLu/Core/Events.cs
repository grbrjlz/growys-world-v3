using Content.Scripts.HsRm.JuLu.Core.Collectables;
using Content.Scripts.HsRm.JuLu.Core.Interactables;
using UnityEngine;
using UnityEngine.Events;

namespace Content.Scripts.HsRm.JuLu.Core
{
    public static class Events
    {
        [SerializeField]
        public class InteractableEvent : UnityEvent<Interactable> {}
        
        [SerializeField]
        public class CollectableEvent : UnityEvent<Collectable> {}
    }
}
