using System;
using System.Speech.Synthesis;

namespace TextToSpeech
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize a new instance of the SpeechSynthesizer class
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Choose a voice from the installed voices on your system
            synth.SelectVoice("Microsoft Zira Desktop");

            // Speak the text
            synth.Speak("Hello, I'm a text-to-speech voice");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}