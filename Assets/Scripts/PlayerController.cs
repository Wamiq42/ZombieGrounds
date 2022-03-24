using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerBehaviourManager playerManager;

    
    public CharacterController playerCharController;

    public Transform cameraTransform;
    public Transform playerTransform;
    public Transform bodyTransform;
    public Transform groundCheckTransform;
    public LayerMask groundLayerMask;
    public List<GameObject> guns;
   


    // Start is called before the first frame update
    void Awake()
    {
        
        
        playerManager = new PlayerBehaviourManager();
      
        playerManager.SetGroundCheckTransform(groundCheckTransform);
        playerManager.SetGroundLayerMask(groundLayerMask);
        playerManager.SetPlayerTransform(playerTransform);
        playerManager.SetBodyTransform(bodyTransform);
        playerManager.SetCharacterController(playerCharController);
        playerManager.SetCameraTransform(cameraTransform);
        playerManager.SetGuns(guns);
        playerManager.CursorLock();
        playerManager.NoGun();

        
    }

    // Update is called once per frame
    void Update()
    {
        playerManager.MouseMovement();
        playerManager.PlayerMovement();
        playerManager.EquipGun();
        playerManager.FireGun();
       

    }
    void FixedUpdate()
    {
        playerManager.PlayerGravity();
    }

    





    //private void EquippingGun(EquippedGun equippedGun)
    //{
    //    for (int i = 0; i <guns.Count; i++)
    //    {
    //        if ((int)equippedGun == i)
    //        {
    //            guns[i].SetActive(true);
    //            guns[i].transform.rotation = playerInputManager.GetBodyTransform().rotation;
    //            playerInputManager.SetBodyTransform(guns[i].transform);
    //            cameraTransform.SetParent(guns[i].transform);
    //        }
    //        else
    //        {
    //            guns[i].SetActive(false);
    //            //cameraTransform.SetParent(transform);
    //        }
    //    }
    //}

}
