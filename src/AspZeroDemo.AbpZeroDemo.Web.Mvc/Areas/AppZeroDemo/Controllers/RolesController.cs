﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using AspZeroDemo.AbpZeroDemo.Authorization;
using AspZeroDemo.AbpZeroDemo.Authorization.Permissions;
using AspZeroDemo.AbpZeroDemo.Authorization.Permissions.Dto;
using AspZeroDemo.AbpZeroDemo.Authorization.Roles;
using AspZeroDemo.AbpZeroDemo.Web.Areas.AppZeroDemo.Models.Roles;
using AspZeroDemo.AbpZeroDemo.Web.Controllers;

namespace AspZeroDemo.AbpZeroDemo.Web.Areas.AppZeroDemo.Controllers
{
    [Area("AppZeroDemo")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Roles)]
    public class RolesController : AbpZeroDemoControllerBase
    {
        private readonly IRoleAppService _roleAppService;
        private readonly IPermissionAppService _permissionAppService;

        public RolesController(
            IRoleAppService roleAppService,
            IPermissionAppService permissionAppService)
        {
            _roleAppService = roleAppService;
            _permissionAppService = permissionAppService;
        }

        public ActionResult Index()
        {
            var permissions = _permissionAppService.GetAllPermissions().Items.ToList();

            var model = new RoleListViewModel
            {
                Permissions = ObjectMapper.Map<List<FlatPermissionDto>>(permissions).OrderBy(p => p.DisplayName).ToList(),
                GrantedPermissionNames = new List<string>()
            };

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Roles_Create, AppPermissions.Pages_Administration_Roles_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = await _roleAppService.GetRoleForEdit(new NullableIdDto { Id = id });
            var viewModel = ObjectMapper.Map<CreateOrEditRoleModalViewModel>(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}