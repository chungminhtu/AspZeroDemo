﻿using System.Collections.Generic;
using System.Linq;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Extensions;
using Microsoft.AspNetCore.Mvc.Razor;
using AspZeroDemo.AbpZeroDemo.Configuration;

namespace AspZeroDemo.AbpZeroDemo.Web.Startup
{
    /// <summary>
    /// That class is generated so that new areas that use default layout can use default components.
    /// </summary>
    public class RazorViewLocationExpander : IViewLocationExpander
    {
        public RazorViewLocationExpander()
        {
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            var currentThemeName = IocManager.Instance.Resolve<ISettingManager>()
                .GetSettingValue(AppSettings.UiManagement.Theme);

            var locations = viewLocations.ToList();

            //{0} is like "Components/{componentname}/{viewname}"
            locations.Add("~/Areas/AppZeroDemo/Views/Shared/{0}.cshtml");
            locations.Add("~/Areas/AppZeroDemo/Views/Shared/Themes/" + currentThemeName.ToPascalCase() +
                          "/{0}.cshtml");

            return locations;
        }
    }
}