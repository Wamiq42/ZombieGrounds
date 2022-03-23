using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourManager
{
    private float mouseX;
    private float mouseY;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 5.0f;
    private Vector3 moveDirection;
    private float mouseSensitivity = 100f;
    private float rotationXaxis = 0;
    private float rotationmaxLimit = 40.0f;
    private float rotationminLimit = -67.0f;
    private Transform playerTransform;
    private Transform bodyTransform;
    private CharacterController playerCharacterController;
    private PlayerPhysics playerPhysics;
    private InventoryManager playerInventory;
    private List<GameObject> guns;
    private Transform cameraTransform;

    public PlayerBehaviourManager()
    {
        playerInventory = new InventoryManager();
        playerPhysics = new PlayerPhysics();


    }

    

    public void SetCameraTransform(Transform cameraTransform)
    {
        this.cameraTransform = cameraTransform;
    }
    public void SetPlayerTransform(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }
    public void SetBodyTransform(Transform bodyTransform)
    {
        this.bodyTransform = bodyTransform;
    }
    public Transform GetBodyTransform()
    {
        return bodyTransform;
    }
    public void SetCharacterController(CharacterController characterController)
    {
        playerCharacterController = characterController;
    }
    public void SetGroundCheckTransform(Transform transform)
    {
        playerPhysics.SetGroundCheckTransform(transform);
    }
    public void SetGroundLayerMask(LayerMask layerMask)
    {
        playerPhysics.SetGroundLayerMask(layerMask);
    }
    public void SetGuns(List<GameObject> guns)
    {
        this.guns = guns;
    }




    public void NoGun()
    {
        playerInventory.gunEquip += EquippingGun;
        playerInventory.SetEquippedGun(EquippedGun.hands);
    }


    /*Camera Movement method
      * Gets the input Mouse that is movement of mouse along the axis,
      * mouse X for the horizontal and Mouse y for the vertical movement,
      * a variable "rotationXaxis" is taken to store the value of vertical movement of mouse,
      * rotationXaxis is later clamped for limiting the camera rotation at x-axis so 
      * player camera doesn't rotate to infinity. rotating to infinity kind of makes wierd behaviour breaks the game.
      * for clamping using Mathf.clamp which takes a value and min value and max value and return the clamped value,
      * if the given value gets higher than min or max limit the limit is returned.
      */
    public void MouseMovement()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationXaxis -= mouseY;
        rotationXaxis = Mathf.Clamp(rotationXaxis, rotationminLimit, rotationmaxLimit);

        //mouseY = Mathf.Clamp(mouseY, -rotationLimitatX, rotationLimitatX);

        playerTransform.Rotate(Vector3.up * mouseX);
        //cameraTransform.Rotate(Vector3.right * mouseY);
        //cameraTransform.localRotation = Quaternion.Euler(mouseY, 0, 0);
        bodyTransform.localRotation = Quaternion.Euler(rotationXaxis, 0, 0);
    }

    /*PlayerMovement
     * Basic player Movement using old unity input system.
     * using characterController move method to move in the given direction 
     * direction is obtained by getting horizontal input and vertical input and multiplying with 
     * transform right and forward -- right = (1,0,0) forward = (0,0,1);
     */
    public void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


      //moveDirection = Vector3.right * horizontalInput + Vector3.forward * verticalInput;
        moveDirection = (playerTransform.right * horizontalInput + playerTransform.forward * verticalInput).normalized;

        playerCharacterController.Move(moveDirection * speed * Time.deltaTime);
    }
    public void PlayerGravity()
    {
        playerCharacterController.Move(playerPhysics.Gravity() * Time.deltaTime);
    }
    public void EquipGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerInventory.SetEquippedGun(EquippedGun.AssaultRifle);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerInventory.SetEquippedGun(EquippedGun.pistol);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerInventory.SetEquippedGun(EquippedGun.hands);
        }
    }

    private void EquippingGun(EquippedGun equippedGun)
    {
        for (int i = 0; i < guns.Count; i++)
        {
            if ((int)equippedGun == i)
            {
                guns[i].SetActive(true);
                guns[i].transform.rotation = bodyTransform.rotation;
                SetBodyTransform(guns[i].transform);
                cameraTransform.SetParent(guns[i].transform);
            }
            else
            {
                guns[i].SetActive(false);
                //cameraTransform.SetParent(transform);
            }
        }
    }




    //Locks the cursor; 
    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


}
