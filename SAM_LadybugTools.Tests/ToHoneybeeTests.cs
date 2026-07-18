// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020-2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using SAM.Core;
using Xunit;

namespace SAM.Core.LadybugTools.Tests
{
    public static class ToHoneybeeTests
    {
        [Fact]
        public static void ToHoneybee_ModelJson_ValidHoneybee26_ShouldDeserialize()
        {
            string json = SampleJson.ModelWithOneRoom();

            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(json, out Log log);

            Assert.NotNull(result);
            Assert.IsType<HoneybeeSchema.Model>(result);

            var model = (HoneybeeSchema.Model)result;
            Assert.NotNull(model.Rooms);
            Assert.Single(model.Rooms);
        }

        [Fact]
        public static void ToHoneybee_RoomJson_ValidHoneybee26_ShouldDeserialize()
        {
            string json = SampleJson.RoomWithOneFace();

            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(json, out Log log);

            Assert.NotNull(result);
            Assert.IsType<HoneybeeSchema.Room>(result);

            var room = (HoneybeeSchema.Room)result;
            Assert.NotNull(room.Faces);
            Assert.Single(room.Faces);
        }

        [Fact]
        public static void ToHoneybee_MissingType_ShouldReturnNullAndLogError()
        {
            string json = @"{""identifier"":""test""}";

            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(json, out Log log);

            Assert.Null(result);
            Assert.NotNull(log);
            Assert.NotEmpty(log);
            Assert.Contains(log, x => x.LogRecordType == LogRecordType.Error);
        }

        [Fact]
        public static void ToHoneybee_EmptyType_ShouldReturnNullAndLogError()
        {
            string json = @"{""type"":"""",""identifier"":""test""}";

            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(json, out Log log);

            Assert.Null(result);
            Assert.NotNull(log);
            Assert.NotEmpty(log);
        }

        [Fact]
        public static void ToHoneybee_UnsupportedType_ShouldReturnNullAndLogWarning()
        {
            string json = @"{""type"":""Unicorn"",""identifier"":""test""}";

            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(json, out Log log);

            Assert.Null(result);
            Assert.NotNull(log);
            Assert.NotEmpty(log);
            Assert.Contains(log, x => x.LogRecordType == LogRecordType.Warning);
        }

        [Fact]
        public static void ToHoneybee_MalformedJson_ShouldReturnNullAndLogError()
        {
            string json = @"this is not json at all {{{";

            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(json, out Log log);

            Assert.Null(result);
            Assert.NotNull(log);
            Assert.NotEmpty(log);
            Assert.Contains(log, x => x.LogRecordType == LogRecordType.Error);
        }

        [Fact]
        public static void ToHoneybee_NullString_ShouldReturnNullWithErrorLog()
        {
            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee((string)null, out Log log);

            Assert.Null(result);
            Assert.NotNull(log);
            Assert.NotEmpty(log);
            Assert.Contains(log, x => x.LogRecordType == LogRecordType.Error);
        }

        [Fact]
        public static void ToHoneybee_EmptyString_ShouldReturnNullWithErrorLog()
        {
            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(string.Empty, out Log log);

            Assert.Null(result);
            Assert.NotNull(log);
            Assert.NotEmpty(log);
            Assert.Contains(log, x => x.LogRecordType == LogRecordType.Error);
        }

        [Fact]
        public static void ToHoneybee_MissingVersion_ShouldNotFail()
        {
            string json = SampleJson.RoomWithoutVersion();

            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(json, out Log log);

            Assert.NotNull(result);
            Assert.IsType<HoneybeeSchema.Room>(result);
        }

        [Fact]
        public static void ToHoneybee_Face_ShouldDeserialize()
        {
            string json = SampleJson.FaceJson();

            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(json, out Log log);

            Assert.NotNull(result);
            Assert.IsType<HoneybeeSchema.Face>(result);
        }

        [Fact]
        public static void ToHoneybee_Aperture_ShouldDeserialize()
        {
            string json = SampleJson.ApertureJson();

            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(json, out Log log);

            Assert.NotNull(result);
            Assert.IsType<HoneybeeSchema.Aperture>(result);
        }

        [Fact]
        public static void ToHoneybee_Door_ShouldDeserialize()
        {
            string json = SampleJson.DoorJson();

            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(json, out Log log);

            Assert.NotNull(result);
            Assert.IsType<HoneybeeSchema.Door>(result);
        }

        [Fact]
        public static void ToHoneybee_Shade_ShouldDeserialize()
        {
            string json = SampleJson.ShadeJson();

            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(json, out Log log);

            Assert.NotNull(result);
            Assert.IsType<HoneybeeSchema.Shade>(result);
        }

        [Fact]
        public static void ToHoneybee_ModelFromJson_RoundTrip_PreservesRoomCount()
        {
            string json = SampleJson.ModelWithThreeRooms();

            HoneybeeSchema.IDdBaseModel result = Convert.ToHoneybee(json, out Log log);

            Assert.NotNull(result);
            var model = Assert.IsType<HoneybeeSchema.Model>(result);
            Assert.NotNull(model.Rooms);
            Assert.Equal(3, model.Rooms.Count);

            string reSerialized = model.ToJson();
            HoneybeeSchema.IDdBaseModel reResult = Convert.ToHoneybee(reSerialized, out Log reLog);

            Assert.NotNull(reResult);
            var reModel = Assert.IsType<HoneybeeSchema.Model>(reResult);
            Assert.Equal(3, reModel.Rooms.Count);
        }

        [Fact]
        public static void ToHoneybee_JsonDocumentExtension_ShouldDeserialize()
        {
            string json = SampleJson.ModelWithOneRoom();
            var jsonDocument = System.Text.Json.JsonDocument.Parse(json);

            HoneybeeSchema.IDdBaseModel result = jsonDocument.ToHoneybee(out Log log);

            Assert.NotNull(result);
            Assert.IsType<HoneybeeSchema.Model>(result);
        }

        [Fact]
        public static void ToHoneybee_LoglessOverloads_ShouldNotThrow()
        {
            string json = SampleJson.ModelWithOneRoom();

            HoneybeeSchema.IDdBaseModel result1 = Convert.ToHoneybee(json);
            Assert.NotNull(result1);

            var jsonDocument = System.Text.Json.JsonDocument.Parse(json);
            HoneybeeSchema.IDdBaseModel result2 = Convert.ToHoneybee(jsonDocument);
            Assert.NotNull(result2);
        }
    }
}
