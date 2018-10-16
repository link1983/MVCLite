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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtID.Text))
			{
				strErr+="ID格式错误！\\n";	
			}
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
			int ID=int.Parse(this.txtID.Text);
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
