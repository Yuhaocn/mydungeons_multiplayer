using Unity.Netcode;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {
    [SerializeField] public float speed = 500;

    public Vector2 movementInput = Vector2.zero;
    Animator anim;
    
    public float forwardVelocity = 0;
    public float sidewaysVelocity = 10;
        public CharacterController Controller;
        public GameObject fire;
    public bool froze = false;


    private void Awake() {
        anim = GetComponentInChildren<Animator>();
    }
    IEnumerator frozep()
    {
        froze = true;
        yield return new WaitForSecondsRealtime(1);
        froze = false;
    }
    private void Update() { 
                anim.SetBool("attack",false);
        anim.SetBool("iceatk",false);
            float horizontal = Input.GetAxis("Horizontal")* Time.deltaTime * speed;
            float vertical = Input.GetAxis("Vertical")* Time.deltaTime * speed;
                       if(Input.GetMouseButtonDown(0)){
                        StartCoroutine(frozep()); 
                        }

            movementInput.x = Mathf.SmoothDamp(movementInput.x, Input.GetAxisRaw("Horizontal"), ref forwardVelocity, 0.15f);
            movementInput.y = Mathf.SmoothDamp(movementInput.y, Input.GetAxisRaw("Vertical"), ref sidewaysVelocity, 0.15f);
           
             anim.SetFloat("speed", movementInput.y * 8);
            anim.SetFloat("accx",movementInput.x * 2);
                    if(froze){
    movementInput.x=0;movementInput.y=0;
}
            if (vertical > 0.1 || vertical < -0.1 || horizontal > 0.1 || horizontal < -0.1)
      {
        // rotate player towards the camera forward.
        Vector3 eu = Camera.main.transform.rotation.eulerAngles;
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            Quaternion.Euler(0.0f, eu.y, 0.0f),
            2.0f * Time.deltaTime);
      }
            else
      {
      transform.Rotate(0.0f, movementInput.x *  100.0f * Time.deltaTime, 0.0f);
      }
    Controller.Move(transform.forward * movementInput.y *10 * Time.deltaTime);

    
    }


    public override void OnNetworkSpawn() {
        if (!IsOwner) Destroy(this);
    }
}