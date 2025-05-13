using UnityEngine;

public class spawner : MonoBehaviour
{
    public float radius = 111f;

    public float spawn_time = 60.0f;
    float timer = 0f;

    [SerializeField] GameObject enemy_pref;

    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= spawn_time)
        {
            timer = 0;

            spawn();
        }

    }

    void spawn()
    {
        float ang = Random.Range(0, 2 * Mathf.PI);



        GameObject new_enemy = Instantiate(
            enemy_pref,
            new Vector3(
                Mathf.Cos(ang),
                Mathf.Sin(ang),
                0
                ) * radius,
            transform.rotation
            );
    }
}
