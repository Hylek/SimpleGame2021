using UnityEngine;

public class Fireworks : MonoBehaviour
{
    private static GameObject[] fireworks;

    private void Start()
    {
        fireworks = GameObject.FindGameObjectsWithTag("Fireworks");
    }

    public static void Play()
    {
        if (fireworks.Length <= 0) return;

        foreach(GameObject go in fireworks)
        {
            go.GetComponent<ParticleSystem>().Play();
        }
    }
}
