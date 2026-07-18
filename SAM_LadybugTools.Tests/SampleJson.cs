// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020-2026 Michal Dengusiak & Jakub Ziolkowski and contributors
namespace SAM.Core.LadybugTools.Tests
{
    /// <summary>
    /// Representative Honeybee Schema 2.6 JSON samples for testing.
    /// </summary>
    public static class SampleJson
    {
        public static string ModelWithOneRoom()
        {
            return @"{
  ""type"": ""Model"",
  ""version"": ""2.6.0"",
  ""identifier"": ""TestModel"",
  ""display_name"": ""Test Model"",
  ""rooms"": [
    {
      ""type"": ""Room"",
      ""identifier"": ""TestRoom"",
      ""display_name"": ""Test Room"",
      ""faces"": [
        {
          ""type"": ""Face"",
          ""identifier"": ""TestRoom_Face0"",
          ""display_name"": ""Face 0"",
          ""geometry"": {
            ""type"": ""Face3D"",
            ""boundary"": [
              [0.0, 0.0, 0.0],
              [1.0, 0.0, 0.0],
              [1.0, 0.0, 1.0],
              [0.0, 0.0, 1.0]
            ]
          },
          ""face_type"": ""Floor"",
          ""boundary_condition"": {
            ""type"": ""Outdoors""
          },
          ""properties"": {
            ""type"": ""FacePropertiesAbridged"",
            ""energy"": {
              ""type"": ""FaceEnergyPropertiesAbridged""
            }
          }
        }
      ],
      ""properties"": {
        ""type"": ""RoomPropertiesAbridged"",
        ""energy"": {
          ""type"": ""RoomEnergyPropertiesAbridged""
        }
      }
    }
  ],
  ""properties"": {
    ""type"": ""ModelProperties"",
    ""energy"": {
      ""type"": ""ModelEnergyProperties"",
      ""constructions"": [],
      ""construction_sets"": [],
      ""materials"": [],
      ""hvacs"": [],
      ""program_types"": [],
      ""schedules"": [],
      ""schedule_type_limits"": []
    }
  }
}";
        }

