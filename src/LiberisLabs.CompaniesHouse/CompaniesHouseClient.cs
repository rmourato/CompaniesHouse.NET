﻿using System.Threading;
using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.CompanySearch;
using LiberisLabs.CompaniesHouse.UriBuilders;
using LiberisLabs.CompaniesHouse.Response.CompanyProfile;

namespace LiberisLabs.CompaniesHouse
{
    public class CompaniesHouseClient : ICompaniesHouseClient
    {
        private readonly ICompaniesHouseSearchCompanyClient _companiesHouseSearchCompanyClient;
        private readonly ICompaniesHouseCompanyProfileClient _companiesHouseCompanyProfileClient;

        public CompaniesHouseClient(ICompaniesHouseSettings settings)
        {
            var httpClientFactory = new HttpClientFactory(settings);

            _companiesHouseSearchCompanyClient = new CompaniesHouseSearchCompanyClient(httpClientFactory, new CompanySearchUriBuilder());
            _companiesHouseCompanyProfileClient = new CompaniesHouseCompanyProfileClient(httpClientFactory, new CompanyProfileUriBuilder());
        }

        public Task<CompaniesHouseClientResponse<CompanySearch>> SearchCompanyAsync(CompanySearchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchCompanyClient.SearchCompanyAsync(request, cancellationToken);
        }

        public Task<CompaniesHouseClientResponse<CompanyProfile>> GetCompanyProfileAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseCompanyProfileClient.GetCompanyProfileAsync(companyNumber, cancellationToken);
        }
    }
}
