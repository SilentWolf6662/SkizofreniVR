using UnityEngine;
using UnityEngine.InputSystem;

namespace SkizofreniVR
{
    public class SimpleSlideDoorFix : MonoBehaviour
    {

        [SerializeField] private InputActionProperty velocityProperty;
        public Vector3 Velocity { get; private set; } = Vector3.zero;
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private bool Selected;

        private void Awake()
        {
            if (rigidBody == null) rigidBody = GetComponent<Rigidbody>();
        }

        public void SlideOpen() 
        { 
            
        }

        public void SelectObject()
        {
            Selected = true;
        }

        public void DeselectObject()
        {
            Selected = false;
        }
    }
}