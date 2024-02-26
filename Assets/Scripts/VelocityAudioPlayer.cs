using System.Collections;
using UnityEngine;

public class VelocityAudioPlayer : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    // Adjust these parameters as needed
    public float minDistanceThreshold = 1f;
    public float maxDistanceThreshold = 10f;

    public float minPitch = 0.9f; // Minimum pitch value
    public float maxPitch = 1.1f; // Maximum pitch value

    private Vector3 startPosition;
    private float totalDistance;

    private void Start()
    {
        //audioSource = gameObject.AddComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = false;  // Set to true if you want continuous looping
        audioSource.playOnAwake = false;

        startPosition = transform.position;
        totalDistance = 0f;

        //StartCoroutine(CheckDistanceAndPlay());
    }

    private void OnEnable()
    {
        StartCoroutine(CheckDistanceAndPlay());
    }

    private IEnumerator CheckDistanceAndPlay()
    {
        while (true)
        {
            // Wait for one second
            yield return new WaitForSeconds(0.01f);

            // Calculate the distance moved during the last second
            Vector3 currentPosition = transform.position;
            currentPosition.y = startPosition.y; // Ignore the y axis
            totalDistance += Vector3.Distance(currentPosition, startPosition);
            startPosition = currentPosition;
            

            // Calculate the delay based on total distance moved
            float normalizedDistance = Mathf.Clamp01((totalDistance - minDistanceThreshold) / (maxDistanceThreshold - minDistanceThreshold));
            float delay = Mathf.Lerp(1f, 0.1f, normalizedDistance);  // Adjust the range of delays as needed

            // Play audio if enough distance has been moved
            if (totalDistance >= minDistanceThreshold)
            {
                Debug.Log("Play footstep");
                float randomPitch = Random.Range(minPitch, maxPitch);
                audioSource.pitch = randomPitch;
                audioSource.Play();
                totalDistance = 0f; // Reset total distance for the next evaluation
            }
        }
    }
}
