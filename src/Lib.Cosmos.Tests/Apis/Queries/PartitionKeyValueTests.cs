using Lib.Cosmos.Apis.Primitives;
using Microsoft.Azure.Cosmos;
using TestConvenience.Universal.Tests;

namespace Lib.Cosmos.Tests.Apis.Queries;

[TestClass]
public sealed class PartitionKeyValueTests : BaseToSystemTypeTests<PartitionKeyValue, PartitionKey>;
