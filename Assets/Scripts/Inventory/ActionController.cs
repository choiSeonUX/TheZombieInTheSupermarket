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
////if (escapeItem != null) // EscapeItem 컴포넌트가 있는지 체크

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
//        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 " + "<color=yellow>" + "(E)" + "</color>";
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
    private float range; // 습득 가능한 최대 거리.

    private bool pickupActivated = false; // 습득 가능할 시 true.

    private RaycastHit hitInfo; // 충돌체 정보 저장.


    // 아이템 레이어에만 반응하도록 레이어 마스크를 설정.
    [SerializeField]
    private LayerMask layerMask;

    // 필요한 컴포넌트.
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
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득했습니다");
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
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 " + "<color=yellow>" + "(E)" + "</color>";
    }
    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
}