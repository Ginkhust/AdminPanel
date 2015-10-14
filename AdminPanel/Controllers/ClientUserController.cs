using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AdminPanel.Models;
using Parse;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    public class ClientUserController : Controller
    {

        public async Task<ActionResult> DeleteClientUser(string id)
        {

            ParseQuery<ParseObject> q = ParseObject.GetQuery("ClientUser");
            ParseObject clientUser = await q.GetAsync(id);
            await clientUser.DeleteAsync();

            return RedirectToAction("ClientUserList");

        }

        #region[List Client User]
        public async Task<ActionResult> ClientUserList()
        {
            var query = new ParseQuery<ParseObject>("ClientUser");
            IEnumerable<ParseObject> clientUsers = await query.FindAsync();

            int count = await query.CountAsync();
            List<ClientUser> _clientUsers = new List<ClientUser>();

            foreach (ParseObject p in clientUsers)
            {
                ClientUser clientUser = new ClientUser();
                clientUser.ClientUserId = p.ObjectId;
                clientUser.firstName = p.Get<string>("firstName");
                clientUser.lastName = p.Get<string>("lastName");
                clientUser.emailAddress = p.Get<string>("emailAddress");
                clientUser.phoneNumber = p.Get<string>("phoneNumber");
                clientUser.birthday = p.Get<DateTime>("birthday");
                clientUser.address = p.Get<string>("address");
                _clientUsers.Add(clientUser);
            }

            ViewBag.count = count;
            return View(_clientUsers);
        }

        #endregion


    }
}