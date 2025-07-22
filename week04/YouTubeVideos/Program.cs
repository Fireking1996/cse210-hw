using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Train Your Dragon Review", "MovieFan42", 320);
        video1.AddComment(new Comment("Alice", "Great review!"));
        video1.AddComment(new Comment("Bob", "I love this movie."));
        video1.AddComment(new Comment("Charlie", "Very informative!"));

        Video video2 = new Video("Best DIY Projects", "CraftQueen", 480);
        video2.AddComment(new Comment("Dave", "I'm trying this tomorrow."));
        video2.AddComment(new Comment("Emma", "So creative!"));
        video2.AddComment(new Comment("Frank", "Loved the third project."));

        Video video3 = new Video("Top 10 Coding Tips", "DevDude", 540);
        video3.AddComment(new Comment("Grace", "Tip #7 was a game changer."));
        video3.AddComment(new Comment("Hank", "Can you do one for Python?"));
        video3.AddComment(new Comment("Isla", "Thanks for the help!"));

        Video video4 = new Video("Guitar Lesson: Beginner Chords", "StringMaster", 600);
        video4.AddComment(new Comment("Jake", "Struggling with G major 😅"));
        video4.AddComment(new Comment("Luna", "This really helped me."));
        video4.AddComment(new Comment("Mark", "Clear and easy to follow."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
