using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;
using Unity.Netcode;

public class enemyai : NetworkBehaviour {
    
    float hitpoints = 10;
     AudioSource source;
        NavMeshAgent agent;
            public Animator anim;
                float distance;
                public GameObject player;
                float minAttackDistance = 1.5f;
                float TimerForNextAttack, Cooldown,TimerForfindplayer;
                public GameObject exp;
                 public GameObject damage;
    // Start is called before the first frame update
    void Start()
    {
         Cooldown = 3;
         TimerForNextAttack = Cooldown;
         TimerForfindplayer=Cooldown;
        source = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
         agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        enabled = IsServer;            
            if (!enabled)
            {
                return;
            }
            if (TimerForfindplayer > 0)
  {
  TimerForfindplayer  -= Time.deltaTime;
  }
            if (TimerForfindplayer <=0){
            Transform player = FindClosestPlayer(50.0f);
        agent.destination = player.transform.position; 
        distance = Vector3.Distance(player.transform.position,transform.position);}
        if (TimerForNextAttack > 0)
  {
  TimerForNextAttack  -= Time.deltaTime;
  }
  else if (TimerForNextAttack <=0)
   {if (distance < minAttackDistance)
        {
            anim.SetBool("attack",true);
        }
   TimerForNextAttack = Cooldown;
   }
        
    }
     private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player")
        {
            print("hit player");
            other.GetComponentInChildren<status>().playerdamage(1);

        }
    }
    public Transform FindClosestPlayer(float range)
{
    // Get all the player objects in the scene
    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

    // Keep track of the closest player and the distance to it
    Transform closestPlayer = null;
    float closestDistance = float.PositiveInfinity;

    // Iterate over all the player objects
    foreach (GameObject player in players)
    {
        // Get the distance from this enemy to the player
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // If this player is closer than the previous closest player,
        // store it as the new closest player
        if (distance < closestDistance)
        {
            closestPlayer = player.transform;
            closestDistance = distance;
        }
    }

    // If the closest player is within the specified range, return it
    if (closestDistance <= range)
    {
        return closestPlayer;
    }
    // Otherwise, return null
    else
    {
        return null;
    }
}


    public void takedamage(int amount)
    {
        damage.transform.GetChild(0).GetComponent<TextMesh>().text=(amount).ToString();
        var number=Instantiate(damage,this.transform.position,player.transform.rotation);
        number.GetComponent<NetworkObject>().Spawn(true);
        hitpoints -= amount;
        source.Play();
        anim.SetBool("ishit",true);
        if(hitpoints <= 0)
        {
            anim.SetBool("isdead",true);
            agent.isStopped = true;
        }
        
    }
            void unflinch(){
        anim.SetBool("ishit",false);
    }
                void unattack(){
        anim.SetBool("attack",false);
    }
    void destory(){
        var expnet = Instantiate(exp,this.transform.position,Quaternion.identity);
        expnet.GetComponent<NetworkObject>().Spawn(true);
        this.transform.gameObject.SetActive(false);
        this.transform.gameObject.GetComponent<NetworkObject>().Despawn();
}
}
