using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using np.Domain;
using np.Utility;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace np.Test
{
    public class DomainTests
    {
        private readonly ITestOutputHelper _output;
        public DomainTests(ITestOutputHelper output)
        {
            _output = output;
        }

        #region GeoCodeValue
        string osmResult = """
            [
                {
                    "place_id": 229586017,
                    "licence": "Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright",
                    "osm_type": "relation",
                    "osm_id": 103703,
                    "boundingbox": [
                        "14.5508249",
                        "14.6395473",
                        "120.7917034",
                        "121.0261672"
                    ],
                    "lat": "14.5906346",
                    "lon": "120.9799964",
                    "display_name": "Manila, Capital District, Metro Manila, Philippines",
                    "class": "boundary",
                    "type": "administrative",
                    "importance": 0.7601726551721906
                },
                {
                    "place_id": 229597594,
                    "licence": "Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright",
                    "osm_type": "way",
                    "osm_id": 1159398316,
                    "boundingbox": [
                        "14.4606773",
                        "14.7053497",
                        "120.6464316",
                        "120.8992505"
                    ],
                    "lat": "14.5830475",
                    "lon": "120.77284105537443",
                    "display_name": "Manila Bay, Cavite, Calabarzon, Philippines",
                    "class": "natural",
                    "type": "bay",
                    "importance": 0.5644841920681354
                },
                {
                    "place_id": 297479544,
                    "licence": "Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright",
                    "osm_type": "relation",
                    "osm_id": 6698725,
                    "boundingbox": [
                        "35.8659762",
                        "35.9091651",
                        "-90.202193",
                        "-90.1414706"
                    ],
                    "lat": "35.8800733",
                    "lon": "-90.1670393",
                    "display_name": "Manila, Mississippi County, Arkansas, United States",
                    "class": "boundary",
                    "type": "administrative",
                    "importance": 0.5004445936746829
                },
                {
                    "place_id": 287862495,
                    "licence": "Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright",
                    "osm_type": "node",
                    "osm_id": 141041263,
                    "boundingbox": [
                        "40.8317929",
                        "40.8717929",
                        "-124.1822856",
                        "-124.1422856"
                    ],
                    "lat": "40.8517929",
                    "lon": "-124.1622856",
                    "display_name": "Manila, Humboldt County, California, United States",
                    "class": "place",
                    "type": "hamlet",
                    "importance": 0.47345574233117793
                },
                {
                    "place_id": 302040011,
                    "licence": "Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright",
                    "osm_type": "node",
                    "osm_id": 153910665,
                    "boundingbox": [
                        "37.9667678",
                        "38.0067678",
                        "-81.9629031",
                        "-81.9229031"
                    ],
                    "lat": "37.9867678",
                    "lon": "-81.9429031",
                    "display_name": "Manila, Boone County, West Virginia, 25203, United States",
                    "class": "place",
                    "type": "hamlet",
                    "importance": 0.4095218989809717
                },
                {
                    "place_id": 216181145,
                    "licence": "Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright",
                    "osm_type": "node",
                    "osm_id": 8075320960,
                    "boundingbox": [
                        "29.7114676",
                        "29.7514676",
                        "79.1835079",
                        "79.2235079"
                    ],
                    "lat": "29.7314676",
                    "lon": "79.2035079",
                    "display_name": "Manila, Bhikiasain, Almora District, Uttarakhand, 263667, India",
                    "class": "place",
                    "type": "village",
                    "importance": 0.38500999999999996
                },
                {
                    "place_id": 223277037,
                    "licence": "Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright",
                    "osm_type": "node",
                    "osm_id": 6387893696,
                    "boundingbox": [
                        "12.6607656",
                        "12.7007656",
                        "75.0435934",
                        "75.0835934"
                    ],
                    "lat": "12.6807656",
                    "lon": "75.0635934",
                    "display_name": "Manila, Bantwal taluk, Dakshina Kannada, Karnataka, 574260, India",
                    "class": "place",
                    "type": "village",
                    "importance": 0.38500999999999996
                },
                {
                    "place_id": 279461624,
                    "licence": "Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright",
                    "osm_type": "node",
                    "osm_id": 3756622801,
                    "boundingbox": [
                        "25.6719486",
                        "25.7119486",
                        "-103.5590216",
                        "-103.5190216"
                    ],
                    "lat": "25.6919486",
                    "lon": "-103.5390216",
                    "display_name": "Manila, Gómez Palacio, Durango, Mexico",
                    "class": "place",
                    "type": "village",
                    "importance": 0.38500999999999996
                },
                {
                    "place_id": 229014651,
                    "licence": "Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright",
                    "osm_type": "node",
                    "osm_id": 10788426654,
                    "boundingbox": [
                        "13.2179038",
                        "13.2579038",
                        "123.9300552",
                        "123.9700552"
                    ],
                    "lat": "13.2379038",
                    "lon": "123.9500552",
                    "display_name": "Manila, Rapu-Rapu, Albay, Bicol Region, Philippines",
                    "class": "place",
                    "type": "village",
                    "importance": 0.38500999999999996
                },
                {
                    "place_id": 302048468,
                    "licence": "Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright",
                    "osm_type": "node",
                    "osm_id": 154217415,
                    "boundingbox": [
                        "37.8228699",
                        "37.8628699",
                        "-82.9354425",
                        "-82.8954425"
                    ],
                    "lat": "37.8428699",
                    "lon": "-82.9154425",
                    "display_name": "Manila, Johnson County, Kentucky, 41238, United States",
                    "class": "place",
                    "type": "hamlet",
                    "importance": 0.3672775033536223
                }
            ]
            """;
        #endregion

        #region OpenRouteService
        string orsResult = """
        {
            "type": "FeatureCollection",
            "bbox": [
                8.681423,
                49.414599,
                8.690123,
                49.420514
            ],
            "features": [
                {
                    "bbox": [
                        8.681423,
                        49.414599,
                        8.690123,
                        49.420514
                    ],
                    "type": "Feature",
                    "properties": {
                        "segments": [
                            {
                                "distance": 1408.8,
                                "duration": 281.9,
                                "steps": [
                                    {
                                        "distance": 1.8,
                                        "duration": 0.4,
                                        "type": 11,
                                        "instruction": "Head west on Gerhart-Hauptmann-Straße",
                                        "name": "Gerhart-Hauptmann-Straße",
                                        "way_points": [
                                            0,
                                            1
                                        ]
                                    },
                                    {
                                        "distance": 313.8,
                                        "duration": 75.3,
                                        "type": 1,
                                        "instruction": "Turn right onto Wielandtstraße",
                                        "name": "Wielandtstraße",
                                        "way_points": [
                                            1,
                                            6
                                        ]
                                    },
                                    {
                                        "distance": 500.8,
                                        "duration": 76.4,
                                        "type": 1,
                                        "instruction": "Turn right onto Mönchhofstraße",
                                        "name": "Mönchhofstraße",
                                        "way_points": [
                                            6,
                                            17
                                        ]
                                    },
                                    {
                                        "distance": 251.9,
                                        "duration": 60.5,
                                        "type": 0,
                                        "instruction": "Turn left onto Erwin-Rohde-Straße",
                                        "name": "Erwin-Rohde-Straße",
                                        "way_points": [
                                            17,
                                            21
                                        ]
                                    },
                                    {
                                        "distance": 126.8,
                                        "duration": 30.4,
                                        "type": 1,
                                        "instruction": "Turn right onto Moltkestraße",
                                        "name": "Moltkestraße",
                                        "way_points": [
                                            21,
                                            22
                                        ]
                                    },
                                    {
                                        "distance": 83,
                                        "duration": 7.5,
                                        "type": 2,
                                        "instruction": "Turn sharp left onto Handschuhsheimer Landstraße, B 3",
                                        "name": "Handschuhsheimer Landstraße, B 3",
                                        "way_points": [
                                            22,
                                            24
                                        ]
                                    },
                                    {
                                        "distance": 130.6,
                                        "duration": 31.3,
                                        "type": 0,
                                        "instruction": "Turn left onto Roonstraße",
                                        "name": "Roonstraße",
                                        "way_points": [
                                            24,
                                            25
                                        ]
                                    },
                                    {
                                        "distance": 0,
                                        "duration": 0,
                                        "type": 10,
                                        "instruction": "Arrive at Roonstraße, straight ahead",
                                        "name": "-",
                                        "way_points": [
                                            25,
                                            25
                                        ]
                                    }
                                ]
                            }
                        ],
                        "way_points": [
                            0,
                            25
                        ],
                        "summary": {
                            "distance": 1408.8,
                            "duration": 281.9
                        }
                    },
                    "geometry": {
                        "coordinates": [
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
                        ],
                        "type": "LineString"
                    }
                }
            ],
            "metadata": {
                "attribution": "openrouteservice.org | OpenStreetMap contributors",
                "service": "routing",
                "timestamp": 1747128282013,
                "query": {
                    "coordinates": [
                        [
                            8.681495,
                            49.41461
                        ],
                        [
                            8.687872,
                            49.420318
                        ]
                    ],
                    "profile": "driving-car",
                    "profileName": "driving-car",
                    "format": "json"
                },
                "engine": {
                    "version": "9.2.0",
                    "build_date": "2025-05-06T08:31:01Z",
                    "graph_date": "2025-05-11T13:01:50Z"
                }
            }
        }
        """;
        #endregion

        #region marilaoToIntramuros
        string mti = """
                        {
                "type": "FeatureCollection",
                "bbox": [
                    120.948019,
                    14.589944,
                    121.000765,
                    14.761345
                ],
                "features": [
                    {
                        "bbox": [
                            120.948019,
                            14.589944,
                            121.000765,
                            14.761345
                        ],
                        "type": "Feature",
                        "properties": {
                            "segments": [
                                {
                                    "distance": 24998.5,
                                    "duration": 1920.1,
                                    "steps": [
                                        {
                                            "distance": 15.4,
                                            "duration": 5.5,
                                            "type": 11,
                                            "instruction": "Head southeast",
                                            "name": "-",
                                            "way_points": [
                                                0,
                                                1
                                            ]
                                        },
                                        {
                                            "distance": 28.7,
                                            "duration": 6.9,
                                            "type": 3,
                                            "instruction": "Turn sharp right",
                                            "name": "-",
                                            "way_points": [
                                                1,
                                                3
                                            ]
                                        },
                                        {
                                            "distance": 670.4,
                                            "duration": 62.5,
                                            "type": 0,
                                            "instruction": "Turn left onto Sandico Street",
                                            "name": "Sandico Street",
                                            "way_points": [
                                                3,
                                                18
                                            ]
                                        },
                                        {
                                            "distance": 98.4,
                                            "duration": 7.1,
                                            "type": 6,
                                            "instruction": "Continue straight onto Sandico Street",
                                            "name": "Sandico Street",
                                            "way_points": [
                                                18,
                                                20
                                            ]
                                        },
                                        {
                                            "distance": 126.3,
                                            "duration": 9.1,
                                            "type": 12,
                                            "instruction": "Keep left onto Sandico Street",
                                            "name": "Sandico Street",
                                            "way_points": [
                                                20,
                                                27
                                            ]
                                        },
                                        {
                                            "distance": 44.4,
                                            "duration": 3.2,
                                            "type": 0,
                                            "instruction": "Turn left onto MacArthur Highway, 1",
                                            "name": "MacArthur Highway, 1",
                                            "way_points": [
                                                27,
                                                28
                                            ]
                                        },
                                        {
                                            "distance": 1426.6,
                                            "duration": 99,
                                            "type": 1,
                                            "instruction": "Turn right onto Lias Road",
                                            "name": "Lias Road",
                                            "way_points": [
                                                28,
                                                70
                                            ]
                                        },
                                        {
                                            "distance": 1818.7,
                                            "duration": 137.7,
                                            "type": 1,
                                            "instruction": "Turn right onto East Service Road",
                                            "name": "East Service Road",
                                            "way_points": [
                                                70,
                                                91
                                            ]
                                        },
                                        {
                                            "distance": 318.2,
                                            "duration": 52.4,
                                            "type": 1,
                                            "instruction": "Turn right onto Malhacan Road",
                                            "name": "Malhacan Road",
                                            "way_points": [
                                                91,
                                                99
                                            ]
                                        },
                                        {
                                            "distance": 12250,
                                            "duration": 676.2,
                                            "type": 0,
                                            "instruction": "Turn left",
                                            "name": "-",
                                            "way_points": [
                                                99,
                                                200
                                            ]
                                        },
                                        {
                                            "distance": 1101.4,
                                            "duration": 108.6,
                                            "type": 1,
                                            "instruction": "Turn right onto C-3 Road, 130",
                                            "name": "C-3 Road, 130",
                                            "way_points": [
                                                200,
                                                218
                                            ]
                                        },
                                        {
                                            "distance": 1386.5,
                                            "duration": 110.4,
                                            "type": 0,
                                            "instruction": "Turn left onto Rizal Avenue Extension, 150",
                                            "name": "Rizal Avenue Extension, 150",
                                            "way_points": [
                                                218,
                                                240
                                            ]
                                        },
                                        {
                                            "distance": 4149.5,
                                            "duration": 405.8,
                                            "type": 13,
                                            "instruction": "Keep right onto Abad Santos Avenue, 151",
                                            "name": "Abad Santos Avenue, 151",
                                            "way_points": [
                                                240,
                                                295
                                            ]
                                        },
                                        {
                                            "distance": 377.2,
                                            "duration": 56.2,
                                            "type": 0,
                                            "instruction": "Turn left onto Plaza Cervantes",
                                            "name": "Plaza Cervantes",
                                            "way_points": [
                                                295,
                                                303
                                            ]
                                        },
                                        {
                                            "distance": 434.4,
                                            "duration": 54.1,
                                            "type": 1,
                                            "instruction": "Turn right onto Magallanes Drive",
                                            "name": "Magallanes Drive",
                                            "way_points": [
                                                303,
                                                316
                                            ]
                                        },
                                        {
                                            "distance": 324.8,
                                            "duration": 37.9,
                                            "type": 4,
                                            "instruction": "Turn slight left onto Andres Soriano Avenue",
                                            "name": "Andres Soriano Avenue",
                                            "way_points": [
                                                316,
                                                320
                                            ]
                                        },
                                        {
                                            "distance": 270,
                                            "duration": 64.8,
                                            "type": 0,
                                            "instruction": "Turn left onto Arzobispo Street",
                                            "name": "Arzobispo Street",
                                            "way_points": [
                                                320,
                                                325
                                            ]
                                        },
                                        {
                                            "distance": 157.9,
                                            "duration": 22.7,
                                            "type": 0,
                                            "instruction": "Turn left onto Anda Street",
                                            "name": "Anda Street",
                                            "way_points": [
                                                325,
                                                329
                                            ]
                                        },
                                        {
                                            "distance": 0,
                                            "duration": 0,
                                            "type": 10,
                                            "instruction": "Arrive at Anda Street, on the left",
                                            "name": "-",
                                            "way_points": [
                                                329,
                                                329
                                            ]
                                        }
                                    ]
                                }
                            ],
                            "extras": {
                                "roadaccessrestrictions": {
                                    "values": [
                                        [
                                            0,
                                            320,
                                            0
                                        ],
                                        [
                                            320,
                                            322,
                                            32
                                        ],
                                        [
                                            322,
                                            329,
                                            0
                                        ]
                                    ],
                                    "summary": [
                                        {
                                            "value": 0,
                                            "distance": 24905.3,
                                            "amount": 99.63
                                        },
                                        {
                                            "value": 32,
                                            "distance": 93.2,
                                            "amount": 0.37
                                        }
                                    ]
                                }
                            },
                            "warnings": [
                                {
                                    "code": 1,
                                    "message": "There may be restrictions on some roads"
                                }
                            ],
                            "way_points": [
                                0,
                                329
                            ],
                            "summary": {
                                "distance": 24998.5,
                                "duration": 1920.1
                            }
                        },
                        "geometry": {
                            "coordinates": [
                                [
                                    120.948209,
                                    14.757549
                                ],
                                [
                                    120.948267,
                                    14.757422
                                ],
                                [
                                    120.948161,
                                    14.757418
                                ],
                                [
                                    120.948019,
                                    14.757347
                                ],
                                [
                                    120.94882,
                                    14.756039
                                ],
                                [
                                    120.949212,
                                    14.755299
                                ],
                                [
                                    120.949354,
                                    14.755034
                                ],
                                [
                                    120.949679,
                                    14.754365
                                ],
                                [
                                    120.94974,
                                    14.754245
                                ],
                                [
                                    120.949898,
                                    14.753951
                                ],
                                [
                                    120.94995,
                                    14.753933
                                ],
                                [
                                    120.950075,
                                    14.753924
                                ],
                                [
                                    120.950242,
                                    14.753949
                                ],
                                [
                                    120.950598,
                                    14.754065
                                ],
                                [
                                    120.95079,
                                    14.754152
                                ],
                                [
                                    120.951292,
                                    14.754353
                                ],
                                [
                                    120.951563,
                                    14.754439
                                ],
                                [
                                    120.951706,
                                    14.754511
                                ],
                                [
                                    120.952005,
                                    14.754626
                                ],
                                [
                                    120.952484,
                                    14.754809
                                ],
                                [
                                    120.952853,
                                    14.754961
                                ],
                                [
                                    120.952933,
                                    14.755011
                                ],
                                [
                                    120.953143,
                                    14.755221
                                ],
                                [
                                    120.953196,
                                    14.755311
                                ],
                                [
                                    120.953253,
                                    14.755405
                                ],
                                [
                                    120.953283,
                                    14.755507
                                ],
                                [
                                    120.953315,
                                    14.755768
                                ],
                                [
                                    120.953402,
                                    14.755915
                                ],
                                [
                                    120.953227,
                                    14.756276
                                ],
                                [
                                    120.953386,
                                    14.756381
                                ],
                                [
                                    120.953876,
                                    14.756819
                                ],
                                [
                                    120.954075,
                                    14.757001
                                ],
                                [
                                    120.954712,
                                    14.757574
                                ],
                                [
                                    120.955285,
                                    14.75804
                                ],
                                [
                                    120.955957,
                                    14.758586
                                ],
                                [
                                    120.956605,
                                    14.759044
                                ],
                                [
                                    120.957049,
                                    14.759317
                                ],
                                [
                                    120.958084,
                                    14.759919
                                ],
                                [
                                    120.95833,
                                    14.760037
                                ],
                                [
                                    120.958408,
                                    14.760063
                                ],
                                [
                                    120.958784,
                                    14.760123
                                ],
                                [
                                    120.959103,
                                    14.760266
                                ],
                                [
                                    120.95917,
                                    14.760293
                                ],
                                [
                                    120.959385,
                                    14.760383
                                ],
                                [
                                    120.95956,
                                    14.760418
                                ],
                                [
                                    120.959718,
                                    14.760428
                                ],
                                [
                                    120.959813,
                                    14.760395
                                ],
                                [
                                    120.959892,
                                    14.760336
                                ],
                                [
                                    120.959936,
                                    14.7603
                                ],
                                [
                                    120.960066,
                                    14.760158
                                ],
                                [
                                    120.960161,
                                    14.760093
                                ],
                                [
                                    120.960399,
                                    14.759922
                                ],
                                [
                                    120.960711,
                                    14.759811
                                ],
                                [
                                    120.960803,
                                    14.759798
                                ],
                                [
                                    120.960948,
                                    14.759794
                                ],
                                [
                                    120.961209,
                                    14.759816
                                ],
                                [
                                    120.96136,
                                    14.759869
                                ],
                                [
                                    120.961484,
                                    14.759918
                                ],
                                [
                                    120.961554,
                                    14.759946
                                ],
                                [
                                    120.961767,
                                    14.760109
                                ],
                                [
                                    120.961826,
                                    14.760141
                                ],
                                [
                                    120.961867,
                                    14.760162
                                ],
                                [
                                    120.96205,
                                    14.760224
                                ],
                                [
                                    120.962123,
                                    14.760247
                                ],
                                [
                                    120.962318,
                                    14.760309
                                ],
                                [
                                    120.962661,
                                    14.760424
                                ],
                                [
                                    120.962945,
                                    14.760559
                                ],
                                [
                                    120.963246,
                                    14.760701
                                ],
                                [
                                    120.964073,
                                    14.761119
                                ],
                                [
                                    120.964473,
                                    14.76133
                                ],
                                [
                                    120.964501,
                                    14.761345
                                ],
                                [
                                    120.964594,
                                    14.761176
                                ],
                                [
                                    120.965808,
                                    14.758963
                                ],
                                [
                                    120.966527,
                                    14.757656
                                ],
                                [
                                    120.967044,
                                    14.756646
                                ],
                                [
                                    120.967072,
                                    14.756593
                                ],
                                [
                                    120.968315,
                                    14.754322
                                ],
                                [
                                    120.969653,
                                    14.751838
                                ],
                                [
                                    120.970418,
                                    14.750411
                                ],
                                [
                                    120.970583,
                                    14.750107
                                ],
                                [
                                    120.970623,
                                    14.750034
                                ],
                                [
                                    120.97067,
                                    14.74995
                                ],
                                [
                                    120.971325,
                                    14.748753
                                ],
                                [
                                    120.971585,
                                    14.748267
                                ],
                                [
                                    120.971657,
                                    14.748154
                                ],
                                [
                                    120.971733,
                                    14.748083
                                ],
                                [
                                    120.972061,
                                    14.747972
                                ],
                                [
                                    120.97247,
                                    14.747804
                                ],
                                [
                                    120.972796,
                                    14.747709
                                ],
                                [
                                    120.972855,
                                    14.747666
                                ],
                                [
                                    120.972879,
                                    14.747629
                                ],
                                [
                                    120.972946,
                                    14.747497
                                ],
                                [
                                    120.972893,
                                    14.747386
                                ],
                                [
                                    120.972789,
                                    14.747159
                                ],
                                [
                                    120.972485,
                                    14.746636
                                ],
                                [
                                    120.972187,
                                    14.745925
                                ],
                                [
                                    120.971983,
                                    14.745388
                                ],
                                [
                                    120.971953,
                                    14.7451
                                ],
                                [
                                    120.971915,
                                    14.745016
                                ],
                                [
                                    120.971793,
                                    14.744894
                                ],
                                [
                                    120.97183,
                                    14.744837
                                ],
                                [
                                    120.971915,
                                    14.744735
                                ],
                                [
                                    120.972048,
                                    14.744679
                                ],
                                [
                                    120.972098,
                                    14.744687
                                ],
                                [
                                    120.972566,
                                    14.744722
                                ],
                                [
                                    120.972718,
                                    14.744725
                                ],
                                [
                                    120.972874,
                                    14.744728
                                ],
                                [
                                    120.972944,
                                    14.744711
                                ],
                                [
                                    120.97302,
                                    14.744672
                                ],
                                [
                                    120.973061,
                                    14.744615
                                ],
                                [
                                    120.973534,
                                    14.743786
                                ],
                                [
                                    120.973801,
                                    14.74351
                                ],
                                [
                                    120.974243,
                                    14.74269
                                ],
                                [
                                    120.975688,
                                    14.740021
                                ],
                                [
                                    120.975957,
                                    14.739529
                                ],
                                [
                                    120.976205,
                                    14.739059
                                ],
                                [
                                    120.97679,
                                    14.737967
                                ],
                                [
                                    120.981638,
                                    14.728992
                                ],
                                [
                                    120.984228,
                                    14.724227
                                ],
                                [
                                    120.984774,
                                    14.723211
                                ],
                                [
                                    120.984961,
                                    14.722863
                                ],
                                [
                                    120.985534,
                                    14.721846
                                ],
                                [
                                    120.985919,
                                    14.721163
                                ],
                                [
                                    120.986384,
                                    14.720261
                                ],
                                [
                                    120.987682,
                                    14.717826
                                ],
                                [
                                    120.988793,
                                    14.71574
                                ],
                                [
                                    120.989819,
                                    14.713863
                                ],
                                [
                                    120.990087,
                                    14.713397
                                ],
                                [
                                    120.991055,
                                    14.71161
                                ],
                                [
                                    120.991931,
                                    14.709931
                                ],
                                [
                                    120.992385,
                                    14.709071
                                ],
                                [
                                    120.993236,
                                    14.707521
                                ],
                                [
                                    120.993881,
                                    14.706261
                                ],
                                [
                                    120.995151,
                                    14.703928
                                ],
                                [
                                    120.998797,
                                    14.697184
                                ],
                                [
                                    120.999288,
                                    14.696229
                                ],
                                [
                                    120.999541,
                                    14.695701
                                ],
                                [
                                    120.999789,
                                    14.695102
                                ],
                                [
                                    121.000033,
                                    14.694437
                                ],
                                [
                                    121.000238,
                                    14.693771
                                ],
                                [
                                    121.000306,
                                    14.693536
                                ],
                                [
                                    121.000393,
                                    14.693141
                                ],
                                [
                                    121.000508,
                                    14.692566
                                ],
                                [
                                    121.000638,
                                    14.691678
                                ],
                                [
                                    121.000697,
                                    14.69116
                                ],
                                [
                                    121.000765,
                                    14.690171
                                ],
                                [
                                    121.000745,
                                    14.688833
                                ],
                                [
                                    121.000742,
                                    14.688269
                                ],
                                [
                                    121.000665,
                                    14.685138
                                ],
                                [
                                    121.000635,
                                    14.684173
                                ],
                                [
                                    121.000602,
                                    14.682258
                                ],
                                [
                                    121.000561,
                                    14.681619
                                ],
                                [
                                    121.000468,
                                    14.681051
                                ],
                                [
                                    121.000033,
                                    14.679693
                                ],
                                [
                                    120.999929,
                                    14.679234
                                ],
                                [
                                    120.999873,
                                    14.678881
                                ],
                                [
                                    120.999873,
                                    14.6785
                                ],
                                [
                                    120.9999,
                                    14.678001
                                ],
                                [
                                    120.999973,
                                    14.677582
                                ],
                                [
                                    121.000201,
                                    14.676754
                                ],
                                [
                                    121.000374,
                                    14.676015
                                ],
                                [
                                    121.00043,
                                    14.675713
                                ],
                                [
                                    121.000451,
                                    14.675361
                                ],
                                [
                                    121.000267,
                                    14.667109
                                ],
                                [
                                    121.000195,
                                    14.663221
                                ],
                                [
                                    121.000186,
                                    14.66264
                                ],
                                [
                                    121.00014,
                                    14.661388
                                ],
                                [
                                    121.000115,
                                    14.660559
                                ],
                                [
                                    121.0001,
                                    14.659353
                                ],
                                [
                                    121.000102,
                                    14.65833
                                ],
                                [
                                    121.000089,
                                    14.657112
                                ],
                                [
                                    121.000032,
                                    14.656763
                                ],
                                [
                                    120.99995,
                                    14.656531
                                ],
                                [
                                    120.999831,
                                    14.656281
                                ],
                                [
                                    120.999785,
                                    14.656202
                                ],
                                [
                                    120.999626,
                                    14.655997
                                ],
                                [
                                    120.999313,
                                    14.655578
                                ],
                                [
                                    120.998791,
                                    14.65494
                                ],
                                [
                                    120.998662,
                                    14.654728
                                ],
                                [
                                    120.998466,
                                    14.654493
                                ],
                                [
                                    120.998262,
                                    14.654216
                                ],
                                [
                                    120.998037,
                                    14.65386
                                ],
                                [
                                    120.997802,
                                    14.653396
                                ],
                                [
                                    120.997652,
                                    14.653096
                                ],
                                [
                                    120.997434,
                                    14.65266
                                ],
                                [
                                    120.997336,
                                    14.652437
                                ],
                                [
                                    120.99718,
                                    14.652031
                                ],
                                [
                                    120.99652,
                                    14.650473
                                ],
                                [
                                    120.995989,
                                    14.649223
                                ],
                                [
                                    120.995853,
                                    14.648905
                                ],
                                [
                                    120.995822,
                                    14.648834
                                ],
                                [
                                    120.99544,
                                    14.647978
                                ],
                                [
                                    120.995284,
                                    14.647602
                                ],
                                [
                                    120.99498,
                                    14.64688
                                ],
                                [
                                    120.994599,
                                    14.645986
                                ],
                                [
                                    120.99432,
                                    14.645333
                                ],
                                [
                                    120.994249,
                                    14.645173
                                ],
                                [
                                    120.994127,
                                    14.644898
                                ],
                                [
                                    120.994011,
                                    14.644638
                                ],
                                [
                                    120.993807,
                                    14.644167
                                ],
                                [
                                    120.993692,
                                    14.643894
                                ],
                                [
                                    120.993293,
                                    14.643883
                                ],
                                [
                                    120.991704,
                                    14.643865
                                ],
                                [
                                    120.991399,
                                    14.643899
                                ],
                                [
                                    120.990898,
                                    14.644037
                                ],
                                [
                                    120.990823,
                                    14.644056
                                ],
                                [
                                    120.990335,
                                    14.644194
                                ],
                                [
                                    120.990074,
                                    14.644252
                                ],
                                [
                                    120.989354,
                                    14.644322
                                ],
                                [
                                    120.988662,
                                    14.644351
                                ],
                                [
                                    120.987942,
                                    14.644357
                                ],
                                [
                                    120.987567,
                                    14.64437
                                ],
                                [
                                    120.987214,
                                    14.644384
                                ],
                                [
                                    120.986836,
                                    14.644404
                                ],
                                [
                                    120.984542,
                                    14.644515
                                ],
                                [
                                    120.984347,
                                    14.644524
                                ],
                                [
                                    120.983628,
                                    14.64453
                                ],
                                [
                                    120.983608,
                                    14.644531
                                ],
                                [
                                    120.983514,
                                    14.644535
                                ],
                                [
                                    120.983506,
                                    14.644357
                                ],
                                [
                                    120.983489,
                                    14.643951
                                ],
                                [
                                    120.983444,
                                    14.643153
                                ],
                                [
                                    120.983408,
                                    14.641759
                                ],
                                [
                                    120.983368,
                                    14.640388
                                ],
                                [
                                    120.983322,
                                    14.639076
                                ],
                                [
                                    120.983319,
                                    14.638987
                                ],
                                [
                                    120.983281,
                                    14.63857
                                ],
                                [
                                    120.983244,
                                    14.638356
                                ],
                                [
                                    120.98318,
                                    14.638152
                                ],
                                [
                                    120.983057,
                                    14.637822
                                ],
                                [
                                    120.982923,
                                    14.637517
                                ],
                                [
                                    120.982811,
                                    14.637281
                                ],
                                [
                                    120.982718,
                                    14.637083
                                ],
                                [
                                    120.982516,
                                    14.636656
                                ],
                                [
                                    120.982324,
                                    14.636245
                                ],
                                [
                                    120.981543,
                                    14.634593
                                ],
                                [
                                    120.981433,
                                    14.634359
                                ],
                                [
                                    120.981402,
                                    14.634294
                                ],
                                [
                                    120.981169,
                                    14.63378
                                ],
                                [
                                    120.980739,
                                    14.632842
                                ],
                                [
                                    120.980648,
                                    14.632602
                                ],
                                [
                                    120.980521,
                                    14.63218
                                ],
                                [
                                    120.980448,
                                    14.631969
                                ],
                                [
                                    120.979918,
                                    14.630469
                                ],
                                [
                                    120.979893,
                                    14.630398
                                ],
                                [
                                    120.979397,
                                    14.628995
                                ],
                                [
                                    120.97885,
                                    14.627445
                                ],
                                [
                                    120.978704,
                                    14.627031
                                ],
                                [
                                    120.978649,
                                    14.62683
                                ],
                                [
                                    120.978502,
                                    14.625926
                                ],
                                [
                                    120.978143,
                                    14.623334
                                ],
                                [
                                    120.978117,
                                    14.623163
                                ],
                                [
                                    120.978091,
                                    14.622984
                                ],
                                [
                                    120.977826,
                                    14.620968
                                ],
                                [
                                    120.97764,
                                    14.619619
                                ],
                                [
                                    120.977419,
                                    14.618051
                                ],
                                [
                                    120.977243,
                                    14.61677
                                ],
                                [
                                    120.976928,
                                    14.615417
                                ],
                                [
                                    120.976685,
                                    14.614394
                                ],
                                [
                                    120.97656,
                                    14.613884
                                ],
                                [
                                    120.976268,
                                    14.612618
                                ],
                                [
                                    120.976034,
                                    14.611389
                                ],
                                [
                                    120.975877,
                                    14.610469
                                ],
                                [
                                    120.975839,
                                    14.610231
                                ],
                                [
                                    120.975655,
                                    14.609213
                                ],
                                [
                                    120.97548,
                                    14.608213
                                ],
                                [
                                    120.975465,
                                    14.608135
                                ],
                                [
                                    120.975257,
                                    14.607547
                                ],
                                [
                                    120.974918,
                                    14.606495
                                ],
                                [
                                    120.974855,
                                    14.606274
                                ],
                                [
                                    120.974878,
                                    14.606125
                                ],
                                [
                                    120.974844,
                                    14.606028
                                ],
                                [
                                    120.974457,
                                    14.60468
                                ],
                                [
                                    120.974402,
                                    14.604564
                                ],
                                [
                                    120.974383,
                                    14.604473
                                ],
                                [
                                    120.974272,
                                    14.60389
                                ],
                                [
                                    120.974259,
                                    14.603823
                                ],
                                [
                                    120.974067,
                                    14.602735
                                ],
                                [
                                    120.974004,
                                    14.602436
                                ],
                                [
                                    120.973955,
                                    14.602221
                                ],
                                [
                                    120.973888,
                                    14.601918
                                ],
                                [
                                    120.973838,
                                    14.601736
                                ],
                                [
                                    120.973792,
                                    14.60159
                                ],
                                [
                                    120.973612,
                                    14.600995
                                ],
                                [
                                    120.973577,
                                    14.60095
                                ],
                                [
                                    120.973504,
                                    14.6009
                                ],
                                [
                                    120.973384,
                                    14.600828
                                ],
                                [
                                    120.973357,
                                    14.600725
                                ],
                                [
                                    120.973377,
                                    14.600654
                                ],
                                [
                                    120.973919,
                                    14.599779
                                ],
                                [
                                    120.973938,
                                    14.599744
                                ],
                                [
                                    120.974048,
                                    14.599537
                                ],
                                [
                                    120.974267,
                                    14.59913
                                ],
                                [
                                    120.974571,
                                    14.598576
                                ],
                                [
                                    120.975378,
                                    14.597222
                                ],
                                [
                                    120.975621,
                                    14.596801
                                ],
                                [
                                    120.976296,
                                    14.597087
                                ],
                                [
                                    120.976387,
                                    14.597073
                                ],
                                [
                                    120.976456,
                                    14.596984
                                ],
                                [
                                    120.976703,
                                    14.596754
                                ],
                                [
                                    120.976818,
                                    14.596573
                                ],
                                [
                                    120.976966,
                                    14.596326
                                ],
                                [
                                    120.977602,
                                    14.595214
                                ],
                                [
                                    120.977796,
                                    14.594885
                                ],
                                [
                                    120.977742,
                                    14.594742
                                ],
                                [
                                    120.977692,
                                    14.594683
                                ],
                                [
                                    120.977556,
                                    14.594605
                                ],
                                [
                                    120.977432,
                                    14.594585
                                ],
                                [
                                    120.977035,
                                    14.594514
                                ],
                                [
                                    120.976353,
                                    14.594396
                                ],
                                [
                                    120.976062,
                                    14.594346
                                ],
                                [
                                    120.975599,
                                    14.594268
                                ],
                                [
                                    120.975436,
                                    14.59424
                                ],
                                [
                                    120.975371,
                                    14.594198
                                ],
                                [
                                    120.974974,
                                    14.593723
                                ],
                                [
                                    120.974866,
                                    14.59371
                                ],
                                [
                                    120.974195,
                                    14.593715
                                ],
                                [
                                    120.974123,
                                    14.593657
                                ],
                                [
                                    120.973053,
                                    14.592727
                                ],
                                [
                                    120.97252,
                                    14.592253
                                ],
                                [
                                    120.971957,
                                    14.591756
                                ],
                                [
                                    120.972334,
                                    14.591359
                                ],
                                [
                                    120.972541,
                                    14.591137
                                ],
                                [
                                    120.972855,
                                    14.590796
                                ],
                                [
                                    120.97309,
                                    14.590543
                                ],
                                [
                                    120.973627,
                                    14.589944
                                ],
                                [
                                    120.973853,
                                    14.590152
                                ],
                                [
                                    120.974185,
                                    14.590458
                                ],
                                [
                                    120.974382,
                                    14.590648
                                ],
                                [
                                    120.974681,
                                    14.590932
                                ]
                            ],
                            "type": "LineString"
                        }
                    }
                ],
                "metadata": {
                    "attribution": "openrouteservice.org | OpenStreetMap contributors",
                    "service": "routing",
                    "timestamp": 1747171247051,
                    "query": {
                        "coordinates": [
                            [
                                120.9482162,
                                14.7575517
                            ],
                            [
                                120.9746537,
                                14.5909588
                            ]
                        ],
                        "profile": "driving-car",
                        "profileName": "driving-car",
                        "format": "json"
                    },
                    "engine": {
                        "version": "9.2.0",
                        "build_date": "2025-05-06T08:31:01Z",
                        "graph_date": "2025-05-11T13:01:50Z"
                    }
                }
            }
            """;
        #endregion

        [Fact]
        public void CanGetGeoCodeProperty()
        {
            var displayNames = new[] 
            {
                "Manila, Capital District, Metro Manila, Philippines",
                "Manila Bay, Cavite, Calabarzon, Philippines",
                "Manila, Mississippi County, Arkansas, United States",
                "Manila, Humboldt County, California, United States",
                "Manila, Boone County, West Virginia, 25203, United States",
                "Manila, Bhikiasain, Almora District, Uttarakhand, 263667, India",
                "Manila, Bantwal taluk, Dakshina Kannada, Karnataka, 574260, India",
                "Manila, Gómez Palacio, Durango, Mexico",
                "Manila, Rapu-Rapu, Albay, Bicol Region, Philippines",
                "Manila, Johnson County, Kentucky, 41238, United States"
            };

            var objs = osmResult.GetGeoCodeProperties();
            var assertion = objs!.Select(p => p.DisplayName).All(displayNames.Contains);
            Assert.True(assertion);
        }

        [Fact]
        public void CanDjikstraGraph()
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
            var graph = JsonConvert.SerializeObject(orsResult.GetOpenRouteServiceProperty().GetSegment().GetSteps().GetGraph());
            Assert.Equal(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(output)), graph);
        }

        [Fact]
        public void GraphIsNotEmpty()
        {
            var x = mti.GetOpenRouteServiceProperty().GetSegment().GetSteps().GetGraph();
            var y = JsonConvert.SerializeObject(x);
            Assert.NotEmpty(x);
        }
    }
}
