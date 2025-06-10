using System.Net;
using Lib.Cosmos.Apis.Operators.Responses;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.OpResponses;

internal sealed class DatabaseOpResponse : OpResponse<Database>
{
    private readonly DatabaseResponse _databaseResponse;

    public DatabaseOpResponse(DatabaseResponse databaseResponse) => _databaseResponse = databaseResponse;

    public override Database Value => _databaseResponse.Database;

    public override HttpStatusCode StatusCode => _databaseResponse.StatusCode;
}