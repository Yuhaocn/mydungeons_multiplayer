using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class display : NetworkBehaviour {
    
    [SerializeField] Text wave;
    [SerializeField] Text win;
    [SerializeField] Text count;
    [SerializeField] Text counttxt;
    public GameObject WaveSpawner;
    public Button quit;
    public GameObject mainui;
    public int enemiesLeft;
    // Start is called before the first frame update
    void Start()
    {
        win.enabled=false;
        quit.interactable=false;
        count.enabled = false;
        counttxt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        wave.text=WaveSpawner.GetComponent<WaveSpawner>().currentWave.ToString();
        if(wave.text=="Wave11 (Wave)"){
                 GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
         enemiesLeft = enemies.Length;
         count.enabled=true;
         counttxt.enabled =true;
         count.text = enemiesLeft.ToString();
        }
        if(wave.text=="Wave11 (Wave)"&enemiesLeft==0){
            win.enabled=true;
            quit.interactable=true;

        }
    }
public void QuitGame()
{
    Application.Quit();
}
}
