﻿namespace Emploee.Web
{
    public interface IWebUrlService
    {
        string GetSiteRootAddress(string tenancyName = null);

        bool SupportsTenancyNameInUrl { get; }
    }
}
