using System.Collections.Generic;
using UnityEngine;
namespace Dragoncraft
{
    [CreateAssetMenu(menuName = "Dragoncraft/New Level")]
    public class LevelData : ScriptableObject
    {
        [Tooltip("data container to store the number of slots on the map")]
        public List<LevelSlot> Slots = new List<LevelSlot>();

        [Tooltip("Number of columns wanted within the grid of the map")]
        public int Columns;
        [Tooltip("Number of rows wanted within the grid of the map")]
        public int Rows;

        [Tooltip("reference to the LevelConfiguration ScriptableObject, which has the default configuration for Prefabs tha tcan be used to add in the level map")]
        public LevelConfiguration Configuration;
    }
}
