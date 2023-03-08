using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    [SerializeField]
    public Item item;
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private int itemCount = 4;  
  
    private void SetColor(float alpha)
    {
        Color color = itemImage.color;
        color.a = alpha;
        itemImage.color = color;
    }

    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemImage.sprite = item.itemImage;
    }

    public void SetSlotCount(int count)
    {
        itemCount += count;
        if (itemCount <= 4)
            ClearSlot();
    }  
    
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);
    }
}
