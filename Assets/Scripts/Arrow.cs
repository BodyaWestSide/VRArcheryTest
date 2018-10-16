using UnityEngine;

public class Arrow : MonoBehaviour, IPoolable
{
    [SerializeField]
    private Rigidbody arrowHeadRB;

    private void Start()
    {
        Spawn(transform);
    }

    public void Spawn(Transform t)
    {
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.rotation = Quaternion.identity;

        arrowHeadRB.isKinematic = true;
        arrowHeadRB.velocity = Vector3.zero;
        arrowHeadRB.angularVelocity = Vector3.zero;
        arrowHeadRB.rotation = Quaternion.identity;

        transform.position = t.position;
        transform.rotation = t.rotation;
    }

    public void ArrowReleased(float velocity)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        arrowHeadRB.isKinematic = false;
        arrowHeadRB.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
    }
}
