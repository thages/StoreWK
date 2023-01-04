﻿global using Autofac;
global using Autofac.Extensions.DependencyInjection;
global using Catalog.API;
global using Catalog.API.Controllers;
global using Catalog.API.Infrastructure.AutofacModules;
global using Catalog.API.Infrastructure.ActionResults;
global using Catalog.API.Infrastructure.Filters;
global using Catalog.API.Application.Behaviors;
global using Catalog.API.Application.Commands;
global using Catalog.API.Application.Queries;
global using Catalog.API.Application.Queries.Products;
global using Catalog.API.Application.Validations;
global using Catalog.API.Application.Handlers;
global using Catalog.BuildingBlocks.EventBus.Abstractions;
global using Catalog.BuildingBlocks.EventBus.Events;
global using Catalog.BuildingBlocks.EventBus.Extensions;
global using Catalog.BuildingBlocks.EventBus;
global using Catalog.BuildingBlocks.EventBusRabbitMQ;
global using Catalog.BuildingBlocks.IntegrationEventLogEF.Services;
global using Catalog.BuildingBlocks.IntegrationEventLogEF;
global using Catalog.Domain.AggregatesModel.ProductAggregate;
global using Catalog.Domain.AggregatesModel.CategoryAggregate;
global using Catalog.Domain.AggregatesModel.Common;
global using Catalog.Domain.DataTransferObjects;
global using Catalog.Domain.Events;
global using Catalog.Domain.Exceptions;
global using Catalog.Domain.SeedWork;
global using Catalog.Infrastructure;
global using Catalog.Infrastructure.Repositories;
global using Dapper;
global using FluentValidation;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc.Authorization;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.AspNetCore.Server.Kestrel.Core;
global using Microsoft.AspNetCore;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;
global using Pomelo.EntityFrameworkCore.MySql;
global using RabbitMQ.Client;
global using Serilog.Context;
global using Serilog;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using System;
global using System.Collections.Generic;
global using System.Data.Common;
global using MySql.Data.MySqlClient;
global using System.IO;
global using System.Linq;
global using System.Net;
global using System.Reflection;
global using System.Runtime.Serialization;
global using System.Threading.Tasks;
global using System.Threading;

