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
namespace MVCLite.Web.Article
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
		MVCLite.BLL.Article bll=new MVCLite.BLL.Article();
		MVCLite.Model.Article model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblTitle.Text=model.Title;
		this.lblContent.Text=model.Content;
		this.lbllevelMax.Text=model.levelMax.ToString();
		this.lblCID.Text=model.CID.ToString();
		this.lblAddTime.Text=model.AddTime.ToString();
		this.lblModifytime.Text=model.Modifytime.ToString();
		this.lblclick.Text=model.click.ToString();

	}


    }
}
