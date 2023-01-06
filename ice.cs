using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;
public class ice : NetworkBehaviour {
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
     Object.Destroy(this.gameObject,5) ;
    }
        private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "enemy")
        {
            GameObject player = GameObject.FindWithTag("Player");
            other.GetComponentInParent<enemyai>().takedamage(player.GetComponentInChildren<status>().basedamage*2+5);

        }
                if(other.transform.tag == "spider")
        {
            GameObject player = GameObject.FindWithTag("Player");
            other.GetComponentInParent<spiderai>().takedamage(player.GetComponentInChildren<status>().basedamage*2+5);

        }
    }
}
