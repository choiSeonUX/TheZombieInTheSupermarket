using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCheck : MonoBehaviour
{
    public bool inventoryActivated = false;

    // �ʿ��� ������Ʈ
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotsParent;

    // ���Ե�.
    private Slot[] slots;

    // �ν��Ͻ� ���� Ŭ����
    [SerializeField]
    private Item[] itemAssets;
    private Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();

        // �ν��Ͻ� ����
        for (int i = 0; i < itemAssets.Length; i++)
        {
            itemDictionary.Add(itemAssets[i].itemName, Instantiate(itemAssets[i]));
        }
    }

    void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
                OpenInventory();
            else
                CloseInventory();
        }
    }

    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }
    public void AcquireItem(Item item, int count = 1)
    {
        for (int i = 0; i < slots.Length && count > 0; i++)
        {
            if (slots[i].item == null && item != null)
            {
                slots[i].AddItem(item, 1);
                --count;
            }

            if (i >= slots.Length-1)
                break;
        }
    }
}