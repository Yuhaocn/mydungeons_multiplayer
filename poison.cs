using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;
public class poison : NetworkBehaviour {

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     Object.Destroy(this.gameObject,5) ;
    }
        private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player")
        {
            print("hit player");
            other.GetComponentInChildren<status>().playerdamage(5);

        }
    }
}
