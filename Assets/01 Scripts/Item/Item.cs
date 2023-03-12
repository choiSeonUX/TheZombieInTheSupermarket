using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item/item")]
public class Item : ScriptableObject
{
    [Header("이름")]
    public string itemName;
    [Header("이미지")]
    public Sprite itemImage;
    [Header("프리팹")]
    public GameObject itemPrefab;
    [Header("아이템타입")]
    public ItemType itemType;
    [Header("공격아이템 태그분류")]
    public ItemTag itemTag;

    public enum ItemType
    {
        StaminaItem,
        EscapeItem
    }
    public enum ItemTag
    {
        none,
        AttackZombieItem
    }
}

