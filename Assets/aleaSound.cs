using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aleaSound : MonoBehaviour
{

    public AudioSource source
    {
        get
        {
            return this.GetComponent<AudioSource>();
        }
    }

    public List<AudioClip> clips = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        int id = Random.Range(0, clips.Count);
        source.clip = clips[id];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
