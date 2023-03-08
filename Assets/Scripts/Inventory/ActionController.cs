using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//public class ActionController : MonoBehaviour
//{
//    [SerializeField]
//    private float range;

//    [SerializeField]
//    private TextMeshProUGUI actionText; 

//    private RaycastHit hitInfo;
//    private bool pickupActivated = false;

//    [SerializeField]
//    private LayerMask layerMask;
//    public GameObject targetObject { get; set; }
//    Item item;

//    private void Update()
//    {
//        CheckItem();
//        TryAction();
//    }

//    private void TryAction()
//    {
//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            CheckItem();
//            CanPickUp();
//        }
//    }

//    private void CanPickUp()
//    {

//        if (pickupActivated)            
//        {
//            if (hitInfo.transform != null)
//            {
//               // EscapeItem escapeItem = hitInfo.transform.GetComponent<EscapeItem>();
////if (escapeItem != null) // EscapeItem ������Ʈ�� �ִ��� üũ

//                  //  targetObject = hitInfo.transform.gameObject; 
//                  //  escapeItem.useItem(targetObject);
//                    Debug.Log(hitInfo.transform.tag);
//                  //  Destroy(hitInfo.transform.gameObject);
//                    InfoDisappear();

//            }
//        }
//    }

//    private void CheckItem()
//    {   
//        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
//        {
//            if(hitInfo.transform.tag == "Escape_Item" || hitInfo.transform.tag == "Stamina_Item")
//            {
//                ItemInfoAppear();
//            }
//        }
//        else
//            InfoDisappear();
//    }

//    private void ItemInfoAppear()
//    {
//        pickupActivated = true;
//        actionText.gameObject.SetActive(true);
//        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� " + "<color=yellow>" + "(E)" + "</color>";
//    }
//    private void InfoDisappear()
//    {
//        pickupActivated = false;
//        actionText.gameObject.SetActive(false);
//    }

//}
public class ActionController : MonoBehaviour
{

    [SerializeField]
    private float range; // ���� ������ �ִ� �Ÿ�.

    private bool pickupActivated = false; // ���� ������ �� true.

    private RaycastHit hitInfo; // �浹ü ���� ����.


    // ������ ���̾�� �����ϵ��� ���̾� ����ũ�� ����.
    [SerializeField]
    private LayerMask layerMask;

    // �ʿ��� ������Ʈ.
    [SerializeField]
     private TextMeshProUGUI actionText;

    Vector3 point1 = new Vector3(0, 0, 0);
    Vector3 point2 = new Vector3(100, 0, 0);
    private void Start()
    {
       
    }

    void Update()
    {
        //Debug.DrawRay(transform.position, point2, Color.red);
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }

    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                Debug.DrawRay(transform.position, point2, Color.red);
                Debug.DrawRay(transform.position, hitInfo.transform.position, Color.red); 
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ���߽��ϴ�");
                Destroy(hitInfo.transform.gameObject);
                InfoDisappear();
            }
        }
    }

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            
            if (hitInfo.transform.tag == "Escape_Item")
            {
                ItemInfoAppear();
            }
        }
        else
            InfoDisappear();
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� " + "<color=yellow>" + "(E)" + "</color>";
    }
    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
}