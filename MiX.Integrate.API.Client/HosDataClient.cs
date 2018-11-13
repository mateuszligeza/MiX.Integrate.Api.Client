﻿using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Carriers;
using MiX.Integrate.Shared.Entities.HosData;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class HosDataClient : BaseClient, IHosDataClient
	{
		public HosDataClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public HosDataClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public CreatedSinceResult<HosEvent> GetHosEventData(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime)
		{
			var dataRequest = new HosEventDataRequest { EntityTypeId = entityTypeId, EntityIds = entityIds, EventTypeIds = eventTypeIds };

			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETHOSEVENTDATA, HttpMethod.Post);

			request.AddUrlSegment("from", fromDateTime.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDateTime.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(dataRequest);

			IHttpRestResponse<List<HosEvent>> response = Execute<List<HosEvent>>(request);

			var sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			var getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");

			if (!bool.TryParse(sHasMoreItems, out var hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");

			return new CreatedSinceResult<HosEvent> { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<CreatedSinceResult<HosEvent>> GetHosEventDataAsync(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime)
		{
			var dataRequest = new HosEventDataRequest { EntityTypeId = entityTypeId, EntityIds = entityIds, EventTypeIds = eventTypeIds };

			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETHOSEVENTDATA, HttpMethod.Post);

			request.AddUrlSegment("from", fromDateTime.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDateTime.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(dataRequest);

			IHttpRestResponse<List<HosEvent>> response = await ExecuteAsync<List<HosEvent>>(request).ConfigureAwait(false);

			var sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			var getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");

			if (!bool.TryParse(sHasMoreItems, out var hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");

			return new CreatedSinceResult<HosEvent> { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public CreatedSinceResult<HosEvent> GetHosEventDataSince(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, string sinceToken)
		{
			var dataRequest = new HosEventDataRequest { EntityTypeId = entityTypeId, EntityIds = entityIds, EventTypeIds = eventTypeIds };

			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETHOSEVENTDATASINCE, HttpMethod.Post);

			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddJsonBody(dataRequest);

			IHttpRestResponse<List<HosEvent>> response = Execute<List<HosEvent>>(request);

			var sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			var getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");

			if (!bool.TryParse(sHasMoreItems, out var hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");

			return new CreatedSinceResult<HosEvent> { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<CreatedSinceResult<HosEvent>> GetHosEventDataSinceAsync(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, string sinceToken)
		{
			var dataRequest = new HosEventDataRequest { EntityTypeId = entityTypeId, EntityIds = entityIds, EventTypeIds = eventTypeIds };

			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETHOSEVENTDATASINCE, HttpMethod.Post);

			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddJsonBody(dataRequest);

			IHttpRestResponse<List<HosEvent>> response = await ExecuteAsync<List<HosEvent>>(request).ConfigureAwait(false);

			var sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			var getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");

			if (!bool.TryParse(sHasMoreItems, out var hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");

			return new CreatedSinceResult<HosEvent> { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public List<HosEventDriverSummary> GetHosEventDataSummary(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime)
		{
			var dataRequest = new HosEventDataRequest { EntityTypeId = entityTypeId, EntityIds = entityIds, EventTypeIds = eventTypeIds };

			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETHOSEVENTDATASUMMARY, HttpMethod.Post);

			request.AddUrlSegment("from", fromDateTime.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDateTime.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(dataRequest);

			IHttpRestResponse<List<HosEventDriverSummary>> response = Execute<List<HosEventDriverSummary>>(request);

			return response.Data;
		}

		public async Task<List<HosEventDriverSummary>> GetHosEventDataSummaryAsync(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime)
		{
			var dataRequest = new HosEventDataRequest { EntityTypeId = entityTypeId, EntityIds = entityIds, EventTypeIds = eventTypeIds };

			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETHOSEVENTDATASUMMARY, HttpMethod.Post);

			request.AddUrlSegment("from", fromDateTime.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDateTime.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(dataRequest);

			IHttpRestResponse<List<HosEventDriverSummary>> response = await ExecuteAsync<List<HosEventDriverSummary>>(request).ConfigureAwait(false);

			return response.Data;
		}

		public List<HosViolation> GetHosViolations(long driverId, DateTime fromDateTime, DateTime toDateTime)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETHOSVIOLATIONS, HttpMethod.Get);

			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("from", fromDateTime.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDateTime.ToString(DataFormats.DateTime_Format));

			IHttpRestResponse<List<HosViolation>> response = Execute<List<HosViolation>>(request);

			return response.Data;
		}

		public async Task<List<HosViolation>> GetHosViolationsAsync(long driverId, DateTime fromDateTime, DateTime toDateTime)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETHOSVIOLATIONS, HttpMethod.Get);

			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("from", fromDateTime.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDateTime.ToString(DataFormats.DateTime_Format));

			IHttpRestResponse<List<HosViolation>> response = await ExecuteAsync<List<HosViolation>>(request).ConfigureAwait(false);

			return response.Data;
		}

		public HosAvailableHours GetHosAvailableHours(long driverId, bool displayHiddenTimeTypes = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETHOSAVAILABLEHOURS, HttpMethod.Get);

			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("displayHiddenTimeTypes", displayHiddenTimeTypes.ToString());

			IHttpRestResponse<HosAvailableHours> response = Execute<HosAvailableHours>(request);

			return response.Data;
		}

		public async Task<HosAvailableHours> GetHosAvailableHoursAsync(long driverId, bool displayHiddenTimeTypes = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETHOSAVAILABLEHOURS, HttpMethod.Get);

			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("displayHiddenTimeTypes", displayHiddenTimeTypes.ToString());

			IHttpRestResponse<HosAvailableHours> response = await ExecuteAsync<HosAvailableHours>(request).ConfigureAwait(false);

			return response.Data;
		}
		public Dictionary<byte, string> GetWorkStateStatusSourceTypes()
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETWORKSTATESTATUSSOURCETYPES, HttpMethod.Get);

			IHttpRestResponse<Dictionary<byte, string>> response = Execute<Dictionary<byte, string>>(request);

			return response.Data;
		}
		public async Task<Dictionary<byte, string>> GetWorkStateStatusSourceTypesAsync()
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETWORKSTATESTATUSSOURCETYPES, HttpMethod.Get);

			IHttpRestResponse<Dictionary<byte, string>> response = await ExecuteAsync<Dictionary<byte, string>>(request).ConfigureAwait(false);
			return response.Data;
		}
		public List<RuleSetSummary> GetRuleSetSummaries(long organisationGroupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETRULESETSUMMARIES, HttpMethod.Get);

			request.AddUrlSegment("organisationId", organisationGroupId.ToString());

			IHttpRestResponse<List<RuleSetSummary>> response = Execute<List<RuleSetSummary>>(request);

			return response.Data;
		}
		public async Task<List<RuleSetSummary>> GetRuleSetSummariesAsync(long organisationGroupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETRULESETSUMMARIES, HttpMethod.Get);

			request.AddUrlSegment("organisationId", organisationGroupId.ToString());

			IHttpRestResponse<List<RuleSetSummary>> response = await ExecuteAsync<List<RuleSetSummary>>(request).ConfigureAwait(false);

			return response.Data;
		}

		public List<HosWorkStateDetail> GetHosWorkStatePerRegion(string region)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETHOSWORKSTATEPERREGION, HttpMethod.Get);

			request.AddUrlSegment("region", region);

			IHttpRestResponse<List<HosWorkStateDetail>> response = Execute<List<HosWorkStateDetail>>(request);

			return response.Data;
		}

		public async Task<List<HosWorkStateDetail>> GetHosWorkStatePerRegionAsync(string region)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.HosDataController.GETHOSWORKSTATEPERREGION, HttpMethod.Get);

			request.AddUrlSegment("region", region);

			IHttpRestResponse<List<HosWorkStateDetail>> response = await ExecuteAsync<List<HosWorkStateDetail>>(request).ConfigureAwait(false);

			return response.Data;
		}
	}
}
