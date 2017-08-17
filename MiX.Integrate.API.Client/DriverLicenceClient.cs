﻿using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Drivers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public class DriverLicenceClient : BaseClient, IDriverLicenceClient
	{
		public DriverLicenceClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DriverLicenceClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public IList<DriverLicence> GetDriverLicencesByDriverId(long organisationGroupId, long driverId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.GETDRIVERLICENCESASYNC, Method.GET);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IRestResponse<List<DriverLicence>> response = Execute<List<DriverLicence>>(request);
			return response.Data;
		}

		public async Task<IList<DriverLicence>> GetDriverLicencesByDriverIdAsync(long organisationGroupId, long driverId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.GETDRIVERLICENCESASYNC, Method.GET);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IRestResponse<List<DriverLicence>> response = await ExecuteAsync<List<DriverLicence>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public DriverLicence GetDriverLicenceById(long organisationGroupId, long driverId, int licenceCategoryId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.GETDRIVERLICENCEASYNC, Method.GET);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("licenceCategoryId", licenceCategoryId.ToString());
			IRestResponse<DriverLicence> response = Execute<DriverLicence>(request);
			return response.Data;
		}

		public async Task<DriverLicence> GetDriverLicenceByIdAsync(long organisationGroupId, long driverId, int licenceCategoryId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.GETDRIVERLICENCEASYNC, Method.GET);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("licenceCategoryId", licenceCategoryId.ToString());
			IRestResponse<DriverLicence> response = await ExecuteAsync<DriverLicence>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<LicenceCategory> GetDriverLicenceCategories(long organisationGroupId, long driverId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.GETDRIVERLICENCECATEGORIESSYNC, Method.GET);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IRestResponse<List<LicenceCategory>> response = Execute<List<LicenceCategory>>(request);
			return response.Data;
		}

		public async Task<IList<LicenceCategory>> GetDriverLicenceCategoriesAsync(long organisationGroupId, long driverId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.GETDRIVERLICENCECATEGORIESSYNC, Method.GET);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IRestResponse<List<LicenceCategory>> response = await ExecuteAsync<List<LicenceCategory>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public void AddDriverLicence(long organisationGroupId, DriverLicence driverLicence)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.ADDDRIVERLICENCEASYNC, Method.PUT);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverLicence);
			Execute(request);
		}

		public async Task AddDriverLicenceAsync(long organisationGroupId, DriverLicence driverLicence)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.ADDDRIVERLICENCEASYNC, Method.PUT);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverLicence);
			await ExecuteAsync(request).ConfigureAwait(false);
		}


		public void UpdateDriverLicence(long organisationGroupId, DriverLicence driverLicence)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.UPDATEDRIVERLICENCEASYNC, Method.PUT);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverLicence);
			Execute(request);
		}

		public async Task UpdateDriverLicenceAsync(long organisationGroupId, DriverLicence driverLicence)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.UPDATEDRIVERLICENCEASYNC, Method.PUT);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverLicence);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public void DeleteDriverLicence(long organisationGroupId, long driverId, int licenceCategoryId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.DELETEDRIVERLICENCEASYNC, Method.PUT);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("licenceCategoryId", licenceCategoryId.ToString());
			Execute(request);
		}

		public async Task DeleteDriverLicenceAsync(long organisationGroupId, long driverId, int licenceCategoryId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.DELETEDRIVERLICENCEASYNC, Method.PUT);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("licenceCategoryId", licenceCategoryId.ToString());
			await ExecuteAsync(request).ConfigureAwait(false);
		}

	}
}
