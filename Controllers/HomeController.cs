using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace MusicPlayerWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Directory where your music files are stored
            string musicDirectory = "/Users/npatil14/Downloads/Movies/Music/";

            // Get all the music files from the directory
            string[] musicFiles = Directory.GetFiles(musicDirectory, "*.mp3");

            if (musicFiles.Length == 0)
            {
                ViewBag.Message = "No music files found in the directory.";
            }
            else
            {
                List<string> musicFileNames = new List<string>();
                foreach (string file in musicFiles)
                {
                    musicFileNames.Add(Path.GetFileName(file));
                }
                ViewBag.MusicFiles = musicFileNames;
            }

            return View();
        }

        [HttpGet]
        public IActionResult Play(string musicFile)
        {
            if (string.IsNullOrEmpty(musicFile))
            {
                return Json(new { status = "error", message = "No music file specified." });
            }
            return Json(new { status = "success", musicFile });
        }

        public IActionResult Pause()
        {
            // Implement code to pause the currently playing music
            // For a JavaScript-based audio player, you'll need to send a response indicating success or failure
            // Assuming success
            return Json(new { status = "success", message = "Music paused." });
        }
    }
}
