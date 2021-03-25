using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04
{
    public class NetworkApp
    {
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        InputReader reader = new InputReader();

        private NewsFeed news = new NewsFeed();
        public void DisplayMenu()
        {
            syntaxGen.SubheaderGen("Haroon's News Feed");
            string[] choices = new string[]
            {
                "Post Message", "Post Image", "Display All Posts", "Quit"
            };
            bool wantToQuit = false;
            int i = 1;
            foreach (string c in choices)
            {
                Console.WriteLine(syntaxGen.SyntaxFiller1(i + ". " + c));
                i++;
            }
            do
            {
                int choice = reader.RangeInputChecker("Choose Option", 1, 4);
                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostImage(); break;
                    case 3: DisplayAll(); break;
                    case 4: wantToQuit = true; break;
                }
            } while (!wantToQuit);
            syntaxGen.SyntaxFiller2();

        }

        private void DisplayAll()
        {
            news.Display();
        }

        private void PostImage()
        {
            string username = reader.ReadInput("Enter Username: ");
            string filename = reader.ReadInput("Enter Photo Filename: ");
            string message = reader.ReadInput("Enter Caption: ");
            new PhotoPost(username, filename, message);
        }

        private void PostMessage()
        {
            string username = reader.ReadInput("Enter Username: ");
            string message = reader.ReadInput("Enter Message: ");
            new MessagePost(username, message);
        }
    }
}
