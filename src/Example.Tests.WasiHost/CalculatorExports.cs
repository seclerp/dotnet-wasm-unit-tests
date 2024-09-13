using System.Runtime.InteropServices;
using Example.Tests.Shared;
using Extism;

namespace Example.Tests.WasiHost;

public static class CalculatorExports
{
  [UnmanagedCallersOnly(EntryPoint = "add")]
  public static int Add()
  {
    var parameters = Pdk.GetInputJson(SourceGenerationContext.Default.AddPayload);

    var calculator = new Library.Calculator();
    var result = calculator.Sum(parameters.A, parameters.B);
    var sum = new SumPayload(result);

    Pdk.SetOutputJson(sum, SourceGenerationContext.Default.SumPayload);
    return 0;
  }
}
