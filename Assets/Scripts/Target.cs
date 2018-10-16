using System.Collections;
using UnityEngine;

public abstract class Target : MonoBehaviour
{
    [SerializeField]
    protected Transform orbitCenter;

    [SerializeField]
    private float minRotationSpeed = 1f;

    [SerializeField]
    private float maxRotationSpeed = 3f;

    [SerializeField]
    private float minDistance = 10f;

    [SerializeField]
    private float maxDistance = 15f;

    [SerializeField]
    private float minHeight = 0.3f;

    [SerializeField]
    private float maxHeight = 2.5f;

    [SerializeField]
    private float hideTime = 0.1f;

    private float rotationSpeed;

    protected ScoreSystem scoreSystem;


    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private void Update()
    {
        transform.RotateAround(orbitCenter.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void Init(Transform center)
    {
        orbitCenter = center;
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        var distance = Random.Range(minDistance, maxDistance);
        var startAngle = Random.Range(0, 2 * Mathf.PI);
        var startHeight = Random.Range(minHeight, maxHeight);
        transform.position = new Vector3(distance * Mathf.Sin(startAngle), startHeight, distance * Mathf.Cos(startAngle));
        Debug.Log(transform.position);

        transform.position += orbitCenter.position;

        transform.LookAt(orbitCenter);

        float respawnTime = Random.Range(5, 30);
        Invoke("DelayRespawn", respawnTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Arrow>() != null)
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<Animator>().SetTrigger("WasHit");
            StartCoroutine(HideCoroutine());
        }
    }

    private IEnumerator HideCoroutine()
    {
        yield return new WaitForSeconds(hideTime);
        OnHit();
        Destroy(gameObject);
    }

    protected abstract void OnHit();

    private void DelayRespawn()
    {
        Init(orbitCenter);
    }
}