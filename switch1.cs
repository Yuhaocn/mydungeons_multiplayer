using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;

public class switch1 : NetworkBehaviour
{
    public static bool gameispause = true;
    public GameObject skilltreeui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
      void FixedUpdate () {
 
        if (!IsOwner) {
            return;
        }
 
        if (Input.GetKeyDown(KeyCode.E)) {
            CmdSwitch (1);
        }
        if (Input.GetKeyDown (KeyCode.Escape)) {
 
            CmdSwitch (2);
        }
 
    }   
    public void CmdSwitch (int objectNumber) {
 
        Switch (objectNumber);
        SwitchClientRpc (objectNumber);
 
    }
 
    [ClientRpc]
    void SwitchClientRpc (int objectNumber) {
 
        Switch (objectNumber);
 
    }
 
    public void Switch (int objectNumber) {
 
        //Activate the selected object, deactivate the others
        if (objectNumber == 1) {
            skilltreeui.SetActive (true);
        }
        if (objectNumber == 2) {
            skilltreeui.SetActive (false);
        }
 
    }
}
