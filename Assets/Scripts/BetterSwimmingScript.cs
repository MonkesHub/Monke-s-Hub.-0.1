using GorillaLocomotion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BetterSwimmingScript : MonoBehaviour
{

    private InputDevice LeftControllerDevice;
    private InputDevice RightControllerDevice;
    private Vector3 LeftControllerVelocity;
    private Vector3 RightControllerVelocity;
    private Rigidbody playerRigidBody;
    private Vector3 swimVelocity;
    public LayerMask whatIsWater;
    public float radius = 0.25f;
    public float swimMultiplier = 1;
    //public bool canSwim => Physics.OverlapSphere(transform.position, radius, whatIsWater).Length > 0;
    public bool canSwim = false;

    // Start is called before the first frame update
    private void Start()
    {
        LeftControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        RightControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        playerRigidBody = Player.Instance.GetComponent<Rigidbody>();
    }


    private void Awake() => gameObject.layer = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other == Player.Instance.bodyCollider)
        {
            Debug.Log("Entered gravity zone");
            playerRigidBody.useGravity = false;
            canSwim = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == Player.Instance.bodyCollider)
        {
            Debug.Log("Exited gravity zone");
            playerRigidBody.useGravity = true;
            canSwim = false;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        LeftControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        RightControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        LeftControllerDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out LeftControllerVelocity);
        RightControllerDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out RightControllerVelocity);
        swimVelocity = new Vector3((((LeftControllerVelocity.x + RightControllerVelocity.x) / 2) * swimMultiplier), ((LeftControllerVelocity.y + RightControllerVelocity.y) / 2 * swimMultiplier), ((LeftControllerVelocity.z + RightControllerVelocity.z) / 2) * swimMultiplier);
        if (canSwim)
        {
            playerRigidBody.AddForce(-swimVelocity);
        }
    }
}