using UnityEngine;

public class KillSpike : MonoBehaviour
{
    public float damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(collision.gameObject);
        collision.GetComponent<PlayerHealth>().AddDamage(damage);
    }
}
