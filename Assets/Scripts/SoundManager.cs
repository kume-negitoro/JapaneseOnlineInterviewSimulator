using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Serialize;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    protected AudioSource audio;

    [SerializeField]
    public AudioDict clipTable;

    public Dictionary<string, AudioClip> clips;

    [System.Serializable]
    public class AudioDict : TableBase<string, AudioClip, ClipInfo>
    {

    }

    [System.Serializable]
    public class ClipInfo : KeyAndValue<string, AudioClip>
    {
        public ClipInfo(string name, AudioClip clip) : base(name, clip)
        {
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        clips = clipTable.GetTable();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayVoice(string sourceName)
    {
        Debug.Log(audio);
        if(clips.ContainsKey(sourceName))
        {
            audio.PlayOneShot(clips[sourceName]);
        }
        else
        {
            Debug.Log("audio not found");
        }
        yield return new WaitUntil(() => audio.isPlaying);
        yield return null;
    }

    public IEnumerator PlaySE(string sourceName)
    {
        if(clips.ContainsKey(sourceName))
        {
            audio.PlayOneShot(clips[sourceName]);
        }
        yield return null;
    }
}
