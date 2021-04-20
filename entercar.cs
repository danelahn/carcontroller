using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class entercar : MonoBehaviour
{
    public GameObject controls;
    public CarController carScript;
    public ParticleSystemBehavior boosterScript;
    public ParticleSystemBehavior boosterScript2;
    public cameraController cameraScript;
    public RigidbodyFirstPersonController playerScript;
    public HeadBob playerCamScript;
    public Camera carCam2;
    public GameObject Player;
    public GameObject crosshair;
    public bool inCar;
    // Start is called before the first frame update
    void Start()
    {
        carScript = carScript.GetComponent<CarController>();
        boosterScript = boosterScript.GetComponent<ParticleSystemBehavior>();
        cameraScript = cameraScript.GetComponent<cameraController>();
        playerScript = playerScript.GetComponent<RigidbodyFirstPersonController>();
        playerCamScript = playerCamScript.GetComponent<HeadBob>();
        

        playerCamScript.enabled = true;
        carScript.enabled = false;
        boosterScript.enabled = false;
        boosterScript2.enabled = false;
        cameraScript.enabled = false;
        playerScript.enabled = true;
        carCam2.enabled = false;
        Player.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            controls.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                inCar = !inCar;
                if (inCar)
                {
                    carScript.enabled = true;
                    boosterScript.enabled = true;
                    boosterScript2.enabled = true;
                    playerScript.enabled = true;
                    cameraScript.enabled = true;
                    playerCamScript.enabled = false;
                    crosshair.SetActive(false);
                    Player.SetActive(false);
                }

                if (!inCar) 
                {
                    Player.SetActive(true);
                    carScript.enabled = false;
                    boosterScript.enabled = false;
                    boosterScript2.enabled = false;
                    playerScript.enabled = false;
                    cameraScript.enabled = false;
                    playerCamScript.enabled = true;
                    crosshair.SetActive(true);

                }
                

            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            controls.SetActive(false);
        }
    }
}
