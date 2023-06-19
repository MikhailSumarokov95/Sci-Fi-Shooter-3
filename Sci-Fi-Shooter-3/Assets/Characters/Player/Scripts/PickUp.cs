using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Medicine Chest"))
        {
            var health = GetComponent<HealthPoints>();
            health.TakeHealth(health.MaxHealth);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("PartSpaceShip"))
        {
            Progress.SetNumberPartsFoundShip(Progress.GetNumberPartsFoundShip() + 1);
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("Ammunition"))
        {
            other.GetComponent<AmmunitionShop>().ReplenishAmmunition();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
    }
}
