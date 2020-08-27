﻿using System.Threading.Tasks;
using Abp.Application.Services;
using AspZeroDemo.AbpZeroDemo.Configuration.Tenants.Dto;

namespace AspZeroDemo.AbpZeroDemo.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
