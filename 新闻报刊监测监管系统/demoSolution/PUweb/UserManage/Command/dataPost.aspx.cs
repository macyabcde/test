﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User.BLL;

namespace User.Web.Command
{
    public partial class dataPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUser = new WebUser();
            webUser.login();

        }
    }
}
