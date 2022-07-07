using System;
using UnityEngine;

namespace HsRm.JuLu.Core.Collectables
{
    [CreateAssetMenu(fileName = "CollectableItem", menuName = "ScriptableObjects/Collectable Item", order = 1)]
    public class CollectableItem : ScriptableObject
    {
        [SerializeField] private string titel = string.Empty;
        public string Name => titel;

        //public string getName()
        //{
        //    return Name;
        //}
    }
}
