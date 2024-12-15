using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Collections;



namespace FiveCountries
{
    public class StorylineManager
    {
        public string? options = null;
        public string? text = null;
        public string? response = null;
        public string? dynamicPath = "";
        dynamic story;
        public int repetition = 0;


        public StorylineManager(string path)
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(projectDirectory, "..", "..", "..", path);
            string fullPath = Path.GetFullPath(filePath);
            this.story = JsonConvert.DeserializeObject(File.ReadAllText(fullPath));

            this.NextLevel("init");

        }
        public void NextLevel(string choice = null)
        {

            this.repetition = 0;

            switch (choice)
            {

                case "1" or null or "":
                    this.story = this.story.opt1;
                    break;
                case "2":
                    this.story = this.story.opt2;
                    break;
                case "3":
                    if (this.story?.GetType().GetProperty("opt3") != null)
                    {
                        this.story = this.story.opt3;
                    }
                    else
                    {
                        Console.WriteLine("No option 3");
                    }
                    break;
                case "init":
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to write a number.");
                    Console.ResetColor();
                    this.repetition += 1;
                    break;
            }

            try
            {
                this.options = this.story.options;
                this.text = this.story.text;
                this.response = this.story.response;
            }

            // offset
            catch { }

        }

    }
}