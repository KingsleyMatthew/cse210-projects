using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

         List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Basics", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Very helpful!"));
        video1.AddComment(new Comment("Mark", "Great explanation."));
        video1.AddComment(new Comment("Sarah", "I finally understand C#!"));

        // Video 2
        Video video2 = new Video("OOP in C#", "Jane Smith", 750);
        video2.AddComment(new Comment("Daniel", "Nice examples."));
        video2.AddComment(new Comment("Emma", "Well explained!"));
        video2.AddComment(new Comment("Chris", "This helped a lot."));

        // Video 3
        Video video3 = new Video("Intro to Programming", "Tech Academy", 900);
        video3.AddComment(new Comment("Leo", "Perfect for beginners."));
        video3.AddComment(new Comment("Nina", "Loved it."));
        video3.AddComment(new Comment("James", "Very clear!"));

        // Add videos to list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display all videos
        foreach (Video video in videos)
        {
            video.DisplayVideo();
        }
    }
}
