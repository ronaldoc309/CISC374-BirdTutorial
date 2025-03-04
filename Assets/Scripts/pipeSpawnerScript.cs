using UnityEngine;
using System.Collections;

public class pipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 3;
    private float timer = 0;
    public float heightOffset = 10;

    void Start()
    {
        spawnPipe();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Instantiate pipe
        GameObject newPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        
        // Set initial scale to zero (invisible)
        newPipe.transform.localScale = Vector3.zero;
        
        // Animate to full size
        StartCoroutine(ScalePipe(newPipe.transform));
    }

    // Coroutine to animate pipe scaling
    IEnumerator ScalePipe(Transform pipeTransform)
    {
        float duration = 0.5f; // Animation duration
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            pipeTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, elapsedTime / duration);
            yield return null;
        }

        pipeTransform.localScale = Vector3.one; // Ensure it reaches full size
    }
}
