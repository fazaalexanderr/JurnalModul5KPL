﻿using System;
using System.Diagnostics;

namespace modul5_1302204062
{
     class Program
    {
        public static void Main(string[] args)
        {
            SayaTubeVideo video1 = new SayaTubeVideo("Review Film Minions oleh Faza Alexander Riawan");
            video1.IncreasePlayCount(25000000);
            SayaTubeVideo video2 = new SayaTubeVideo("Review Film Up oleh Faza Alexander Riawan");
            video1.IncreasePlayCount(25000000);
            SayaTubeVideo video3 = new SayaTubeVideo("Review Film Despicable Me oleh Faza Alexander Riawan");
            video1.IncreasePlayCount(25000000);
            SayaTubeVideo video4 = new SayaTubeVideo("Review Film Pee Mak Phrakanong oleh Faza Alexander Riawan");
            video1.IncreasePlayCount(25000000);
            SayaTubeVideo video5 = new SayaTubeVideo("Review Film Gemini Man oleh Faza Alexander Riawan");
            video1.IncreasePlayCount(25000000);
            SayaTubeVideo video6 = new SayaTubeVideo("Review Film The Lone Ranger oleh Faza Alexander Riawan");
            video1.IncreasePlayCount(25000000);
            SayaTubeVideo video7 = new SayaTubeVideo("Review Film Kung fu Panda 3 oleh Faza Alexander Riawan");
            video1.IncreasePlayCount(25000000);
            SayaTubeVideo video8 = new SayaTubeVideo("Review Film Coraline oleh Faza Alexander Riawan");
            video1.IncreasePlayCount(25000000);
            //SayaTubeVideo video9 = new SayaTubeVideo("Review Film Avatar oleh Faza Alexander Riawan");
            //video1.IncreasePlayCount(25000000);
            //SayaTubeVideo video10 = new SayaTubeVideo("Review Film Aquaman oleh Faza Alexander Riawan");
            //video1.IncreasePlayCount(25000000);

            SayaTubeUser user = new SayaTubeUser("Faza Alexander Riawan");
            user.AddVideo(video1);
            user.AddVideo(video2);
            user.AddVideo(video3);
            user.AddVideo(video4);
            user.AddVideo(video5);
            user.AddVideo(video6);
            user.AddVideo(video7);
            user.AddVideo(video8);
            //user.AddVideo(video9);
            //user.AddVideo(video10);
            user.PrintAllVideoPlaycount();
            Console.WriteLine(user.GetTotalVideoPlayCount());
        }
    }

    class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(String title)
        {
            Debug.Assert(title.Length <= 200, "Panjang title maksimal 200 karakter");
            try
            {
                title = checked(title);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Panjang Judul Video Tidak Sesuai");
            }

            Debug.Assert(title != null, "Title tidak boleh berupa null");
            try
            {
                title = checked(title);
            }
            catch(OverflowException e)
            {
                Console.WriteLine("Judul tidak boleh null");
            }
            this.title = title;
            Random random = new Random();
            this.id = random.Next(99999);
            this.playCount = 0;
        }

        public String GetTitle()
        {
            return this.title;
        }

        public int GetPlayCount()
        {
            return this.playCount;
        }

        public void IncreasePlayCount(int playCount)
        {
            Debug.Assert(playCount <= 25000000 && playCount >= 0, "play count maksimal 25.000.000 dan play count harus berupa bilangan positif");
            try
            {
                this.playCount = checked(this.playCount + playCount);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Terjadi masalah saat menambahkan playCount: " + e.Message);
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine("Video Title: " + this.title);
            Console.WriteLine("Video Id: " + this.id);
            Console.WriteLine("PlayCount: " + this.playCount);
        }
    }

    class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        public String Username;

        public SayaTubeUser(String Username)
        {
            Random random = new Random();
            this.id = random.Next(99999);
            this.uploadedVideos = new List<SayaTubeVideo>();
            Debug.Assert(Username.Length <= 100, "Panjang title maksimal 200 karakter");
            try
            {
                Username = checked(Username);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Panjang Username Tidak Sesuai");
            }

            Debug.Assert(Username != null, "Username tidak boleh berupa null");
            try
            {
                Username = checked(Username);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Username tidak sesuai, Username tidak boleh berupa NULL");
            }
            this.Username = Username;
        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            for (int i = 0; i < this.uploadedVideos.Count; i++)
            {
                Debug.Assert(total <= int.MaxValue, "Jumlah play count harus kurang dari 2,147,483,647");
                try
                {
                    total = total + this.uploadedVideos[i].GetPlayCount();
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Total play count melebihi 2,147,483,647");
                    total = 0;
                }
            }
            return total;
        }

        public void AddVideo(SayaTubeVideo video)
        {
            Debug.Assert(video != null && video.GetPlayCount() <= int.MaxValue, "Video tidak boleh berupa null dan video yang ditambahkan punya playCount yang kurang dari 2,147,483,647");
            this.uploadedVideos.Add(video);
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine("User: " + this.Username);
            int i = 1;
            for (int j = 0; j < this.uploadedVideos.Count; j++)
            {
                Debug.Assert(j < 8, "Jumlah video maksimal yang ditampilkan adalah 8");
                Console.WriteLine("Video " + i + " judul: " + uploadedVideos[j].GetTitle());
                i++;
            }
        }
    }
}