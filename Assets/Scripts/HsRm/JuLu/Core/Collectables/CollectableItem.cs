using System;
using UnityEngine;

namespace HsRm.JuLu.Core.Collectables
{
    public class CollectableItem : ScriptableObject
    {
        [SerializeField] private new string name = string.Empty;
        public string Name => name;
    }
}
