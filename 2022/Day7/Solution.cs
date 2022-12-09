using AdventOfCodeBase;

namespace AdventOfCode2022.Day7;

public class Solution : AdventSolver
{
    public Solution(bool useSample) : base (useSample, "2022", "7", "Day 7") {}
    public override void Part1()
    {
        var rootNode = BuildTree();
        //PrintNode(rootNode, 0);

        int max = 100000;
        var lookup = new Dictionary<TreeNode, int>();
        GetSizeOfChildren(rootNode, lookup);
        var totalAboveLimit = lookup.Where(l => l.Value <= max).Sum(l => l.Value);

        Console.WriteLine($"{Name} Part 1: {totalAboveLimit}");
    }

    public override void Part2()
    {
        var rootNode = BuildTree();
        //PrintNode(rootNode, 0);

        int totalDiskSpace = 70000000;
        int requiredUpdatedSpace = 30000000;
        var lookup = new Dictionary<TreeNode, int>();
        int totalUsedSpace = GetSizeOfChildren(rootNode, lookup);
        int totalAvailableSpace = totalDiskSpace - totalUsedSpace;
        var firstDirectoryOverNeededSpace = lookup.OrderBy(l => l.Value).First(l => l.Value + totalAvailableSpace > requiredUpdatedSpace);
        Console.WriteLine($"{Name} Part 2: {firstDirectoryOverNeededSpace.Value}");
    }
    
    private TreeNode BuildTree() {
        IEnumerable<string> lines = Input.Split(Environment.NewLine);
        var rootInfo = lines.First().Replace("$ cd ", "");
        var rootNode = new TreeNode {
            Name = rootInfo,
            Type = "dir",
            Size = 0,
            Parent = null
        };
        var currentNode = rootNode;
        foreach(var line in lines.Skip(1)) {
            if (line.Equals("$ ls")) {
                continue;
            }
            if (line.StartsWith("$ cd")) {
                var dirInfo = line.Replace("$ cd ", "");
                if (dirInfo.Equals("..")) {
                    currentNode = currentNode.Parent;
                } else {
                    var childNode = currentNode.Children.First(c => c.Name == dirInfo);
                    currentNode = childNode;
                }
            } else {
                var fileInfo = line.Split(' ');
                if (fileInfo[0].StartsWith("dir")) {
                    currentNode.Children.Add(new TreeNode {
                        Parent = currentNode,
                        Name = fileInfo[1],
                        Type = "dir",
                        Size = 0
                    });
                } else {
                    var size = Int32.Parse(fileInfo[0]);
                    currentNode.Children.Add(new TreeNode {
                        Parent = currentNode,
                        Name = fileInfo[1],
                        Type = "file",
                        Size = size
                    });
                }
            }
        }
        return rootNode;
    }

    public void PrintNode(TreeNode node, int depth) {
        var info = $"- {node.Name} ({node.Type}{(node.Size > 0 ? $", size={node.Size}" : "")})";
        Console.WriteLine(info.PadLeft(info.Length + depth * 2, ' '));
        foreach(var childNode in node.Children) {
            PrintNode(childNode, depth + 1);
        }
    }

    private int GetSizeOfChildren(TreeNode root, Dictionary<TreeNode, int> lookup) {
        int totalSize = 0;
        foreach(var child in root.Children) {
            if (child.Type == "dir") {
                totalSize += GetSizeOfChildren(child, lookup);
            } else {
                totalSize += child.Size;
            }
        }
        //Console.WriteLine($"Directory {root.Name} Size {totalSize}");
        lookup.Add(root, totalSize);
        return totalSize;
    }
}

public class TreeNode {
    public string Type {get; set;}
    public string Name {get; set;}
    public int Size { get; set;}
    public TreeNode? Parent { get; set; }
    public List<TreeNode> Children {get; set;}

    public TreeNode() {
        Children = new List<TreeNode>();
    }
}