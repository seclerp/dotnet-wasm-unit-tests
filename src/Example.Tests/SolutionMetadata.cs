using System.Reflection;

namespace Example.Tests;

public static class SolutionMetadata
{
  public static string SourceRoot => ResolvedAttribute.Value.SourceRoot;
  public static string ArtifactsRoot => ResolvedAttribute.Value.ArtifactsRoot;

    private static Lazy<SolutionMetadataAttribute> ResolvedAttribute { get; } = new(() =>
        Assembly.GetExecutingAssembly().GetCustomAttribute<SolutionMetadataAttribute>()
        ?? throw new Exception($"Missing {nameof(SolutionMetadataAttribute)} metadata attribute."));
}
