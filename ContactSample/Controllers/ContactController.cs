using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace ContactSample.Controllers
{
    public class ContactController : Controller
    {
        private IConfiguration _configuration;
        private readonly ILogger _logger;
        private IContactQueueService _ContactQueueService;

        public ContactController(IConfiguration configuration, ILogger<ContactController> logger, IContactQueueService ContactQueueService)
        {
            _configuration= configuration;
            _logger= logger;    
            _ContactQueueService= ContactQueueService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([Bind("Name,Email,Phone,Comments")] ContactFormModel model)
        {
            model.IP = Common.ResolveIPAddress(HttpContext);
            await _ContactQueueService.AddAsync(model, _configuration["SendMailQueueURL"]);
            _logger.LogInformation($"Contact added to queue. {model.LogSerialized});
            return RedirectToAction("Index");
        }
    }
}
