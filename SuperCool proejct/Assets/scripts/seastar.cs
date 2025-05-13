using UnityEngine;

public class seastar : MonoBehaviour
{
    public float speed = 1;
    public float death_dist = 101;

    Vector3 dir;

    void Start()
    {
        dir = GameObject.FindGameObjectsWithTag("Player")[0].transform.position - transform.position;
        dir.z = 0;
        dir = dir.normalized;
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

        if (transform.position.magnitude > death_dist)
        {
            Destroy(this.gameObject);
        }
    }
}
