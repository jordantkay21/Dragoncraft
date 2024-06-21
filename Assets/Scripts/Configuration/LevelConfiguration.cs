using System.Collections.Generic;
using UnityEngine;

namespace Dragoncraft
{
    [CreateAssetMenu(menuName = "Dragoncraft/New Configuration")]
    public class LevelConfiguration : ScriptableObject
    {
        [Tooltip("data container used to store all level items avaiable to be configured ")]
        public List<LevelItem> LevelItems = new List<LevelItem>();

        /// <summary>
        /// searches through the LevelItems collection to find an element whose Type property matches the value stored in the type variable
        /// </summary>
        /// <param name="type"></param>
        /// <returns>the first matching element it finds</returns>
        public LevelItem FindByType(LevelItemType type)
        {
            return LevelItems.Find(item => item.Type == type);
        }
    }
}
