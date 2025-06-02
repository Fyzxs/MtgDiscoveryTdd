using Lib.Universal.Primitives;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Primitives;

public abstract class PartitionKeyValue : ToSystemType<PartitionKey>;
