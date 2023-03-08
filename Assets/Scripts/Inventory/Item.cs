using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item/item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public GameObject itemPrefab;
    public ItemType itemType;

    public enum ItemType
    {
        StaminaItem,
        EscapeItem
    }
    //public abstract void useItem();
}

//public sealed class EscapeItem : Item
//{
//    public int count = 1;
//    Item item;
//     public override void useItem()
//    {
//        //ActionController action = targetObject.GetComponent<ActionController>();
//      //  inventory = targetObject.GetComponent<InventoryCheck>();

////if(action.gameObject.tag == "Escaped_Item")
////inventory.Acquireitem(item, count =1);

//    }
//}

//public sealed class StaminaItem : Item
//{
//    public int Amount;
//    public override void useItem()
//    {
////ActionController action = targetObject.GetComponent<ActionController>();
////Stamina stamina = GetComponent<Stamina>();

////if(action.gameObject.tag =="Stamina_Item")
//       // stamina.GetPlusCurrentHP(Amount); 

//    }
//}