using System;
using UnityEngine;

namespace HsRm.JuLu.Core.Collectables
{
    [CreateAssetMenu(fileName = "CollectableItem", menuName = "ScriptableObjects/Collectable Item", order = 1)]
    public class CollectableItem : ScriptableObject
    {
        [SerializeField] private string name = string.Empty;
        public string Name => name;
    }
}
