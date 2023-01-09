using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VelocityInteractable : XRGrabInteractable
{
    private ControllerVelocity controllerVelocity = null;
    public OVRInput.Controller controller;
    private MeshRenderer meshRenderer = null;
    public Vector3 velocity;
    private Rigidbody rb;

    protected override void Awake()
    {
        base.Awake();
        meshRenderer = GetComponent<MeshRenderer>();
        controller = OVRInput.Controller.None;
        rb = GetComponent<Rigidbody>();
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
        ApplyVelocityAtUngrab();
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (isSelected)
        {
            //UpdateColorBasedOnVelocity();
            //print($"{controllerVelocity} | {controllerVelocity.Velocity}");
        }
    }

    private void UpdateColorBasedOnVelocity()
    {
        Color color = new(velocity.x, velocity.y, velocity.z);
        meshRenderer.material.color = color;
    }

    private void FixedUpdate()
    {
        velocity = OVRInput.GetLocalControllerVelocity(controller);
        var velocityV2 = OVRInput.GetLocalControllerAngularVelocity(controller);
        var velocityV3 = OVRInput.GetLocalControllerVelocity(controller) + OVRInput.GetLocalControllerAngularVelocity(controller);
        print($"VelocityV1 {velocity} | VelocityV2 {velocityV2} | VelocityV3 {velocityV3} ");
        // Debug.Log($"Speed: {string.Format("0:0.00", speed)}");
    }
    private void ApplyVelocityAtUngrab() => rb.velocity = velocity * 2;
}
