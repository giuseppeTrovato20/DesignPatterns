using System;
namespace DesignPatterns.structural.Adapter
{

    public interface IMediaProvider
    {
        void Play();
        void Pause();
    }

    public class VideoService
    {
        public void StartVideo()
        {
            Console.WriteLine("VideoService: Playing video...");
        }

        public void PauseVideo()
        {
            Console.WriteLine("VideoService: Pausing video...");
        }
    }

    public class AudioService
    {
        public void PlayAudio()
        {
            Console.WriteLine("AudioService: Playing audio...");
        }

        public void PauseAudio()
        {
            Console.WriteLine("AudioService: Pausing audio...");
        }
    }



    public class VideoToMediaProviderAdapter : IMediaProvider
    {
        VideoService videoService;

        public VideoToMediaProviderAdapter(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Play()
        {
            videoService.StartVideo();
        }

        public void Pause()
        {
            videoService.PauseVideo();
        }

    }


    public class AudioToMediaProviderAdapter : IMediaProvider
    {
        AudioService audioService;

        public AudioToMediaProviderAdapter(AudioService audioService)
        {
            this.audioService = audioService;
        }

        public void Play()
        {
            audioService.PlayAudio();
        }

        public void Pause()
        {
            audioService.PauseAudio();
        }
    }

    class Client
    {
        static void Main(string[] args)
        {
            
        }
    }
}

//Modifica il codice fornito per:

//Creare due classi adapter separate per VideoService e AudioService che implementano l'interfaccia IMediaProvider.

//Nel metodo Main, istanzia le classi adapter e passa le istanze di VideoService e AudioService alle rispettive classi adapter.

//Utilizza i metodi Play e Pause delle classi adapter per invocare i corrispondenti metodi delle classi di servizio sottostanti.

//Esegui il programma per verificare che il codice funzioni correttamente e i servizi multimediali siano invocati tramite l'interfaccia IMediaProvider.
