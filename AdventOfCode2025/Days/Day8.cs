using System.Numerics;

namespace AdventOfCode2025.Days;

public class Day8 : IDay
{
    // input = ["162,817,812", "57,618,57", ...]

    public string Part1(string[] input)
    {
        var positions = input.Select(line => line.Split(',').Select(int.Parse).ToArray());
        var positionVectors = positions.Select(p => new Vector3(p[0], p[1], p[2])).ToArray();
        var circuits = new List<HashSet<Vector3>>();
        var distances = new List<(float distance, Vector3 a, Vector3 b)>();
        for (int i = 0; i < positionVectors.Length; i++)
        {
            for (int j = 0; j < positionVectors.Length; j++)
            {
                if (i != j && i > j)
                {
                    distances.Add(
                        (
                            Vector3.Distance(positionVectors[i], positionVectors[j]),
                            positionVectors[i],
                            positionVectors[j]
                        )
                    );
                }
            }
        }
        distances = [.. distances.OrderBy(d => d.distance)];
        foreach (var (distance, a, b) in distances[..(input.Length <= 20 ? 10 : 1000)])
        {
            var circuitA = circuits.FirstOrDefault(c => c.Contains(a));
            var circuitB = circuits.FirstOrDefault(c => c.Contains(b));
            if (circuitA == null && circuitB == null)
            {
                var newCircuit = new HashSet<Vector3> { a, b };
                circuits.Add([a, b]);
            }
            else if (circuitA != null && circuitB == null)
            {
                circuitA.Add(b);
            }
            else if (circuitA == null && circuitB != null)
            {
                circuitB.Add(a);
            }
            else if (circuitA != null && circuitB != null && circuitA != circuitB)
            {
                circuitA.UnionWith(circuitB);
                circuits.Remove(circuitB);
            }
        }

        return circuits
            .OrderBy(c => -c.Count)
            .Select(c => c.Count)
            .ToArray()[..3]
            .Aggregate(1, (a, b) => a * b)
            .ToString();
    }

    public string Part2(string[] input)
    {
        var positions = input.Select(line => line.Split(',').Select(int.Parse).ToArray());
        var positionVectors = positions.Select(p => new Vector3(p[0], p[1], p[2])).ToArray();
        var circuits = new List<HashSet<Vector3>>();
        var distances = new List<(float distance, Vector3 a, Vector3 b)>();
        for (int i = 0; i < positionVectors.Length; i++)
        {
            for (int j = 0; j < positionVectors.Length; j++)
            {
                if (i != j && i > j)
                {
                    distances.Add(
                        (
                            Vector3.Distance(positionVectors[i], positionVectors[j]),
                            positionVectors[i],
                            positionVectors[j]
                        )
                    );
                }
            }
        }
        distances = [.. distances.OrderBy(d => d.distance)];
        foreach (var (distance, a, b) in distances)
        {
            // Console.WriteLine($"Connecting {a} and {b} with distance {distance}");
            var circuitA = circuits.FirstOrDefault(c => c.Contains(a));
            var circuitB = circuits.FirstOrDefault(c => c.Contains(b));
            if (circuitA == null && circuitB == null)
            {
                circuits.Add([a, b]);
            }
            else if (circuitA != null && circuitB == null)
            {
                circuitA.Add(b);
            }
            else if (circuitA == null && circuitB != null)
            {
                circuitB.Add(a);
            }
            else if (circuitA != null && circuitB != null && circuitA != circuitB)
            {
                circuitA.UnionWith(circuitB);
                circuits.Remove(circuitB);
            }

            if (circuits.Count == 1 && circuits[0].Count == positionVectors.Length)
            {
                return ((int)a.X * (int)b.X).ToString();
            }
        }

        return "Failure";
    }
}
