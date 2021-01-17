using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
    public static int CoinCount = 0;

    private AudioSource audioSource;
    private MeshRenderer mesh;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mesh = GetComponent<MeshRenderer>();

        Coin.CoinCount++;
    }

    private void OnDestroy()
    {
        Coin.CoinCount--;

        if(Coin.CoinCount <= 0)
        {
            // Win!
        }
    }

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 0, -Time.deltaTime * 25f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            mesh.enabled = false;
            StartCoroutine(playDingSound());
        }
    }

    private IEnumerator playDingSound()
    {
        audioSource.Play(0);

        yield return new WaitForSeconds(audioSource.clip.length);

        Destroy(gameObject);
    }
}
