﻿using Lib.Cosmos.Apis.Queries;
using Microsoft.Azure.Cosmos;
using TestConvenience.Universal.Tests;

namespace Lib.Cosmos.Tests.Apis.Queries;

[TestClass]
public sealed class SimpleQueryDefinitionTests : BaseToSystemTypeTests<SimpleQueryDefinition, QueryDefinition> { }