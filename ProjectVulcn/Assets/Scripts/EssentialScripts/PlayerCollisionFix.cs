using UnityEngine;
using Unity.XR.CoreUtils;

public class PlayerCollisionFix : MonoBehaviour
{
    private CharacterController thePlayer;
   private XROrigin playerXrOrigin;

    void Start()
    {
        thePlayer = GetComponent<CharacterController>();
        playerXrOrigin= GetComponent<XROrigin>();
        
    }
    void FixedUpdate()
    {
        thePlayer.height = playerXrOrigin.CameraInOriginSpaceHeight + 0.15f;

        Vector3 playerCenterPoint = transform.InverseTransformPoint(playerXrOrigin.Camera.transform.position);

        thePlayer.center = new Vector3(playerCenterPoint.x, thePlayer.height / 2 + thePlayer.skinWidth , playerCenterPoint.z);

        //thePlayer.Move(new Vector3(0.001f, -0.001f, 0.001f));
        //thePlayer.Move(new Vector3(-0.001f, 0.001f, -0.001f));

    }

   
}
