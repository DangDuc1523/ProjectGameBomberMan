using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrease,
    }

    public ItemType type;

    private void OnItemPickup(GameObject player)
    {
        switch (type)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombController>().AddBomb();
                break;

            case ItemType.BlastRadius:
                player.GetComponent<BombController>().explosionRadius++;
                break;

            case ItemType.SpeedIncrease:
                player.GetComponent<MovementController>().speed++;
                break;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Item ({gameObject.name}) chạm vào {other.gameObject.name} tại vị trí {other.transform.position}");

        if (other.CompareTag("Player"))
        {
            OnItemPickup(other.gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            Destroy(gameObject);
            Debug.Log("💥 Item đã bị phá hủy bởi vụ nổ!");
        }
    }




    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Explosion"))
    //    {
    //        gameObject.SetActive(false);
    //        Debug.Log("Player đã chạm vào Enemy và chết");
    //    }
    //}
}
