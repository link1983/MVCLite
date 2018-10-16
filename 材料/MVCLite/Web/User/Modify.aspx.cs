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
namespace MVCLite.Web.User
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
		MVCLite.BLL.User bll=new MVCLite.BLL.User();
		MVCLite.Model.User model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtname.Text=model.name;
		this.txtpassword.Text=model.password;
		this.txtstatus.Text=model.status.ToString();
		this.txtAddTime.Text=model.AddTime.ToString();
		this.txtModifytime.Text=model.Modifytime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(this.txtpassword.Text.Trim().Length==0)
			{
				strErr+="password不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtstatus.Text))
			{
				strErr+="status格式错误！\\n";	
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
			string name=this.txtname.Text;
			string password=this.txtpassword.Text;
			int status=int.Parse(this.txtstatus.Text);
			DateTime AddTime=DateTime.Parse(this.txtAddTime.Text);
			DateTime Modifytime=DateTime.Parse(this.txtModifytime.Text);


			MVCLite.Model.User model=new MVCLite.Model.User();
			model.ID=ID;
			model.name=name;
			model.password=password;
			model.status=status;
			model.AddTime=AddTime;
			model.Modifytime=Modifytime;

			MVCLite.BLL.User bll=new MVCLite.BLL.User();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
