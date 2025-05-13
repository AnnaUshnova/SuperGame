using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowMouse : MonoBehaviour
{
    public float speed = 0.11f;
    public float rotationSpeed = 10f;
    public float min_dist = 0.7f;
    public float max_dist = 99f;


    SpriteRenderer mySpriteRenderer;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 targetPosition =  GetMouseWorldPosition();

        Vector2 direction = targetPosition - transform.position;

        float dist = direction.magnitude;

        if (dist > min_dist)
        {
            RotateTowardsTarget(direction);

            transform.position = Vector2.MoveTowards(transform.position, Vector2.Lerp(transform.position, targetPosition, (Mathf.Clamp01((dist + min_dist) / max_dist))), speed * Time.deltaTime);
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = transform.position.z - Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    void RotateTowardsTarget(Vector3 direction)
    {
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (Mathf.Abs(transform.eulerAngles.z) > 90 && !mySpriteRenderer.flipY)
        {
            mySpriteRenderer.flipY = true;
        }
        if (Mathf.Abs(transform.eulerAngles.z) <= 90 && mySpriteRenderer.flipY) {
            mySpriteRenderer.flipY = false;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}