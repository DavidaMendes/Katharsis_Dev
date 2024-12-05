using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallRotation : MonoBehaviour
{
    private bool playerInTrigger = false;
    private bool isRotated = false;
    private List<GameObject> walls;
    private List<Quaternion> originalRotations;
    private List<Quaternion> rotatedRotations;

    [SerializeField] private float rotationDuration = 1.0f;
    public AudioSource sound;

    private PlayerSwap camPlayer;
    private GameObject playerJulieta;

    void Start()
    {
        walls = new List<GameObject>(GameObject.FindGameObjectsWithTag("WallRotationUp"));
        originalRotations = new List<Quaternion>();
        rotatedRotations = new List<Quaternion>();

        foreach (GameObject wall in walls)
        {
            originalRotations.Add(wall.transform.rotation);
            rotatedRotations.Add(Quaternion.Euler(wall.transform.eulerAngles + new Vector3(0, 0, 90)));
        }

        camPlayer = FindAnyObjectByType<PlayerSwap>();
        playerJulieta = GameObject.Find("Julieta");
    }

    void Update()
    {
        // Apenas permite a rotação se a Julieta for o personagem ativo
        if (camPlayer != null && camPlayer.virtualCamera.Follow == playerJulieta.transform)
        {
            if (playerInTrigger && (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire2")))
            {
                sound.Play();
                StartCoroutine(RotateWallsSmoothly());
            }
        }
    }

    private IEnumerator RotateWallsSmoothly()
    {
        float elapsedTime = 0f;
        List<Quaternion> startRotations = new List<Quaternion>();

        foreach (GameObject wall in walls)
        {
            startRotations.Add(wall.transform.rotation);
        }

        List<Quaternion> targetRotations = isRotated ? originalRotations : rotatedRotations;

        while (elapsedTime < rotationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / rotationDuration);

            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].transform.rotation = Quaternion.Lerp(startRotations[i], targetRotations[i], t);
            }

            yield return null;
        }

        for (int i = 0; i < walls.Count; i++)
        {
            walls[i].transform.rotation = targetRotations[i];
        }

        isRotated = !isRotated;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Checa se a Julieta está no trigger
        if (col.CompareTag("Player") && col.transform == playerJulieta.transform)
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.transform == playerJulieta.transform)
        {
            playerInTrigger = false;
        }
    }
}
