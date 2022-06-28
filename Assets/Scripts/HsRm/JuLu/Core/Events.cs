using HsRm.JuLu.Core.Collectables;
using HsRm.JuLu.Core.Interactables;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HsRm.JuLu.Core
{
    [Serializable] public class InteractableEvent : UnityEvent<Interactable> {}
    [Serializable] public class CollectableEvent : UnityEvent<Collectable> {}
    [Serializable] public class ColliderEvent : UnityEvent<Collider> {}
    [Serializable] public class IntEvent : UnityEvent<int> {}
    [Serializable] public class FloatEvent : UnityEvent<float> {}
    [Serializable] public class BoolEvent : UnityEvent<bool> {}
}
