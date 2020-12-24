using System.Threading.Tasks;
using SSCMS.Parse;
using SSCMS.Plugins;
using SSCMS.Repositories;
using SSCMS.Services;
using SSCMS.Utils;

namespace SSCMS.QRCode
{
    public class StlQRCode : IPluginParseAsync
    {
        private const string AttributeUrl = "url";
        private const string AttributeSize = "size";

        private readonly IPathManager _pathManager;
        private readonly ISiteRepository _siteRepository;

        public StlQRCode(IPathManager pathManager, ISiteRepository siteRepository)
        {
            _pathManager = pathManager;
            _siteRepository = siteRepository;
        }

        public string ElementName => "stl:qrcode";

        public async Task<string> ParseAsync(IParseStlContext context)
        {
            var url = string.Empty;
            var size = 0;

            foreach (var name in context.StlAttributes.AllKeys)
            {
                var value = context.StlAttributes[name];

                if (StringUtils.EqualsIgnoreCase(name, AttributeUrl))
                {
                    url = await context.ParseAsync(value);
                }
                else if (StringUtils.EqualsIgnoreCase(name, AttributeSize))
                {
                    size = TranslateUtils.ToInt(value);
                }
            }

            url = string.IsNullOrEmpty(url) ? "location.href" : $"'{url}'";

            var guid = StringUtils.Guid();
            var site = await _siteRepository.GetAsync(context.SiteId);
            var libUrl = _pathManager.GetApiHostUrl(site, "/assets/qrcode/qrcode.min.js");

            return size == 0
                ? $@"
<div class=""qrcode"" id=""{guid}""></div>
<script type=""text/javascript"" src=""{libUrl}""></script>
<script type=""text/javascript"">
new QRCode(document.getElementById('{guid}'), {url});
</script>
"
                : $@"
<div class=""qrcode"" id=""{guid}""></div>
<script type=""text/javascript"" src=""{libUrl}""></script>
<script type=""text/javascript"">
new QRCode(document.getElementById('{guid}'), {{
    text: {url},
	width: {size},
	height: {size}
}});
</script>
";
        }
    }
}
