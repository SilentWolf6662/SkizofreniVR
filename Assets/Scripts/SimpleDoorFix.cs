using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkizofreniVR
{
    public class SimpleDoorFix : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidBody;

        private void Awake()
        {
            if (rigidBody == null) rigidBody = GetComponent<Rigidbody>();
        }

        public void DisableRBConstrains() => rigidBody.constraints = RigidbodyConstraints.FreezeAll;

        public void EnableRBConstrains() => rigidBody.constraints = RigidbodyConstraints.None;
    }
}