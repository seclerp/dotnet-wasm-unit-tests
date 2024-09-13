namespace Example.Tests;

/// <summary>This attribute is only used by the solution test infrastructure.</summary>
public class SolutionMetadataAttribute : Attribute
{
  public string SourceRoot { get; }
  public string ArtifactsRoot { get; }

  public SolutionMetadataAttribute(string sourceRoot, string artifactsRoot)
  {
    SourceRoot = sourceRoot;
    ArtifactsRoot = artifactsRoot;
  }
}
