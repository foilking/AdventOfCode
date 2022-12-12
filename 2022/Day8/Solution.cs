using AdventOfCodeBase;
using System.Collections.Generic;

namespace AdventOfCode2022.Day8;

public class Solution : AdventSolver
{
    public Solution(bool useSample) : base (useSample, "2022", "8", "Day8") {}

    public override void Part1()
    {
        string[] lines = this.Input.Split(Environment.NewLine);
        var matrix = lines.Select(l => l.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray()).ToArray();
        var height = matrix.Length;
        var width = matrix[0].Length;

        int treesVisible = 0;
        for (int h = 0; h < height; h++) {
            for (int w = 0; w < width; w++) {
                if (w == 0 || h == 0 
                || w == width - 1 || h == height - 1) {
                    treesVisible++;
                } else {
                    var currentTree = matrix[h][w];
                    var northTrees = matrix.Where((m, index) => index < h).Select(m => m[w]);
                    var southTrees = matrix.Where((m, index) => index > h).Select(m => m[w]);
                    var eastTrees = matrix.Where((m, index) => index == h).SelectMany(m => m).Where((m, index) => index > w);  
                    var westTrees = matrix.Where((m, index) => index == h).SelectMany(m => m).Where((m, index) => index < w);

                    var visibleFromNorth = northTrees.All(n => n < currentTree);
                    var visibleFromSouth = southTrees.All(n => n < currentTree);
                    var visibleFromEast = eastTrees.All(n => n < currentTree);
                    var visibleFromWest = westTrees.All(n => n < currentTree);

                    if (visibleFromNorth 
                    || visibleFromSouth
                    || visibleFromEast
                    || visibleFromWest)
                    {
                        treesVisible++;   
                    }
                }
            }
        }
        Console.WriteLine($"{Name} Part 1: {treesVisible}");
    }

    public override void Part2()
    {
        string[] lines = this.Input.Split(Environment.NewLine);
        var matrix = lines.Select(l => l.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray()).ToArray();
        var height = matrix.Length;
        var width = matrix[0].Length;
        int scenicHighScore = 0;
        for (int h = 0; h < height; h++) {
            for (int w = 0; w < width; w++) {
                var currentTree = matrix[h][w];
                var upTrees = matrix.Where((m, index) => index < h).Select(m => m[w]).Reverse();
                var downTrees = matrix.Where((m, index) => index > h).Select(m => m[w]);
                var rightTrees = matrix.Where((m, index) => index == h).SelectMany(m => m).Where((m, index) => index > w);  
                var leftTrees = matrix.Where((m, index) => index == h).SelectMany(m => m).Where((m, index) => index < w).Reverse();

                var upScore = ScenicScore(currentTree, upTrees);
                var downScore = ScenicScore(currentTree, downTrees);
                var rightScore = ScenicScore(currentTree, rightTrees);
                var leftScore = ScenicScore(currentTree, leftTrees);
                var scenicScore = upScore * downScore * rightScore * leftScore;

                if (scenicScore > scenicHighScore) {
                    Console.WriteLine($"Postion {h + 1},{w + 1} Tree value {currentTree}");
                    Console.WriteLine($"Up Trees: {string.Join(',', upTrees)}");
                    Console.WriteLine($"Up Score: {upScore}");
                    
                    Console.WriteLine($"Left Trees: {string.Join(',', leftTrees)}");
                    Console.WriteLine($"Left Score: {leftScore}");
                    
                    Console.WriteLine($"Down Trees: {string.Join(',', downTrees)}");
                    Console.WriteLine($"Down Score: {downScore}");
                    
                    Console.WriteLine($"Right Trees: {string.Join(',', rightTrees)}");
                    Console.WriteLine($"Right Score: {rightScore}");
                    
                    Console.WriteLine($"Scenic Score: {scenicScore}");
                    Console.WriteLine();
                }

                if (scenicScore > scenicHighScore) {
                    scenicHighScore = scenicScore;
                } 
            }
        }

        Console.WriteLine($"{Name} Part 2: {scenicHighScore}");
    }

    private int ScenicScore(int currentTree, IEnumerable<int> treeList)
    {
        var blockingIndex = treeList.Where(t => t > 0).Select((elem, index) => new {elem, index}).FirstOrDefault(p => p.elem >= currentTree && p.elem > 0);
        return blockingIndex == null ? treeList.Count() : blockingIndex.index + 1;
    }
}