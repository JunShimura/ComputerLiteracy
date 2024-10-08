namespace SearchTest;
using System;
using System.Diagnostics;

class SerchTest
{
    static readonly int DATA_LENGTH = 10000000;
    static void Main()
    {
        // ランダムなデータを生成
        int[] data = new int[DATA_LENGTH];
        Random rand = new Random();
        for (var i = 0; i < data.Length; i++)
        {
            data[i] = rand.Next(1, DATA_LENGTH + 1); // 1から要素数までのランダムな数値
        }

        // データをソート（サーチのため）
        Array.Sort(data);

        Stopwatch stopwatch = new Stopwatch();
        while (true)
        {
            var target = data[rand.Next(data.Length)]; // ランダムなターゲット値

            // シーケンシャルサーチの実行時間を計測
            stopwatch.Start();
            var sequentialIndex = SequentialSearch(data, target);
            stopwatch.Stop();
            double sequentialTime = (double)stopwatch.ElapsedTicks / Stopwatch.Frequency;

            // バイナリサーチの実行時間を計測
            stopwatch.Restart();
            var binaryIndex = Array.BinarySearch(data, target);
            stopwatch.Stop();
            var binaryTime = (double)stopwatch.ElapsedTicks / Stopwatch.Frequency;

            // 結果を表示
            Console.WriteLine($"シーケンシャルサーチのインデックス: {sequentialIndex}, 実行時間: {sequentialTime.ToString("N10")} ms");
            Console.WriteLine($"バイナリサーチのインデックス: {binaryIndex}, 実行時間: {binaryTime.ToString("N10")} ms");
            Console.Write("Retry to hit Y:");
            var input = Console.ReadKey();
            if (input.KeyChar != 'y')
            {
                break;
            }
        }
    }

    static int SequentialSearch(int[] data, int target)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] == target)
            {
                return i;
            }
        }
        return -1; // 見つからなかった場合
    }
}

