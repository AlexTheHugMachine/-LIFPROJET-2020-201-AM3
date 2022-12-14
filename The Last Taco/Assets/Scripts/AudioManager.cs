using UnityEngine;
using UnityEngine.Audio;

//Classe permettant de gérer les musiques du jeu
public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;

    public AudioMixerGroup soundEffectMixer;

    public static AudioManager instance;

   //Singleton
   private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("Il n'y a plus d'une instance de AudioManager dans la scène");
           return;
       }

       instance = this; 
   }

   //Procédure permettant de lancer la première musique
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    //Procédure permettant de lancer la musique suivante lorsque la première musique est terminée
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    //Procédure permettant de jouer la musique suivante de la playlist
    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(tempGO, clip.length);
        return audioSource;
    }

}
