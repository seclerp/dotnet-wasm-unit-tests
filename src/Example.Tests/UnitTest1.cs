using Example.Tests.Shared;
using Extism.Sdk;

namespace Example.Tests;

public class UnitTest1
{
  static UnitTest1()
  {
    Environment.SetEnvironmentVariable("WASMTIME_BACKTRACE_DETAILS", "1");
  }

  [Fact]
  public void Test1()
  {
    //
    // Arrange
    var libraryModulePath = Path.Combine(SolutionMetadata.ArtifactsRoot, "bin", "Example.Tests.WasiHost", "debug_wasi-wasm", "AppBundle", "Example.Tests.WasiHost.wasm");
    var manifest = new Manifest(new PathWasmSource(libraryModulePath));
    using var plugin = new Plugin(manifest, functions: [], withWasi: true);

    //
    // Act
    var result = plugin.Call<AddPayload, SumPayload>("add", new AddPayload(123, 456)) ?? throw new ArgumentNullException();

    //
    // Assert
    Assert.Equal(579, result.Result);
  }
}
