﻿using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AndreasReitberger.API.REST.JSON.System
{
    /// <summary>
    /// Source: https://stackoverflow.com/a/64636093/10083577
    /// License: CC BY-SA 4.0 (https://creativecommons.org/licenses/by-sa/4.0/)
    /// Author: Shimmy Weitzhandler (https://stackoverflow.com/users/75500/shimmy-weitzhandler)
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    /// <typeparam name="TImplementation"></typeparam>
    public class TypeMappingConverter<TType, TImplementation> : JsonConverter<TType> where TImplementation : TType
    {
        [return: MaybeNull]
        public override TType Read(
          ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize<TImplementation>(ref reader, options);

        public override void Write(
          Utf8JsonWriter writer, TType value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, (TImplementation)value!, options);
    }
}