        public static string ModelWithThreeRooms()
        {
            return @"{
  ""type"": ""Model"",
  ""version"": ""2.6.0"",
  ""identifier"": ""ThreeRoomModel"",
  ""display_name"": ""Three Room Model"",
  ""rooms"": [
    {
      ""type"": ""Room"",
      ""identifier"": ""Room_001"",
      ""display_name"": ""Room 001"",
      ""faces"": [
        {
          ""type"": ""Face"",
          ""identifier"": ""Room_001_Face0"",
          ""display_name"": ""Face 0"",
          ""geometry"": {
            ""type"": ""Face3D"",
            ""boundary"": [[0,0,0],[1,0,0],[1,0,1],[0,0,1]]
          },
          ""face_type"": ""Floor"",
          ""boundary_condition"": { ""type"": ""Ground"" },
          ""properties"": { ""type"": ""FacePropertiesAbridged"", ""energy"": { ""type"": ""FaceEnergyPropertiesAbridged"" } }
        }
      ],
      ""properties"": { ""type"": ""RoomPropertiesAbridged"", ""energy"": { ""type"": ""RoomEnergyPropertiesAbridged"" } }
    },
    {
      ""type"": ""Room"",
      ""identifier"": ""Room_002"",
      ""display_name"": ""Room 002"",
      ""faces"": [
        {
          ""type"": ""Face"",
          ""identifier"": ""Room_002_Face0"",
          ""display_name"": ""Face 0"",
          ""geometry"": {
            ""type"": ""Face3D"",
            ""boundary"": [[1,0,0],[2,0,0],[2,0,1],[1,0,1]]
          },
          ""face_type"": ""Floor"",
          ""boundary_condition"": { ""type"": ""Ground"" },
          ""properties"": { ""type"": ""FacePropertiesAbridged"", ""energy"": { ""type"": ""FaceEnergyPropertiesAbridged"" } }
        }
      ],
      ""properties"": { ""type"": ""RoomPropertiesAbridged"", ""energy"": { ""type"": ""RoomEnergyPropertiesAbridged"" } }
    },
    {
      ""type"": ""Room"",
      ""identifier"": ""Room_003"",
      ""display_name"": ""Room 003"",
      ""faces"": [
        {
          ""type"": ""Face"",
          ""identifier"": ""Room_003_Face0"",
          ""display_name"": ""Face 0"",
          ""geometry"": {
            ""type"": ""Face3D"",
            ""boundary"": [[2,0,0],[3,0,0],[3,0,1],[2,0,1]]
          },
          ""face_type"": ""Floor"",
          ""boundary_condition"": { ""type"": ""Ground"" },
          ""properties"": { ""type"": ""FacePropertiesAbridged"", ""energy"": { ""type"": ""FaceEnergyPropertiesAbridged"" } }
        }
      ],
      ""properties"": { ""type"": ""RoomPropertiesAbridged"", ""energy"": { ""type"": ""RoomEnergyPropertiesAbridged"" } }
    }
  ],
  ""properties"": {
    ""type"": ""ModelProperties"",
    ""energy"": {
      ""type"": ""ModelEnergyProperties"",
      ""constructions"": [],
      ""construction_sets"": [],
      ""materials"": [],
      ""hvacs"": [],
      ""program_types"": [],
      ""schedules"": [],
      ""schedule_type_limits"": []
    }
  }
}";
        }

        public static string RoomWithOneFace()
        {
            return @"{
  ""type"": ""Room"",
  ""identifier"": ""TestRoom"",
  ""display_name"": ""Test Room"",
  ""faces"": [
    {
      ""type"": ""Face"",
      ""identifier"": ""TestRoom_Face0"",
      ""display_name"": ""Face 0"",
      ""geometry"": {
        ""type"": ""Face3D"",
        ""boundary"": [[0,0,0],[1,0,0],[1,0,1],[0,0,1]]
      },
      ""face_type"": ""Floor"",
      ""boundary_condition"": { ""type"": ""Outdoors"" },
      ""properties"": { ""type"": ""FacePropertiesAbridged"", ""energy"": { ""type"": ""FaceEnergyPropertiesAbridged"" } }
    }
  ],
  ""properties"": { ""type"": ""RoomPropertiesAbridged"", ""energy"": { ""type"": ""RoomEnergyPropertiesAbridged"" } }
}";
        }

        public static string RoomWithoutVersion()
        {
            return @"{
  ""type"": ""Room"",
  ""identifier"": ""NoVersionRoom"",
  ""display_name"": ""Room Without Version"",
  ""faces"": [
    {
      ""type"": ""Face"",
      ""identifier"": ""NoVersionRoom_Face0"",
      ""display_name"": ""Face 0"",
      ""geometry"": {
        ""type"": ""Face3D"",
        ""boundary"": [[0,0,0],[1,0,0],[1,0,1],[0,0,1]]
      },
      ""face_type"": ""Floor"",
      ""boundary_condition"": { ""type"": ""Outdoors"" },
      ""properties"": { ""type"": ""FacePropertiesAbridged"", ""energy"": { ""type"": ""FaceEnergyPropertiesAbridged"" } }
    }
  ],
  ""properties"": { ""type"": ""RoomPropertiesAbridged"", ""energy"": { ""type"": ""RoomEnergyPropertiesAbridged"" } }
}";
        }

        public static string FaceJson()
        {
            return @"{
  ""type"": ""Face"",
  ""identifier"": ""TestFace"",
  ""display_name"": ""Test Face"",
  ""geometry"": {
    ""type"": ""Face3D"",
    ""boundary"": [[0,0,0],[1,0,0],[1,0,1],[0,0,1]]
  },
  ""face_type"": ""Wall"",
  ""boundary_condition"": { ""type"": ""Outdoors"" },
  ""properties"": { ""type"": ""FacePropertiesAbridged"", ""energy"": { ""type"": ""FaceEnergyPropertiesAbridged"" } }
}";
        }

        public static string ApertureJson()
        {
            return @"{
  ""type"": ""Aperture"",
  ""identifier"": ""TestAperture"",
  ""display_name"": ""Test Aperture"",
  ""geometry"": {
    ""type"": ""Face3D"",
    ""boundary"": [[0.2,0,0.8],[0.8,0,0.8],[0.8,0,0.2],[0.2,0,0.2]]
  },
  ""boundary_condition"": { ""type"": ""Outdoors"" },
  ""properties"": { ""type"": ""AperturePropertiesAbridged"", ""energy"": { ""type"": ""ApertureEnergyPropertiesAbridged"" } }
}";
        }

        public static string DoorJson()
        {
            return @"{
  ""type"": ""Door"",
  ""identifier"": ""TestDoor"",
  ""display_name"": ""Test Door"",
  ""geometry"": {
    ""type"": ""Face3D"",
    ""boundary"": [[0.4,0,0.6],[0.6,0,0.6],[0.6,0,0.0],[0.4,0,0.0]]
  },
  ""boundary_condition"": { ""type"": ""Outdoors"" },
  ""is_glass"": false,
  ""properties"": { ""type"": ""DoorPropertiesAbridged"", ""energy"": { ""type"": ""DoorEnergyPropertiesAbridged"" } }
}";
        }

        public static string ShadeJson()
        {
            return @"{
  ""type"": ""Shade"",
  ""identifier"": ""TestShade"",
  ""display_name"": ""Test Shade"",
  ""geometry"": {
    ""type"": ""Face3D"",
    ""boundary"": [[0,1,0],[1,1,0],[1,1,1],[0,1,1]]
  },
  ""properties"": { ""type"": ""ShadePropertiesAbridged"", ""energy"": { ""type"": ""ShadeEnergyPropertiesAbridged"" } }
}";
        }
    }
}
