﻿using LeetCode.Question.Hard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Consoles.Tools;
using Newtonsoft.Json;

namespace LeetCode.Question
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();

            CodeTimer codeTimer = new CodeTimer();

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);
        }

        private static void TestSwimInWater(CodeTimer codeTimer, Random rand)
        {
            SwimInWater instance = new SwimInWater();

            instance.Solution2(
                JsonConvert.DeserializeObject<int[][]>(
                    "[[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]"),
                true); //16

            instance.Solution2(
                JsonConvert.DeserializeObject<int[][]>(
                    "[[7,34,16,12,15,0],[10,26,4,30,1,20],[28,27,33,35,3,8],[29,9,13,14,11,32],[31,21,23,24,19,18],[22,6,17,5,2,25]]"),
                true); //26

            instance.Solution(JsonConvert.DeserializeObject<int[][]>(
                "[[52,19,24,3,45,21,56,27,5],[48,35,53,12,11,75,65,61,59],[58,9,76,28,4,80,72,34,78],[63,79,33,16,64,51,13,67,23],[31,57,54,60,74,8,6,38,44],[7,77,36,37,10,2,42,68,46],[32,25,17,26,15,14,29,70,39],[50,40,49,71,0,22,55,41,73],[69,66,1,47,20,43,30,62,18]]"));

            Console.ReadKey(true);

            int testCount = 10, martixLen = 20;

            codeTimer.Time(1, () => { instance.Solution(null); });
            for (int i = 0; i < testCount; i++)
            {
                var len = rand.Next(martixLen) + 2;

                var arr = new int[len][];

                var source = Enumerable.Range(0, len * len).ToList();

                for (int j = 0; j < len; j++)
                {
                    arr[j] = new int[len];
                    for (int k = 0; k < len; k++)
                    {
                        var randIndex = rand.Next(source.Count);
                        arr[j][k] = source[randIndex];
                        source.RemoveAt(randIndex);
                    }
                }

                int res = 0;

                var codeTimerResult = codeTimer.Time(1, () => { res = instance.Solution(arr); });

                ShowResult.ShowMulti(new Dictionary<string, object>()
                {
                    //{nameof(arr),ShowList.GetStr(arr)},
                    {nameof(arr), arr},
                    {nameof(res), res},
                    {nameof(codeTimerResult), codeTimerResult}
                });
            }
        }

        private static void TestBraceExpansionII()
        {
            BraceExpansionII instance = new BraceExpansionII();

            IList<string> res;

            res = instance.Solution("n{{c,g},{h,j},l}a{{a,{x,ia,o},w},er,a{x,ia,o}w}n");

            //["ncaaiawn","ncaan","ncaaown","ncaaxwn","ncaern","ncaian","ncaon","ncawn","ncaxn","ngaaiawn","ngaan","ngaaown","ngaaxwn","ngaern","ngaian","ngaon","ngawn","ngaxn","nhaaiawn","nhaan","nhaaown","nhaaxwn","nhaern","nhaian","nhaon","nhawn","nhaxn","njaaiawn","njaan","njaaown","njaaxwn","njaern","njaian","njaon","njawn","njaxn","nlaaiawn","nlaan","nlaaown","nlaaxwn","nlaern","nlaian","nlaon","nlawn","nlaxn"]
            ShowResult.Show(res);

            res = instance.Solution("a,n{{c,g},{h,j},l}a{{a,{x,ia,o},w},er,a{x,ia,o}w}n");

            //["a,ncaaiawn","a,ncaan","a,ncaaown","a,ncaaxwn","a,ncaern","a,ncaian","a,ncaon","a,ncawn","a,ncaxn","a,ngaaiawn","a,ngaan","a,ngaaown","a,ngaaxwn","a,ngaern","a,ngaian","a,ngaon","a,ngawn","a,ngaxn","a,nhaaiawn","a,nhaan","a,nhaaown","a,nhaaxwn","a,nhaern","a,nhaian","a,nhaon","a,nhawn","a,nhaxn","a,njaaiawn","a,njaan","a,njaaown","a,njaaxwn","a,njaern","a,njaian","a,njaon","a,njawn","a,njaxn","a,nlaaiawn","a,nlaan","a,nlaaown","a,nlaaxwn","a,nlaern","a,nlaian","a,nlaon","a,nlawn","a,nlaxn"]
            ShowResult.Show(res);

            res = instance.Solution("{{a,{x,ia,o},w},er,a{x,ia,o}w}");

            ShowResult.Show(res); //["a","aiaw","aow","axw","er","ia","o","w","x"]

            // next
            res = instance.Solution("{a,{a,{x,ia,o},w}er{n,{g,{u,o}},{a,{x,ia,o},w}},er}");

            //["a","aera","aerg","aeria","aern","aero","aeru","aerw","aerx","er","iaera","iaerg","iaeria","iaern","iaero","iaeru","iaerw","iaerx","oera","oerg","oeria","oern","oero","oeru","oerw","oerx","wera","werg","weria","wern","wero","weru","werw","werx","xera","xerg","xeria","xern","xero","xeru","xerw","xerx"]
            ShowResult.Show(res);

            res = instance.Solution("{a{x,ia,o}w,{n,{g,{u,o}},{a,{x,ia,o},w}},er}");

            ShowResult.Show(res); //["a","aiaw","aow","axw","er","g","ia","n","o","u","w","x"]

            res = instance.Solution("{a,b}c{d,e}f");

            ShowResult.Show(res); //["acdf","acef","bcdf","bcef"]

            res = instance.Solution("{a,b}{c,{d,e}}");

            ShowResult.Show(res); //["ac","ad","ae","bc","bd","be"]

            res = instance.Solution("{{a,z},a{b,c},{ab,z}}");

            ShowResult.Show(res); //["a","ab","ac","z"]
        }

        private static void TestLongestDecomposition()
        {
            LongestDecomposition instance = new LongestDecomposition();

            instance.Test(instance.Solution);

            instance.TestCase(100, 10, instance.Solution);
        }

        private static void TestParseBoolExpr()
        {
            ParseBoolExpr instance = new ParseBoolExpr();

            Console.WriteLine(instance.Solution("|(f,&(t,t))") == true);

            instance.Test(instance.Solution);

            Console.WriteLine(instance.Solution("!(&(&(!(&(f)),&(t),|(f,f,t)),&(t),&(t,t,f)))"));

            Console.WriteLine(instance.Solution(
                                  "&(&(&(!(&(f)),&(t),|(f,f,t)),|(t),|(f,f,t)),!(&(|(f,f,t),&(&(f),&(!(t),&(f),|(f)),&(!(&(f)),&(t),|(f,f,t))),&(t))),&(!(&(&(!(&(f)),&(t),|(f,f,t)),|(t),|(f,f,t))),!(&(&(&(t,t,f),|(f,f,t),|(f)),!(&(t)),!(&(|(f,f,t),&(&(f),&(!(t),&(f),|(f)),&(!(&(f)),&(t),|(f,f,t))),&(t))))),!(&(f))))") ==
                              false);
        }

        private static void TestMyCalendarThree()
        {
            List<int> list = new List<int>() {1, 2, 3};
            list.Insert(0, 4);

            MyCalendarThree instance = new MyCalendarThree();

            instance.Test();

            var arr = new[]
            {
                new[] {24, 40},
                new[] {43, 50},
                new[] {27, 43},
                new[] {5, 21},
                new[] {30, 40},
                new[] {14, 29},
                new[] {3, 19},
                new[] {3, 14},
                new[] {25, 39},
                new[] {6, 19}
            };

            //[null,1,1,2,2,3,3,3,3,4,4]

            foreach (var item in arr)
            {
                instance.Book(item[0], item[1]);
            }
        }
    }
}