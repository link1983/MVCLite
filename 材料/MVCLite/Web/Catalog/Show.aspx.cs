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
namespace MVCLite.Web.Catalog
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
		MVCLite.BLL.Catalog bll=new MVCLite.BLL.Catalog();
		MVCLite.Model.Catalog model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblName.Text=model.Name;
		this.lblIntro.Text=model.Intro;
		this.lblStatus.Text=model.Status.ToString();
		this.lblAddTime.Text=model.AddTime.ToString();
		this.lblModifytime.Text=model.Modifytime.ToString();

	}


    }
}
