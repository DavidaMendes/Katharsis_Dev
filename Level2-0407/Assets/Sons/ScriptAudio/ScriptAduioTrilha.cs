using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAduioTrilha : MonoBehaviour
{
    public AudioSource audioSourceTrilhaMenu;
    public AudioClip [] musicasMenu;
    void Start()
    {
        AudioClip musica = musicasMenu[0];
        audioSourceTrilhaMenu.clip = musica;
        audioSourceTrilhaMenu.loop = true;
        audioSourceTrilhaMenu.Play();

    }

    // Update is called once per frame
    void Update()
    {
        audioSourceTrilhaMenu.loop = true;
    }
}
