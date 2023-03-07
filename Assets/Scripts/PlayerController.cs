using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    private float applySpeed;

    // 상태변수 
    private bool isRun = false; 





    // 카메라 민감도 
    [SerializeField]
    private float lookSensitivity;

    // 카메라 각도 
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    [SerializeField]
    private Camera theCamera;

    private Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        applySpeed = walkSpeed; 

    }

    private void Update()
    {
        TryRun();
        Move();
        CamreraRotation();
        CharcaterRotation(); 
        
    }
    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunngCancel();
        }

    }

    private void Running()
    {
        isRun = true;
        applySpeed = runSpeed; 
    }

    private void RunngCancel()
    {
        isRun = false;
        applySpeed = walkSpeed; 
    }
    private void Move()
    {
        float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * moveDirX;
        Vector3 moveVetrical = transform.forward * moveDirZ;

        Vector3 velocity = (moveHorizontal + moveVetrical).normalized * applySpeed;

        rigidbody.MovePosition(transform.position + velocity * Time.deltaTime); 
    }
    // 좌우 캐릭터 회전 
    private void CharcaterRotation()
    {
        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 characterRotationY = new Vector3(0f, yRotation, 0f) * lookSensitivity;
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(characterRotationY));
    }

    // 상하 카메라 회전 
    private void CamreraRotation()
    {
        float xRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRotation * lookSensitivity;
        currentCameraRotationX -= cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }
}
