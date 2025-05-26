using Lib.Universal.Primitives;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Queries;

public abstract class PartitionKeyValue : ToSystemType<PartitionKey>;