using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class script_postproc_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Volume volume;
    private script_character_movement charAccess;
    Bloom bloom;
    Vignette vignette;
    private float internalDarkness;
    private bool bloomMod;
    public float upperBloom;
    public float normalBloom;
    ChromaticAberration chromaticAberration;
    void Start()
    {
        bloomMod = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        charAccess = player.GetComponent<script_character_movement>();
        volume.profile.TryGet<Vignette>(out vignette);
        volume.profile.TryGet<Bloom>(out bloom);
        volume.profile.TryGet<ChromaticAberration>(out chromaticAberration);


        internalDarkness = charAccess.weightOfDarkness;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(bloom.intensity.value);
        //vignette.intensity.value = Mathf.Sin(Time.deltaTime);
        //Debug.Log("infixedupdate");
        if (charAccess.weightOfDarkness != internalDarkness)
        {
           // Debug.Log("changing vignette");
            vignette.intensity.value = Mathf.Lerp(charAccess.weightOfDarkness / 15, internalDarkness, Time.deltaTime / 2);
            internalDarkness = charAccess.weightOfDarkness;
        }

        if (charAccess.hasLightRounds || charAccess.holdingLight)
        {
            bloomMod = true;
        }
        if (bloomMod)
        {
            chromaticAberration.intensity.value = Mathf.PingPong(Time.time * 6, 8);
            bloom.intensity.value = Mathf.Lerp(normalBloom, upperBloom, 20);
            //Debug.Log(bloom.intensity.value);
            bloomMod = false;
        }
        else
        {
            bloom.intensity.value = Mathf.Lerp(upperBloom, normalBloom, 20);
            chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, 0, 20);
        }

    }
}
