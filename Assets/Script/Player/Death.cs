using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    public static Death instance;

    private void Awake() //gere la mort du player
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void Update()
    {
        if (Health.instance.Dead == true)
        {
            PlayerMovement.instance.enabled = false;

            PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;

            PlayerMovement.instance.bc.enabled = false;

            StartCoroutine(DeathDelay());
        }
    }

    public IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("DeathMenu");
    }
}
