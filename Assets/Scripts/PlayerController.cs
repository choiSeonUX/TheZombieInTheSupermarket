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

    // ���º��� 
    private bool isRun = false; 





    // ī�޶� �ΰ��� 
    [SerializeField]
    private float lookSensitivity;

    // ī�޶� ���� 
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
    // �¿� ĳ���� ȸ�� 
    private void CharcaterRotation()
    {
        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 characterRotationY = new Vector3(0f, yRotation, 0f) * lookSensitivity;
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(characterRotationY));
    }

    // ���� ī�޶� ȸ�� 
    private void CamreraRotation()
    {
        float xRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRotation * lookSensitivity;
        currentCameraRotationX -= cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }
}
