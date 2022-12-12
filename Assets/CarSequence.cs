using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkizofreniVR
{
    public class CarSequence : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
        [SerializeField] private Transform[] sequenceWaypoints;

        private void Awake()
        {
            transform.position = sequenceWaypoints[0].position;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab)) Drive();
        }

        private void Drive()
        {
            transform.position = new Vector3(Mathf.Lerp(sequenceWaypoints[0].transform.position.x, sequenceWaypoints[sequenceWaypoints.Length-1].transform.position.x, speed), Mathf.Lerp(sequenceWaypoints[0].transform.position.y, sequenceWaypoints[sequenceWaypoints.Length - 1].transform.position.y, speed), Mathf.Lerp(sequenceWaypoints[0].transform.position.z, sequenceWaypoints[sequenceWaypoints.Length-1].transform.position.z, speed));
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i < sequenceWaypoints.Length; i++)
            {
                Gizmos.color = Color.yellow;
                Vector3 waypoint = new Vector3(sequenceWaypoints[i].transform.position.x, sequenceWaypoints[i].transform.position.y, sequenceWaypoints[i].transform.position.z);
                Gizmos.DrawSphere(waypoint, 0.2f);
            }
        }
    }
}
