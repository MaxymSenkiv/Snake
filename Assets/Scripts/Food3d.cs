using UnityEngine;

public class Food3d : MonoBehaviour
{
    public BoxCollider2D FoodSpawnGridArea;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.FoodSpawnGridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        RandomizePosition();
    }
}
