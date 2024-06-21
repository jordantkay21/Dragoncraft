using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Dragoncraft
{
    //Attribute to create a CustomEditor for the specified class (LevelData)
    [CustomEditor(typeof(LevelData))]
    public class LevelDataEditor : Editor
    {
        /// <summary>
        /// Overriding the OnInspectorGUI allows us to add custom code so the rendered GUI will be drawn as we define it using the defined methods to modify the ScriptableObjects data as we interact with the cutom editor
        /// </summary>
        public override void OnInspectorGUI()
        {
            
            LevelData levelData = (LevelData)target;

            AddLevelDetails(levelData);
            AddLevelSlots(levelData);
            AddButtonInitialize(levelData);
            AddButtonUpdate(levelData);
        }

        /// <summary>
        /// provides a convenient way to edit and configure properties of a LevelData object within the Unity Editor environment by presenting custom fields and sliders for modifying LevelData properties such as Configuration, Columns, and Rows
        /// </summary>
        /// <param name="levelData">LevelData ScriptableObject wanting to be configured</param>
        private void AddLevelDetails(LevelData levelData)
        {
            //This line adds an object field to the Unity Editor interface labeled "Level:". It allows the user to assign an object of type LevelConfiguration to the Configuration property of the levelData object.
            levelData.Configuration = EditorGUILayout.ObjectField("Level: ", levelData.Configuration, typeof(LevelConfiguration), false) as LevelConfiguration;

            //These lines create integer sliders in the Unity Editor labeled "Columns:" and "Rows:", allowing the user to adjust the Columns and Rows properties of the levelData object.
            levelData.Columns = EditorGUILayout.IntSlider("Columns: ", levelData.Columns, 1, 25);
            levelData.Rows = EditorGUILayout.IntSlider("Rows: ", levelData.Rows, 1, 25);
        }

        /// <summary>
        /// designed to assist the editing and configuration of LevelSlot objects within a grid layout defined by Rows and Columns in the Unity Editor interface. 
        /// It utilizes nested loops to iterate through each position in the grid, displays an enum popup for selecting LevelItemType for each slot, 
        /// and updates the corresponding slot object's ItemType property based on user selection.
        /// </summary>
        /// <param name="levelData">LevelData ScriptableObject wanting to be configured</param>
        private void AddLevelSlots(LevelData levelData)
        {
            //This line displays a static label in the Unity Editor interface, informing the user about the content that follows
            EditorGUILayout.LabelField("Level Item per position: ");

            //These nested loops iterate through each position (x, y) in a grid defined by Rows and Columns in the levelData object
            // Outer Loop (x) iterates over the rows of the grid (levelData.Rows).
            for (int x=0; x < levelData.Rows; x++) 
            {
                //Begins a horizontal group of GUI controls in the Unity Editor interface
                GUILayout.BeginHorizontal();
                //Inner Loop (y) iterates over the columns of the grid
                for (int y=0; y < levelData.Columns; y++)
                {
                    //retrieves a LevelSlot object from the Slots collection within levelData at the current (x, y) position
                    LevelSlot slot = FindLevelSlot(levelData.Slots, x, y);
                    //displays a dropdown list of enum values (LevelItemType in this case) and allows the user to select an item type for the current slot
                    slot.ItemType = (LevelItemType)EditorGUILayout.EnumPopup(slot.ItemType);
                }
                //Ends the horizontal group of GUI controls
                GUILayout.EndHorizontal();
            }
        }

        /// <summary>
        /// The FindLevelSlot method is used to find or create a LevelSlot object at specific coordinates (x, y) within a list of slots (slots). 
        /// If a slot matching the coordinates already exists in the list, it returns that slot. 
        /// If not, it creates a new LevelSlot with default settings (LevelItemType.None) for the specified coordinates, adds it to the list, and then returns this new slot. 
        /// </summary>
        /// <param name="slots">list of LevelSLot Objects</param>
        /// <param name="x">integer representing coordinate x within the grid</param>
        /// <param name="y">integer representing coordinate y within the grid</param>
        /// <returns>either a LevelSlot that is found to match the cooridinates or a newly created LevelSlot</returns>
        private LevelSlot FindLevelSlot(List<LevelSlot> slots, int x, int y)
        {
            //This line uses the Find method of the List<LevelSlot> (slots) to locate a LevelSlot object where the coordinates (Coordinates.x and Coordinates.y) match the given (x, y) coordinates
            LevelSlot slot = slots.Find(i => i.Coordinates.x == x && i.Coordinates.y == y);

            if (slot == null)
            {
                //Creates a new LevelSlot instance configuring it with the included parameters
                slot = new LevelSlot(LevelItemType.None, new Vector2Int(x, y));
                //Adds newly created LevelSlot to the List<LevelSlot> (slots)
                slots.Add(slot);
            }

            return slot;
        }

        private void AddButtonInitialize(LevelData levelData)
        {
            if (GUILayout.Button("Initialize"))
                Initialize(levelData);
        }

        private void Initialize(LevelData levelData)
        {
            levelData.Slots.Clear();
            for (int x = 0; x < levelData.Rows; x++)
                for (int y = 0; y < levelData.Columns; y++)
                {
                    LevelSlot levelSlot = new LevelSlot(LevelItemType.None, new Vector2Int(x, y));

                    levelData.Slots.Add(levelSlot);
                }
        }

        private void AddButtonUpdate(LevelData levelData)
        {
            if (GUILayout.Button("Update"))
            {
                EditorUtility.SetDirty(levelData);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }
}
