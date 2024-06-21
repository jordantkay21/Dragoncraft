using System;
using UnityEngine;

namespace Dragoncraft
{
    [Serializable]
    public class LevelSlot
    {
        
        public LevelItemType ItemType;
        public Vector2Int Coordinates;

        /// <summary>
        /// Defines *this* level slot
        /// </summary>
        /// <param name="type">Item Type found within this Level Slot</param>
        /// <param name="coordinates">Where is the Level Slot located</param>
        public LevelSlot(LevelItemType type, Vector2Int coordinates)
        {
            ItemType = type;
            Coordinates = coordinates;
        }
    }
}
