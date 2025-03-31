using Lib.Cosmos.Primitives;
using Lib.Universal.Primitives;
using TestConvenience.Universal.Tests;

namespace Lib.Cosmos.Tests.Primitives;

[TestClass]
public sealed class CosmosAccountNameTests : BaseToSystemTypeTests<CosmosAccountName, string>;

[TestClass]
public sealed class CosmosDatabaseNameTests : BaseToSystemTypeTests<CosmosDatabaseName, string>;

public abstract class CosmosDatabaseName : ToSystemType<string>;
