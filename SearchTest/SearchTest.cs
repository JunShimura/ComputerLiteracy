namespace SearchTest;
using System;
using System.Diagnostics;

class SerchTest
{
    static readonly int DATA_LENGTH = 1000;
    static void Main()
    {
        // ランダムなデータを生成
        int[] data = new int[DATA_LENGTH];
        Random rand = new Random();
        //data[0] = rand.Next(1, DATA_LENGTH);
        for (var i = 0; i < data.Length; i++)
        {
            data[i] = i;// rand.Next(1, DATA_LENGTH); // 1から要素数までのランダムな数値
        }

        // データをソート（サーチのため）
        //Array.Sort(data);

        Stopwatch stopwatch = new Stopwatch();
        while (true)
        {
            var target = data[rand.Next(data.Length)]; // ランダムなターゲット値

            // シーケンシャルサーチの実行時間を計測
            stopwatch.Start();
            var sequentialIndex = SequentialSearch(data, target);
            stopwatch.Stop();
            var sequentialTime = TicksToMs(stopwatch);

            // 自前バイナリサーチの実行時間を計測
            stopwatch.Restart();
            var originalBinaryIndex = BinarySearch(data, target);
            stopwatch.Stop();
            var originalBinaryTime = TicksToMs(stopwatch);
            // 標準バイナリサーチの実行時間を計測
            stopwatch.Restart();
            var binaryIndex = Array.BinarySearch(data, target);
            stopwatch.Stop();
            var binaryTime = TicksToMs(stopwatch);

            // 結果を表示
            Console.WriteLine($"\nシーケンシャルサーチのインデックス: {sequentialIndex}, \n実行時間: {sequentialTime} ms");
            Console.WriteLine($"自前バイナリサーチのインデックス: {originalBinaryIndex}, \n実行時間: {originalBinaryTime} ms");
            Console.WriteLine($"標準バイナリサーチのインデックス: {binaryIndex}, \n実行時間: {binaryTime} ms");
            Console.Write("Retry to hit Y:");
            var input = Console.ReadKey();
            if (input.KeyChar != 'y')
            {
                break;
            }
        }
    }

    static string TicksToMs(Stopwatch sw)
    {
        return ((double)sw.ElapsedTicks / Stopwatch.Frequency).ToString("N10");
    }
    static int SequentialSearch(int[] data, int target)
    {
        int result = -1;

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] == target)
            {
                result = i;
                break;
            }
        }
        return result; // 見つからなかった場合
    }
    static int BinarySearch(int[] data, int target)
    {
        int result = -1;
        int head = 0;
        int tail = data.Length - 1;
        while (head <= tail)
        {
            int i = (head + tail) / 2;
            if (data[i] == target)
            {   // 見つかった
                result = i;
                break;
            }
            else if (data[i] > target)
            {   // 先頭に近いほうに在る
                tail = i - 1;
            }
            else
            {   // 後ろ側に近いほうに在る            
                head = i + 1;
            }
        }
        return result;
    }
}

