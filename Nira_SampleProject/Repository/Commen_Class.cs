using Nira_SampleProject.DB;
using Nira_SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Nira_SampleProject.Repository
{
    public class Commen_Class
    {
        MesssageModel MesssageModel = new MesssageModel();
        Test_AppEntities Test_AppEntities = new Test_AppEntities();
        public object login(LoginModel model)
        {
            try
            {
                var dats = Test_AppEntities.tb_login.Where(x => x.login_Email == model.login_Email && x.login_Password == model.login_Password).FirstOrDefault();
                if (dats != null)
                {
                    MesssageModel.message = "Success";
                    MesssageModel.status = true;
                    MesssageModel.datas = dats;
                    return MesssageModel;

                }
                else
                {
                    MesssageModel.message = "UserName or Password Mismatch";
                    MesssageModel.status = false;
                    return MesssageModel;

                }



            }
            catch (Exception ex)
            {
                MesssageModel.message = ex.Message;
                MesssageModel.status = false;
                return MesssageModel;
            }

        }

        public object create_Login(LoginModel model)
        {
            try
            {
                //var dats = Test_AppEntities.tb_login.Where(x => x.login_Email == model.login_Email && x.login_Password == model.login_Password).FirstOrDefault();
                if (model.login_Name != null && model.login_Email != null && model.login_Password != null)
                {

                    var chekEmail = Test_AppEntities.tb_login.Where(x => x.login_Email == model.login_Email).FirstOrDefault();

                    if (chekEmail == null)
                    {
                        if (ValidateEmail(model.login_Email))
                        {
                            var datas = Test_AppEntities.tb_login.Create();
                            datas.login_Name = model.login_Name;
                            datas.login_Email = model.login_Email;
                            datas.login_Password = model.login_Password;
                            datas.login_IsActive = true;
                            datas.login_UpdatedDate = DateTime.Now;
                            datas.login_CreatedDate = DateTime.Now;
                            Test_AppEntities.tb_login.Add(datas);
                            Test_AppEntities.SaveChanges();


                            MesssageModel.message = "Account created successfully";
                            MesssageModel.status = true;
                            MesssageModel.datas = datas;
                            return MesssageModel;

                        }
                        else
                        {
                            MesssageModel.message = model.login_Email + " is Invalid Email Address";
                            MesssageModel.status = false;
                            return MesssageModel;

                        }


                    }
                    else
                    {

                        MesssageModel.message = "Email already exists";
                        MesssageModel.status = false;
                        return MesssageModel;

                    }



                }
                else
                {
                    MesssageModel.message = "Empty";
                    MesssageModel.status = false;
                    return MesssageModel;

                }



            }
            catch (Exception ex)
            {
                MesssageModel.message = ex.Message;
                MesssageModel.status = false;
                return MesssageModel;
            }

        }



        private bool ValidateEmail(string email)
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {                //lbl_message.Text = email + " is Valid Email Address";
                return true;
            }
            else
            {
                return false;
            }
            //lbl_message.Text = email + " is Invalid Email Address";


        }



    }
}