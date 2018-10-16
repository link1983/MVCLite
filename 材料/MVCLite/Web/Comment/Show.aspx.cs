using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace MVCLite.Web.Comment
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int ID=(Convert.ToInt32(strid));
					ShowInfo(ID);
				}
			}
		}
		
	private void ShowInfo(int ID)
	{
		MVCLite.BLL.Comment bll=new MVCLite.BLL.Comment();
		MVCLite.Model.Comment model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblContent.Text=model.Content;
		this.lbluserid.Text=model.userid.ToString();
		this.lblPID.Text=model.PID.ToString();
		this.lblusername.Text=model.username;
		this.lblAddTime.Text=model.AddTime.ToString();
		this.lblstatus.Text=model.status.ToString();
		this.lblarticleid.Text=model.articleid.ToString();

	}


    }
}
