# dotnet-wasm-unit-tests

!['main' Build status](../../actions/workflows/build.yml/badge.svg?branch=main)

An example of how .NET assemblies compiled into wasi-wasm module could be tested in true WASI WASM environment.

The example is based on the Extism platform - a high level interop and serialization abstraction over regular WASI WASM modules
initially designed for enriching applications with plugin support.

## How it works

- `Example.Library`: the code that should be tested, zero dependencies on Wasm stuff
- `Example.Tests.WasiHost`: a project that bundles actual library, compiles to wasi-wasm module and provides exports used by test project
- `Example.Tests.Shared`: contains payloads used by both test project and library
- `Example.Tests`: the xUnit test project that hosts Extism runtime and executes exports from WasiHost

Declared MSBuild target from `wasi-experimental` workload builds `Example.Tests.WasiHost` as a `.wasm` module. This module already
contains library logic, as it references `Example.Library`. Then, `Example.Tests` test project loads `.wasm` module as an Extism plugin
and executes the logic under test execution. The interop between WASI runtime and compiled module is done by Extism, including serialization of complex objects.
Shared models are placed in `Example.Tests.Shared` project.

## Dependencies

### .NET SDK 8
Minimal supported version of .NET SDK is 8. 

### `wasi-experimental`
Extism uses `wasi-experimental` toolset and `wasi-wasm` runtime identifier, so the appropriate workload should be installed
```shell
dotnet workload install wasi-experimental
```

### WASI SDK
To build native part of the party WASI SDK is required.

1. Download WASI SDK from [the releases page](https://github.com/WebAssembly/wasi-sdk/releases)
2. Export env var `WASI_SDK_PATH=/path/to/wasi-sdk`

Alternatively, you could install WASI SDK using the Powershell script from 
[dotnet/runtimelab](https://github.com/dotnet/runtimelab/blob/feature/NativeAOT-LLVM/eng/pipelines/runtimelab/install-wasi-sdk.ps1).