using System.Speech.Recognition;

namespace SpeechToText
{
    internal class Program
    {
        //Necessário ativar o reconhecimento de fala antes de rodar o programa(Windows 10: Settings>>Time&Language>>Language>>Windows display language>>English(United States); Settings>>Time&Language>>Speech>>Speech language>>English(United States);)
        //Neste exemplo é necessário setar o idioma para English. O programa só irá conseguir entender se o usuário falar hello ou world
        static void Main(string[] args)
        {
            // Create a new speech recognition engine
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();

            // Load a grammar for recognizing dates and times
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append("hello");
            grammarBuilder.Append("world");
            Grammar grammar = new Grammar(grammarBuilder);
            recognizer.LoadGrammar(grammar);

            // Start listening for speech
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

            // Register for the speech recognized event
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

            // Wait for the user to say "exit"
            Console.WriteLine("Listening for speech. Say 'exit' to stop.");
            while (Console.ReadLine() != "exit") ;

            // Stop the recognition engine
            recognizer.RecognizeAsyncStop();
        }

        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // Write the recognized text to the console
            Console.WriteLine("Recognized speech: " + e.Result.Text);
        }
    }
}