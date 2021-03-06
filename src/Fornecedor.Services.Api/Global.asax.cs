﻿using System.Web;
using System.Web.Http;
using Fornecedor.Application.AutoMapper;
using FluentValidation.Mvc;

namespace Fornecedor.Services.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}