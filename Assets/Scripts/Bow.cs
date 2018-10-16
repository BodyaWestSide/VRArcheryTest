using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField]
    private OVRInput.RawButton attachButton = OVRInput.RawButton.RIndexTrigger;

    [SerializeField]
    private Transform stringAttachPoint;

    [SerializeField]
    private Transform arrowStartPoint;

    [SerializeField]
    private Transform stringStartPoint;

    [SerializeField]
    private PullHand pullHand;

    [SerializeField]
    private float maxPullDistance = 0.33F;

    [SerializeField]
    private float velocityMultiplier = 20.0F;

    private Arrow attachedArrow = null;

    private bool IsArrowAttached { get { return attachedArrow != null; } }

    private bool IsAttachButtonDown { get { return OVRInput.GetDown(attachButton);  } }

    void OnTriggerStay(Collider other)
    {
        TryAttachArrow(other);
    }

    void OnTriggerEnter(Collider other)
    {
        
        TryAttachArrow(other);
    }

    void Update()
    {
        PullString();
    }

    private void TryAttachArrow(Collider other)
    {
        var arrow = other.GetComponent<Arrow>();
        Debug.Log(IsAttachButtonDown);
        if (CanAttach(arrow))
        {
            Debug.Log("triggerenter");
            attachedArrow = arrow;
            attachedArrow.transform.parent = stringAttachPoint.transform;
            attachedArrow.transform.localPosition = arrowStartPoint.transform.localPosition;
            attachedArrow.transform.rotation = arrowStartPoint.transform.rotation;
        }
    }

    private bool CanAttach(Arrow arrow)
    {
        return arrow != null && !IsArrowAttached && IsAttachButtonDown;
    }

    private void PullString()
    {
        if (IsArrowAttached)
        {
            float dist = GetPullDistance();
            stringAttachPoint.localPosition = stringStartPoint.localPosition + new Vector3(0f, dist, 0f);

            if (OVRInput.GetUp(attachButton))
            {
                Shoot(dist);
            }
        }
    }

    private float GetPullDistance()
    {
        Vector3 controllerLocalOffset = pullHand.transform.position - stringStartPoint.position;
        float projection = Vector3.Dot(controllerLocalOffset, -stringStartPoint.right);
        return Mathf.Clamp(projection, 0, maxPullDistance);
    }

    private void Shoot(float velocity)
    {
        Debug.Log("Shooting!!!");

        pullHand.ReleaseArrow();
        attachedArrow.transform.parent = null;

        attachedArrow.ArrowReleased(velocity * velocityMultiplier);
    
        stringAttachPoint.position = stringStartPoint.position;
        attachedArrow = null;
    }
}