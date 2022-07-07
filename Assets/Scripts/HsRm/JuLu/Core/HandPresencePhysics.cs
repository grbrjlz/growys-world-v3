using UnityEngine;

namespace HsRm.JuLu.Core
{
    public class HandPresencePhysics : MonoBehaviour
    {
        public Transform target;
        private Rigidbody rb;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.maxAngularVelocity = 200;
        }

        void FixedUpdate()
        {
            rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

            Quaternion rotationDifference = (target.rotation * Quaternion.Inverse(transform.rotation));
            rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

            Vector3 rotationDifferenceInDegree =  angleInDegree * rotationAxis;

            rb.angularVelocity = (rotationDifferenceInDegree  * Mathf.Deg2Rad / Time.fixedDeltaTime);
        }
    }
}
