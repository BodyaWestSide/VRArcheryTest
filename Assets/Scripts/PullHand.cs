using UnityEngine;

public class PullHand : MonoBehaviour
{
    private GameObject currentArrow;
    private ObjectPool arrowPool;

    private void Awake()
    {
        arrowPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        currentArrow = GetArrow();
    }

    public void ReleaseArrow()
    {
        currentArrow = GetArrow();
    }

    private GameObject GetArrow()
    {
        var arrow = arrowPool.SpawnFromPool(transform);
        arrow.transform.parent = transform;
        arrow.transform.localRotation = Quaternion.identity;
        return arrow;
    }
}
