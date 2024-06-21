using System;
using UnityEngine;

namespace Dragoncraft
{
    /// <summary>
    /// Helper Script to build the LevelConfiguration ScriptableObject
    /// </summary>
    [Serializable]
    public class LevelItem
    {
        [Tooltip("Creates a dropdown list of available item types defined in the LevelItemType Enum Class")]
        public LevelItemType Type;
        public GameObject Prefab;
    }
}
