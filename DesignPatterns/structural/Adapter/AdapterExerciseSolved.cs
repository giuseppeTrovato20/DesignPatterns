using System;
namespace DesignPatterns.structural.AdapterExerciseSolved
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

    public class VideoServiceAdapter : IMediaProvider
    {
        private readonly VideoService _videoService;

        public VideoServiceAdapter(VideoService videoService)
        {
            _videoService = videoService;
        }

        public void Play()
        {
            _videoService.StartVideo();
        }

        public void Pause()
        {
            _videoService.PauseVideo();
        }
    }

    public class AudioServiceAdapter : IMediaProvider
    {
        private readonly AudioService _audioService;

        public AudioServiceAdapter(AudioService audioService)
        {
            _audioService = audioService;
        }

        public void Play()
        {
            _audioService.PlayAudio();
        }

        public void Pause()
        {
            _audioService.PauseAudio();
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        VideoService videoService = new VideoService();
    //        AudioService audioService = new AudioService();

    //        IMediaProvider videoAdapter = new VideoServiceAdapter(videoService);
    //        IMediaProvider audioAdapter = new AudioServiceAdapter(audioService);

    //        Console.WriteLine("Using VideoAdapter:");
    //        videoAdapter.Play();
    //        videoAdapter.Pause();

    //        Console.WriteLine("\nUsing AudioAdapter:");
    //        audioAdapter.Play();
    //        audioAdapter.Pause();
    //    }
    //}
}

