using UnityEngine;
using UnityEngine.UI;

public class DetectProjectileCollision : MonoBehaviour
{
    [SerializeField] private int foodAmountToFeed;

    private Slider healthSlider; 

    private static int score = 0;

    private int eatenFoodCount;

    private void Start()
    {
        eatenFoodCount = 0;

        healthSlider = GetComponentInChildren<Slider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            Destroy(collider.gameObject);

            eatenFoodCount = Mathf.Clamp(eatenFoodCount + 1, 0, foodAmountToFeed);

            AdjustHealthSlider();

            if (isFed()) {

                score++;
                print("Score : " + score);

                Invoke(nameof(DestroyAnimal), 0.1f);
            }
        }
    }

    private bool isFed()
    {
        if (eatenFoodCount >= foodAmountToFeed) {

            return true;
        }

        return false;
    }

    private void AdjustHealthSlider()
    {
        healthSlider.value = (float) eatenFoodCount / foodAmountToFeed;
    }

    private void DestroyAnimal()
    {
        Destroy(gameObject);
    }
}
