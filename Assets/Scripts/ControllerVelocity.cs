using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerVelocity : MonoBehaviour
{
    public InputActionProperty velocityProperty;
    public string controllerHand = "none";
    public OVRInput.Controller controller;

    public Vector3 Velocity { get; private set; } = Vector3.zero;

    private void Start()
    {
        if (controllerHand.Equals("none")) controller = OVRInput.Controller.None;
        else if (controllerHand.Equals("leftTouch")) controller = OVRInput.Controller.LTouch;
        else if (controllerHand.Equals("rightTouch")) controller = OVRInput.Controller.RTouch;

    }

    private void Update()
    {
        Velocity = velocityProperty.action.ReadValue<Vector3>();
    }

}
