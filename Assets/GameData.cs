using UnityEngine;

[System.Serializable]
public class GameItem
{
    public string itemName;
    public Sprite itemImage;
}

[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
public class GameData : ScriptableObject
{
    public GameItem[] items;
}