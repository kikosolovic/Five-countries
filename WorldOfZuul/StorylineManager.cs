using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Collections;



namespace WorldOfZuul
{
    public class StorylineManager
    {
        public string? options = null;
        public string? text = null;
        public string? response = null;
        public string? dynamicPath = "";
        dynamic story;
        public int idiotCount = 0;


        public StorylineManager(string path)
        {
            this.story = JsonConvert.DeserializeObject(File.ReadAllText(path));

            this.NextLevel("init");

        }
        public void NextLevel(string choice)
        {

            this.idiotCount = 0;

            switch (choice)
            {

                case "1":
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
                    Console.WriteLine("You have to choose one or two and also write it correctly withou a dot");
                    Console.ResetColor();
                    this.idiotCount += 1;
                    break;
            }

            try
            {
                this.options = this.story.options;
                this.text = this.story.text;
                this.response = this.story.response;
            }

            catch
            {
                Console.WriteLine("You have finished all of it");//pozret sa na t0, implement what happens at the ennd of scritp
                this.options = null;
            }

        }
        public string? tryRead(string subpena)
        {
            if (dynamicPath != "")
            {
                try
                {
                    string res = this.story.dynamicPath.subpena;
                    return res;
                }
                catch { return null; }

            }
            else
            {
                try
                {
                    string res = this.story.subpena;
                    return res;
                }
                catch { return null; }
            }

        }
    }
}