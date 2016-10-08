using System;
using System.IO;
using System.Threading;
using Microsoft.Office.Interop.PowerPoint;

namespace OfficeInteropFinally
{
    class Program
    {
        //Listing 8-7 (część 2)
        [STAThread]
        static void Main(string[] args)
        {
            var pptApp = new Application();
            var pres = pptApp.Presentations.Open(args[0]);
            try
            {
                ProcessSliders(pres);
            }
            finally
            {
                pres.Close();
            }

        }

        private static void ProcessSliders(Presentation pres)
        {
            Application app = pres.Application;
            string inputPptx = pres.FullName;
            Presentation scratchPres = app.Presentations.Add();
            scratchPres.ApplyTemplate(inputPptx);
            Directory.CreateDirectory(VideoOutputFolder);

            char[] badChars = Path.GetInvalidFileNameChars();
            try
            {
                for (int i = 1; i <= pres.Slides.Count; ++i)
                {
                    var orig = pres.Slides[i];
                    orig.Copy();
                    SlideRange pasted = scratchPres.Slides.Paste();
                    pasted.Design = orig.Design;
                    pasted.SlideShowTransition.EntryEffect = PpEntryEffect.ppEffectNone;

                    string slideBaseName = string.Format("{1} {0}",
                        orig.Shapes.HasTitle == Microsoft.Office.Core.MsoTriState.msoCTrue
                            ? orig.Shapes.Title.TextEffect.Text
                            : "Slide", i);
                    foreach (char bad in badChars)
                    {
                        slideBaseName = slideBaseName.Replace(bad.ToString(), "");
                    }

                    string videoFileName = slideBaseName + ".wmv";
                    string videoPath = Path.Combine(VideoOutputFolder, videoFileName);
                    scratchPres.CreateVideo(videoPath, UseTimingsAndNarrations: false, DefaultSlideDuration: 0,
                        VertResolution: 768, FramesPerSecond: 30, Quality: 100);

                    do
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine(scratchPres.CreateVideoStatus);
                    } while (scratchPres.CreateVideoStatus == PpMediaTaskStatus.ppMediaTaskStatusInProgress);
                    pasted.Delete();
                }
            }
            finally
            {
                scratchPres.Close();
            }
        }

        private static readonly string VideoOutputFolder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RawSliderVideo");
    }
}
