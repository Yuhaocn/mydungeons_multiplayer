using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class pickup : NetworkBehaviour
{
    public AudioSource source;

    public int gain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {enabled = IsServer;            
            if (!enabled)
            {
                return;
            }
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player")
        {
            other.GetComponentInChildren<status>().getexp(gain);
            source.Play();
            Destroy(gameObject,source.clip.length);

        }
    }
}
