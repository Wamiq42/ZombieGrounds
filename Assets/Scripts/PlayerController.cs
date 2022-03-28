using Photon.Pun;
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
    public GameManager gameManager;
    private PhotonView PV;


    // Start is called before the first frame update
    void Awake()
    {

        PV = GetComponent<PhotonView>();
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
        playerCharController.detectCollisions = true;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerManager.SetGameManager(gameManager);

    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.GetHealth() > 0 && PV.IsMine)
        {
            playerManager.MouseMovement();
            playerManager.PlayerMovement();
            playerManager.EquipGun();
            playerManager.FireGun();
        }
        else if(playerManager.GetHealth() < 0 && PV.IsMine)
        {
            gameManager.SetPlayerDead(true);
            Destroy(gameObject);
            
        }

        gameManager.healthText.text = "Health : " + playerManager.GetHealth();
        gameManager.ammoText.text = "Ammo : " + playerManager.GetAmmo();
     
    }
    void FixedUpdate()
    {
        playerManager.PlayerGravity();
    }


    public PlayerBehaviourManager GetPlayerManager()
    {
        return playerManager;
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
