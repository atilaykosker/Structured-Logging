using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Structured_Logging.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        
        public void OnGet()
        {
            _logger.LogInformation("You requested the Index page.");

            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 56)
                    {
                        throw new Exception("Demo Exception");
                    }
                    else
                    {
                        _logger.LogInformation("The value of i is {LoopCountValue}", i);
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "We caught this exception in the Index Get Call!");
            }
        }
    }
}
