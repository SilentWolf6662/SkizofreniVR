using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VelocityInteractable : XRGrabInteractable
{
    private ControllerVelocity controllerVelocity = null;
    private MeshRenderer meshRenderer = null;

    protected override void Awake()
    {
        base.Awake();
        meshRenderer = GetComponent<MeshRenderer>();    
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        controllerVelocity = args.interactorObject.transform.GetComponent<ControllerVelocity>();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        controllerVelocity = null;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (isSelected)
        {
            UpdateColorBasedOnVelocity();
        }
    }

    private void UpdateColorBasedOnVelocity()
    {
        print($"{controllerVelocity} | {controllerVelocity.Velocity}");
        Vector3 velocity = controllerVelocity ? controllerVelocity.Velocity : Vector3.zero;
        Color color = new(velocity.x, velocity.y, velocity.z);
        meshRenderer.material.color = color;
    }
}
