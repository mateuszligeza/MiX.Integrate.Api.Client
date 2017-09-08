﻿using System.Collections.Generic;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Drivers;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;
using System;

namespace MiX.Integrate.Api.Client
{
	public class DriversClient : BaseClient, IDriversClient
	{
		public DriversClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DriversClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<DriverSummary> GetAllDriverSummaries(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETALLDRIVERSUMMARIES, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IHttpRestResponse<List<DriverSummary>> response = Execute<List<DriverSummary>>(request);
			return response.Data;
		}

		public async Task<List<DriverSummary>> GetAllDriverSummariesAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETALLDRIVERSUMMARIES, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IHttpRestResponse<List<DriverSummary>> response = await ExecuteAsync<List<DriverSummary>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Driver GetDriverById(long groupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETDRIVERBYID, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IHttpRestResponse<Driver> response = Execute<Driver>(request);
			return response.Data;
		}

		public async Task<Driver> GetDriverByIdAsync(long groupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETDRIVERBYID, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IHttpRestResponse<Driver> response = await ExecuteAsync<Driver>(request).ConfigureAwait(false);
			return response.Data;
		}

		public void UpdateDriver(Driver driver)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.UPDATEDRIVERASYNC, HttpMethod.Put);
			request.AddJsonBody(driver);
			Execute(request);
		}

		public async Task UpdateDriverAsync(Driver driver)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.UPDATEDRIVERASYNC, HttpMethod.Put);
			request.AddJsonBody(driver);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public long AddDriver(Driver driver)
		{
			if (driver.FmDriverId == -1 || driver.FmDriverId == 0 || driver.FmDriverId == 1) throw new ArgumentException("FmDriverId -1, 0 and 1 was reserved");
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.ADDDRIVERASYNC, HttpMethod.Post);
			request.AddJsonBody(driver);
			IHttpRestResponse response = Execute(request);
			var idHeaderVal = GetResponseHeader(response.Headers, "driverid");
			long driverId;
			if (!long.TryParse(idHeaderVal, out driverId) || driverId == 0)
				throw new Exception("Could not determine the id of the newly-created driver");
			return driverId;
		}

		public async Task<long> AddDriverAsync(Driver driver)
		{
			if (driver.FmDriverId == -1 || driver.FmDriverId == 0 || driver.FmDriverId == 1) throw new ArgumentException("FmDriverId -1, 0 and 1 was reserved");
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.ADDDRIVERASYNC, HttpMethod.Post);
			request.AddJsonBody(driver);
			IHttpRestResponse response = await ExecuteAsync(request).ConfigureAwait(false);
			var idHeaderVal = GetResponseHeader(response.Headers, "driverid");
			long driverId;
			if (!long.TryParse(idHeaderVal, out driverId) || driverId == 0)
				throw new Exception("Could not determine the id of the newly-created driver");
			return driverId;
		}

	}
}