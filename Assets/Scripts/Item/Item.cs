using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item/item")]
public class Item : ScriptableObject
{
    [Header("�̸�")]
    public string itemName;
    [Header("�̹���")]
    public Sprite itemImage;
    [Header("������")]
    public GameObject itemPrefab;
    [Header("������Ÿ��")]
    public ItemType itemType;

    public enum ItemType
    {
        StaminaItem,
        EscapeItem
    }
}

