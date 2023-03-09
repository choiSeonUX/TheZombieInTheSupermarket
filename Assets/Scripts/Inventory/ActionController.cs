using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionController : MonoBehaviour
{

    [SerializeField]
    private float range; // ���� ������ �ִ� �Ÿ�.

    private bool pickupActivated = false; // ���� ������ �� true.
    private RaycastHit hitInfo; // �浹ü ���� ����.

    // �ʿ��� ������Ʈ.
    [SerializeField]
    private TextMeshProUGUI actionText;

    public GameObject target { get; set; }

    void Update()
    {
        CheckItem();
        TryAction();
    }
    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CanPickUp();
        }

    }
    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                ItemPickUp itemPickUp = hitInfo.transform.GetComponent<ItemPickUp>();
                Item item = itemPickUp.item;
                Debug.Log(item.itemName + " ȹ���߽��ϴ�");


                Destroy(hitInfo.transform.gameObject);
                InfoDisappear();
            }
        }
    }

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range))
        {
            ItemPickUp itemPickUp = hitInfo.transform.GetComponent<ItemPickUp>();
            if (itemPickUp != null && (itemPickUp.item.itemType == Item.ItemType.EscapeItem || itemPickUp.item.itemType == Item.ItemType.StaminaItem))
            {
                ItemInfoAppear(itemPickUp.item.itemName);
            }
        }
        else

            InfoDisappear();
    }

    private void ItemInfoAppear(string itemName)
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = itemName + " ȹ�� " + "<color=yellow>" + "(E)" + "</color>";
    }
    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
}
