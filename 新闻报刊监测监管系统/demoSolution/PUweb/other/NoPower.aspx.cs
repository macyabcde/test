﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PU.web.other
{
    public partial class NoPower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();
        }
    }
}
