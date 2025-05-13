using Newtonsoft.Json;
using np.Domain;

namespace np.Utility
{
    public static class OpenRouteServiceExtensions
    {
        public static OpenRouteServiceProperty GetOpenRouteServiceProperty(this string json)
        {
            return JsonConvert.DeserializeObject<OpenRouteServiceProperty>(json) ?? new OpenRouteServiceProperty();
        }

        public static Segment GetSegment(this OpenRouteServiceProperty openRouteServiceProperty)
        {
            return openRouteServiceProperty.Features[0].Properties.Segments[0];
        }

        public static double GetTotalDistance(this Segment segment)
        {
            return segment.Distance;
        }

        public static double GetTotalDuration(this Segment segment)
        {
            return segment.Duration;
        }

        public static IEnumerable<Step> GetSteps(this Segment segment)
        {
            return segment.Steps;
        }

        public static Dictionary<string, Dictionary<string, int>> GetGraph(this IEnumerable<Step> steps)
        {
            var graph = new Dictionary<string, Dictionary<string, int>>();
            foreach (var step in steps)
            {
                var innerGraph = new Dictionary<string, int>();
                foreach (var innerStep in steps)
                {
                    if (innerStep.WayPoints[0] - step.WayPoints[0] > 0)
                    {
                        if (!innerGraph.ContainsKey(innerStep.Name))
                        {
                            innerGraph.Add(innerStep.Name, (innerStep.WayPoints[0] - step.WayPoints[0]));
                        }
                        else
                        {
                            innerGraph.Add($"{innerStep.Name}-{(innerStep.WayPoints[0] - step.WayPoints[0])}", (innerStep.WayPoints[0] - step.WayPoints[0]));
                        }
                    }
                }
                if (!graph.ContainsKey(step.Name))
                {
                    graph.Add(step.Name, innerGraph);
                }
                else
                {
                    graph.Add($"{step.Name}-{step.WayPoints[0]}", innerGraph);
                }
            }
            return graph;
        }

        public static double[][] GetCoordinates(this OpenRouteServiceProperty openRouteServiceProperty)
        {
            return openRouteServiceProperty.Features[0].Geometry.Coordinates;
        }

        public static (Dictionary<string, Dictionary<string, int>> Graph, IEnumerable<double>[] Coordinates) GetSampleGraph()
        {
            var output = """
                    {
                    "Gerhart-Hauptmann-Straße": {
                        "Wielandtstraße": 1,
                        "Mönchhofstraße": 6,
                        "Erwin-Rohde-Straße": 17,
                        "Moltkestraße": 21,
                        "Handschuhsheimer Landstraße, B 3": 22,
                        "Roonstraße": 24,
                        "-": 25
                    },
                    "Wielandtstraße": {
                        "Mönchhofstraße": 5,
                        "Erwin-Rohde-Straße": 16,
                        "Moltkestraße": 20,
                        "Handschuhsheimer Landstraße, B 3": 21,
                        "Roonstraße": 23,
                        "-": 24
                    },
                    "Mönchhofstraße": {
                        "Erwin-Rohde-Straße": 11,
                        "Moltkestraße": 15,
                        "Handschuhsheimer Landstraße, B 3": 16,
                        "Roonstraße": 18,
                        "-": 19
                    },
                    "Erwin-Rohde-Straße": {
                        "Moltkestraße": 4,
                        "Handschuhsheimer Landstraße, B 3": 5,
                        "Roonstraße": 7,
                        "-": 8
                    },
                    "Moltkestraße": {
                        "Handschuhsheimer Landstraße, B 3": 1,
                        "Roonstraße": 3,
                        "-": 4
                    },
                    "Handschuhsheimer Landstraße, B 3": {
                        "Roonstraße": 2,
                        "-": 3
                    },
                    "Roonstraße": {
                        "-": 1
                    },
                    "-": {}
                }
                """;
            double[][] coordinates = [
                    [
                        8.681495,
                        49.414599
                    ],
                    [
                        8.68147,
                        49.414599
                    ],
                    [
                        8.681488,
                        49.41465
                    ],
                    [
                        8.681423,
                        49.415746
                    ],
                    [
                        8.681656,
                        49.41659
                    ],
                    [
                        8.681826,
                        49.417081
                    ],
                    [
                        8.681881,
                        49.417392
                    ],
                    [
                        8.682461,
                        49.417389
                    ],
                    [
                        8.682676,
                        49.417387
                    ],
                    [
                        8.682781,
                        49.417386
                    ],
                    [
                        8.683023,
                        49.417384
                    ],
                    [
                        8.683595,
                        49.417372
                    ],
                    [
                        8.68536,
                        49.417365
                    ],
                    [
                        8.686407,
                        49.417365
                    ],
                    [
                        8.68703,
                        49.41736
                    ],
                    [
                        8.687467,
                        49.417351
                    ],
                    [
                        8.688212,
                        49.417358
                    ],
                    [
                        8.688802,
                        49.417381
                    ],
                    [
                        8.68871,
                        49.418194
                    ],
                    [
                        8.688647,
                        49.418465
                    ],
                    [
                        8.688539,
                        49.418964
                    ],
                    [
                        8.688398,
                        49.41963
                    ],
                    [
                        8.690123,
                        49.419833
                    ],
                    [
                        8.689854,
                        49.420217
                    ],
                    [
                        8.689653,
                        49.420514
                    ],
                    [
                        8.687871,
                        49.420322
                    ]
                ];
            return (
                JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(output) ?? new Dictionary<string, Dictionary<string, int>>(),
                coordinates.Select(c => c.Reverse()).ToArray()
                );
        }
    }
}
