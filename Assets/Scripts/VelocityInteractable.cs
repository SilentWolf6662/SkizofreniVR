using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VelocityInteractable : XRGrabInteractable
{
    private ControllerVelocity controllerVelocity = null;
    public OVRInput.Controller controller;
    private MeshRenderer meshRenderer = null;

    protected override void Awake()
    {
        base.Awake();
        meshRenderer = GetComponent<MeshRenderer>();
        controller = OVRInput.Controller.None;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        controllerVelocity = args.interactorObject.transform.GetComponent<ControllerVelocity>();
        controller = controllerVelocity.controller;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        controllerVelocity = null;
        controller = OVRInput.Controller.None;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (isSelected)
        {
            UpdateColorBasedOnVelocity();
            //print($"{controllerVelocity} | {controllerVelocity.Velocity}");
        }
    }

    private void UpdateColorBasedOnVelocity()
    {
        Vector3 velocity = controllerVelocity ? controllerVelocity.Velocity : Vector3.zero;
        Color color = new(velocity.x, velocity.y, velocity.z);
        meshRenderer.material.color = color;
    }

    public GameObject RightHandAnchor;
    private Vector3 lastPosition;

    private void FixedUpdate()
    {
        var velocity = OVRInput.GetLocalControllerAngularVelocity(controller);
        print($"Velocity {velocity}");
        // Debug.Log($"Speed: {string.Format("0:0.00", speed)}");

    }
}
