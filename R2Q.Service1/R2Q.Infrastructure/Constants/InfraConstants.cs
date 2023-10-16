﻿namespace R2Q.Infrastructure.Constants
{
    public static class InfraConstants
    {

        public const string ConnectionStringKey = "ApplicationDb";
        public const string CacheConnectionStringKey = "DistributedCache";
        public const string EnvironmentNameKey = "ASPNETCORE_ENVIRONMENT";

        public const string EmailTemplatesPath = "/Templates/Email/";
        public const string EmailHeaderTemplateFileName = "Header.html";
        public const string EmailFooterTemplateFileName = "Footer.html";

        public const string EnglishUsCultureName = "en-US";
        #region Common

        public const string HtmlFileExtension = ".html";
        public const string DaprSideCarService1Endpoint = "http://localhost:3500";
        public const string DaprSideCarService1 = "r2q-service3";
        #endregion
    }
}
