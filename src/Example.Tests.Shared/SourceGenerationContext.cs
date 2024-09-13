using System.Text.Json.Serialization;

namespace Example.Tests.Shared;

/// <summary>
/// A source generated class that will contain JsonTypeInfo<T> prepared by System.Text.Json
/// </summary>
[JsonSerializable(typeof(AddPayload))]
[JsonSerializable(typeof(SumPayload))]
public partial class SourceGenerationContext : JsonSerializerContext;
