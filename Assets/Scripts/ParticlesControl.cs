using UnityEngine;
using System.Collections;

public class ParticlesControl : MonoBehaviour
{
    void Update()
    {
        if(!this.GetComponent<ParticleSystem>().isPlaying)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GetComponent<ParticleSystem>().startColor = GameObject.FindGameObjectsWithTag("Object")[0].GetComponent<ColorFader>().color;
        }
    }
}
