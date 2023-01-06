using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class status : NetworkBehaviour
{
    AudioSource source;
    public float health = 100;
    public float mana = 100;
    public Image healthbar;
    public Image manabar;
    public Image expbar;
    public float regen = 2f;
    public GameObject player;
    public GameObject tutorial;
    public float exptotal=0;
    public float max=100;
    public float level=1;
    public float skillpointcount=0;
    public static bool gameispause = true;
    public int basedamage=1;
    public GameObject mainui;
    public GameObject skilltreeui;
    [SerializeField] Text gameover;
    [SerializeField] Text exp;
        [SerializeField] Text damage;
    [SerializeField] Text skillpoint;
    [SerializeField] Button restartb;
    [SerializeField] Button skill1;
    [SerializeField] Button skill2;
    [SerializeField] Button skill3;
    [SerializeField] Button skill4;
    [SerializeField] Button skill5;
    // Start is called before the first frame update
    void Start()
    {
        if (!IsLocalPlayer)
        {
            mainui.SetActive(false);
            return;
        }
        gameover.enabled=false;
        restartb.interactable = false;
        source= GetComponent<AudioSource>();
        exp.text = 0.ToString();
        skillpoint.text = 0.ToString();
        skill2.interactable = false;
        skill3.interactable = false;
        skill4.interactable = false;
        skill5.interactable = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(exptotal>100){
            level+=1;
            skillpointcount+=1;
            exptotal=0;
            health=max;
            mana=max;
            basedamage+=1;
        }
        damage.text = basedamage.ToString();
        exp.text = level.ToString();
        skillpoint.text = skillpointcount.ToString();
        expbar.fillAmount = exptotal/100;
       healthbar.fillAmount = health/max;
        manabar.fillAmount = mana/max;
        if(health<max){
            health+=regen*Time.deltaTime;
        }
                if(mana<max){
            mana+=regen*Time.deltaTime;
        }
        if(health<=0){
            player.GetComponent<PlayerController>().froze=true;
            regen=0;
            gameover.enabled=true;
            restartb.interactable = true;
        }
        
    }
    public void playerdamage(float damage){
        source.Play();
        health -=damage;
        healthbar.fillAmount = health/max;
    }
        public void manause(float used){
        mana -=used;
        manabar.fillAmount = mana/max;
    }
    public void getexp(float increase){
        exptotal +=increase;

    }
    public void restart(){
        SceneManager.LoadScene("Auth");;
    }
            public void skill1c(){
                if(skillpointcount>0){
                 skillpointcount -=1;
                 regen+=2f;
            skill1.interactable = false;
        skill2.interactable=true;
        skill3.interactable=true;   
                }
            

    }
                public void skill2c(){
                     if(skillpointcount>0){
                        basedamage+=1;
            skillpointcount -=1;
            skill2.interactable = false;
        skill4.interactable=true;}

    }
                    public void skill3c(){
                         if(skillpointcount>0){
                            max+=50;
            skillpointcount -=1;
            skill3.interactable = false;
        skill5.interactable=true;}

    }
    
                    public void skill4c(){
                         if(skillpointcount>=2){
                            basedamage+=2;
            skillpointcount -=2;
            skill4.interactable = false;
        }

    }
    
                    public void skill5c(){
                         if(skillpointcount>=2){
                            max+=100;
            skillpointcount -=2;
            skill5.interactable = false;
        }
        

    }
    public void tutorialclose(){
            tutorial.SetActive(false);
        }

    
}
