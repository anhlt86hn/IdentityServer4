using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class OAuthController : Controller
    {
        
        [HttpGet]
        public IActionResult Authorize(
            string response_type, // authorization flow type
            string client_id, // client id
            string redirect_uri, 
            string scope, // what info I want = email, grandma, tel
            string state) // random string generated to confirm that we are going to back the same client
        {
            // ?a=foo&b=bar
            var query = new QueryBuilder();
            query.Add("redirectUri", redirect_uri);
            query.Add("state", state);
            return View(model: query.ToString());
        }

        [HttpPost]
        public IActionResult Authorize(
            string username,           
            string redirect_uri,          
            string state)
        {
            const string code = "BABABA";
            return Redirect("");
        }

        public IActionResult Token()
        {
            return View();
        }

    }
}
