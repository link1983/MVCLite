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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace MVCLite.Web.Catalog
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ID);
				}
			}
		}
			
	private void ShowInfo(int ID)
	{
		MVCLite.BLL.Catalog bll=new MVCLite.BLL.Catalog();
		MVCLite.Model.Catalog model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtName.Text=model.Name;
		this.txtIntro.Text=model.Intro;
		this.txtStatus.Text=model.Status.ToString();
		this.txtAddTime.Text=model.AddTime.ToString();
		this.txtModifytime.Text=model.Modifytime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
			if(this.txtIntro.Text.Trim().Length==0)
			{
				strErr+="Intro不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtStatus.Text))
			{
				strErr+="Status格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtAddTime.Text))
			{
				strErr+="AddTime格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtModifytime.Text))
			{
				strErr+="Modifytime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.lblID.Text);
			string Name=this.txtName.Text;
			string Intro=this.txtIntro.Text;
			int Status=int.Parse(this.txtStatus.Text);
			DateTime AddTime=DateTime.Parse(this.txtAddTime.Text);
			DateTime Modifytime=DateTime.Parse(this.txtModifytime.Text);


			MVCLite.Model.Catalog model=new MVCLite.Model.Catalog();
			model.ID=ID;
			model.Name=Name;
			model.Intro=Intro;
			model.Status=Status;
			model.AddTime=AddTime;
			model.Modifytime=Modifytime;

			MVCLite.BLL.Catalog bll=new MVCLite.BLL.Catalog();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
