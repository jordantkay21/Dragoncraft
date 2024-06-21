using System;

namespace Dragoncraft
{
    /// <summary>
    /// Enum class used to define the item types avaiable with the game.
    /// Helper class used to build the LevelConfiguration ScriptableObject
    /// </summary>
    [Serializable]
    public enum LevelItemType
    {
        None,
        Tree,
        House,
        Rock
    }
}
