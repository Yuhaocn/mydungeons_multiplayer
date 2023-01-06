using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Networking;

public class camerafollow : NetworkBehaviour {

  public GameObject cameraholder;

  public Vector3 mPositionOffset = new Vector3(0.0f, 2.0f, -2.5f);

  void LateUpdate()
  {
    
    CameraMove_Track();
  }

  void CameraMove_Track()
  {
    cameraholder.transform.position=transform.position+mPositionOffset;
  }
      public override void OnNetworkSpawn() {
        if (IsOwner) {
          cameraholder.SetActive(true);
        };
    }
}
