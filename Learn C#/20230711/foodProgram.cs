// See https://aka.ms/new-console-template for more information
using System;

// 二次元配列の扱いの練習プログラム
namespace ConsoleApp6
{
    class program
    {
        static void Main(string[] args)
        {
            // 二次元配列
            string[,] items =
            {
                { "1", "Red", "Apple", "りんご", "Fruit" },
                { "2", "Orange", "Orange", "みかん", "Fruit" },
                { "3", "Purple", "Grape", "ぶどう", "Fruit" },
                { "4", "Yellow", "Banana", "バナナ", "Fruit" },
                { "5", "Pink", "Peach", "もも", "Fruit" },
                { "6", "Red", "Tomato", "トマト", "Vegetable" },
                { "7", "Green", "Cucumber", "きゅうり", "Vegetable" },
                { "8", "Green", "Bell Pepper", "ピーマン", "Vegetable" },
                { "9", "Yellow", "Corn", "とうもろこし", "Vegetable" },
                { "10","Red", "beef", "牛肉", "Meat"}
            };

            // ジャグ配列
            List<string>[] itemsByKind = new List<string>[2];
            itemsByKind[0] = GetItemsByKind(items, "Vegetable"); // 野菜のリスト
            itemsByKind[1] = GetItemsByKind(items, "Fruit");     // フルーツのリスト
            List<string> duplicateColors = GetDuplicateColors(items);

            // 野菜のリストを表示
            Console.WriteLine("<野菜のリスト抽出>");
            PrintItems(itemsByKind[0]);

            // フルーツのリストを表示
            Console.WriteLine("<フルーツのリスト抽出>");
            PrintItems(itemsByKind[1]);

            // 重複した色と対応するフルーツ名または野菜名を表示
            Console.WriteLine("<色の重複>");
            foreach (string color in duplicateColors)
            {
                Console.WriteLine($"色: {color}");
                Console.Write("フルーツ名または野菜名: ");
                PrintItems(GetItemsByColor(items, color));
            }
        }

        // 野菜またはフルーツのリストを作る。
        static List<string> GetItemsByKind(string[,] items, string kind)
        {
            List<string> itemList = new List<string>();

            for (int i = 0; i < items.GetLength(0); i++)
            {
                string engName = items[i, 2];
                string jpName = items[i, 3];
                if (items[i, 4] == kind)
                {
                    itemList.Add($"{engName}:{jpName}");
                }
            }

            return itemList;
        }

        // 色の重複を判定
        static List<string> GetDuplicateColors(string[,] items)
        {
            List<string> duplicateColors = new List<string>();

            for (int i = 0; i < items.GetLength(0); i++)
            {
                string color = items[i, 1];
                bool isDuplicate = false;

                for (int j = i + 1; j < items.GetLength(0); j++)
                {
                    if (color == items[j, 1] && !duplicateColors.Contains(color))
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (isDuplicate)
                {
                    duplicateColors.Add(color);
                }
            }

            return duplicateColors;
        }

        static List<string> GetItemsByColor(string[,] items, string color)
        {
            List<string> itemList = new List<string>();

            for (int i = 0; i < items.GetLength(0); i++)
            {
                if (items[i, 1] == color)
                {
                    itemList.Add(items[i, 2]);
                }
            }

            return itemList;
        }

        static void PrintItems(List<string> items)
        {
            foreach (string item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
